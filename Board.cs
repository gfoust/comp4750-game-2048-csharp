using Godot;
using System;

public partial class Board : Node2D
{
  Tile tile = null!;
  bool busy = false;

  public override void _Ready()
  {
    tile = GetNode<Tile>("Tile");
  }


  public override void _Input(InputEvent @event)
  {
    if (busy) return;

    var newPos = tile.Position;
    if (@event.IsActionPressed("ui_left"))
    {
      newPos.X = 0;
    }
    else if (@event.IsActionPressed("ui_right"))
    {
      newPos.X = 360;
    }
    else if (@event.IsActionPressed("ui_up"))
    {
      newPos.Y = 0;
    }
    else if (@event.IsActionPressed("ui_down"))
    {
      newPos.Y = 360;
    }

    if (newPos != tile.Position)
    {
      moveTile(tile, newPos);
    }
  }


  private void moveTile(Tile tile, Vector2 newPosition)
  {
    busy = true;
    Tween tween = CreateTween();
    Console.WriteLine($"Tweening {tile.Name} from {tile.Position} to {newPosition}");
    tween.TweenProperty(tile, "position", newPosition, 0.33333);
    tween.Finished += onMoveFinished;
  }

  private void onMoveFinished()
  {
    busy = false;
  }


}
