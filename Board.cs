using Godot;
using System;
using System.Collections;
using System.Collections.Generic;


public partial class Board : Node2D
{
  public enum Dir { Up, Down, Left, Right };


  const int GRID_SIZE = 4;
  const float TILE_SIZE = 120;


  bool busy = false;
  TileGrid grid = new TileGrid(GRID_SIZE);
  int emptyTiles = GRID_SIZE * GRID_SIZE;
  Random random = new Random();
  PackedScene tileScene = GD.Load<PackedScene>("res://tile.tscn");


  public override void _Ready()
  {
    addTileToGrid();
  }



  public override void _Input(InputEvent @event)
  {
    if (busy) return;

    Dir? dir = null;

    if (@event.IsActionPressed("ui_left"))
    {
      dir = Dir.Left;
    }
    else if (@event.IsActionPressed("ui_right"))
    {
      dir = Dir.Right;
    }
    else if (@event.IsActionPressed("ui_up"))
    {
      dir = Dir.Up;
    }
    else if (@event.IsActionPressed("ui_down"))
    {
      dir = Dir.Down;
    }

    if (dir.HasValue && slide(dir.Value))
    {
      moveTiles();
    }
  }


  private void moveTiles()
  {
    busy = true;
    Tween tween = CreateTween();
    tween.SetParallel(true);
    tween.SetTrans(Tween.TransitionType.Quart);
    tween.SetEase(Tween.EaseType.Out);
    for (int i = 0; i < GRID_SIZE; ++i)
    {
      for (int j = 0; j < GRID_SIZE; ++j)
      {
        if (grid[i, j] != null)
        {
          tween.TweenProperty(
            grid[i, j],
            "position",
            new Vector2(i * TILE_SIZE, j * TILE_SIZE),
            0.3333
          );
        }
      }
    }
    tween.Finished += addTileToGrid;
  }


  private void addTileToGrid()
  {
    busy = false;
    if (emptyTiles > 0)
    {
      int n = random.Next(emptyTiles);
      for (int i = 0; i < GRID_SIZE; ++i)
      {
        for (int j = 0; j < GRID_SIZE; ++j)
        {
          if (grid[i, j] == null)
          {
            if (n == 0)
            {
              grid[i, j] = makeTile(i, j);
              return;
            }
            --n;
          }
        }
      }
    }
  }


  private Tile makeTile(int i, int j)
  {
    Tile tile = tileScene.Instantiate<Tile>();
    tile.Position = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
    AddChild(tile);
    --emptyTiles;
    return tile;
  }


  private bool slide(Dir dir)
  {
    bool changed = false;  // Wait until you know why you need it

    for (int i = 0; i < GRID_SIZE; ++i)
    {
      var dst = slice(dir, i);
      dst.MoveNext();

      var src = slice(dir, i);
      while (src.MoveNext())
      {
        if (grid[src.Current] != null)
        {
          if (src.Current != dst.Current)
          {
            grid[dst.Current] = grid[src.Current];
            grid[src.Current] = null;
            changed = true;
          }
          dst.MoveNext();
        }
      }
    }

    return changed;
  }


  private static IEnumerator<Vector2I> slice(Dir dir, int along)
  {
    bool xAligned = dir == Dir.Left || dir == Dir.Right;

    int begin, end, inc;
    if (dir == Dir.Left || dir == Dir.Up)
    {
      begin = 0;
      end = GRID_SIZE;
      inc = 1;
    }
    else
    {
      begin = GRID_SIZE - 1;
      end = -1;
      inc = -1;
    }

    for (int current = begin; current != end; current += inc)
    {
      if (xAligned)
      {
        yield return new Vector2I(current, along);
      }
      else
      {
        yield return new Vector2I(along, current);
      }
    }
  }


  // For Illustration Purposes
  class SliceIterator : IEnumerator<Vector2I>
  {
    private Dir dir;
    private int along;

    private int begin;
    private int end;
    private bool xAligned;
    private int inc;
    private int current;


    public SliceIterator(Dir dir, int along)
    {
      this.dir = dir;
      this.along = along;

      if (dir == Dir.Left || dir == Dir.Up)
      {
        begin = 0;
        end = GRID_SIZE - 1;
      }
      else
      {
        begin = GRID_SIZE - 1;
        end = 0;
      }

      xAligned = dir == Dir.Left || dir == Dir.Right;
      inc = dir == Dir.Left || dir == Dir.Up ? -1 : 1;
      current = begin;
    }


    Vector2I IEnumerator<Vector2I>.Current
    {
      get
      {
        if (xAligned)
        {
          return new Vector2I(current, along);
        }
        else
        {
          return new Vector2I(along, current);
        }
      }
    }

    object IEnumerator.Current
    {
      get
      {
        if (xAligned)
        {
          return new Vector2I(current, along);
        }
        else
        {
          return new Vector2I(along, current);
        }
      }
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
      current += inc;
      return current != end;
    }

    public void Reset()
    {
      current = begin - inc;
    }
  }
}


public struct TileGrid
{
  private Tile?[,] tiles;

  public TileGrid(int gridSize)
  {
    tiles = new Tile[gridSize, gridSize];
  }

  public Tile? this[int x, int y]
  {
    get => tiles[x, y];
    set => tiles[x, y] = value;
  }

  public Tile? this[Vector2I pos]
  {
    get => tiles[pos.X, pos.Y];
    set => tiles[pos.X, pos.Y] = value;
  }
}
