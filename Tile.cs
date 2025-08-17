using Godot;
using System;

[Tool]
public partial class Tile : Node2D
{
  private static readonly Color[] _colors = {
      Colors.Black,
      Colors.DarkBlue,
      Colors.DarkCyan,
      Colors.CadetBlue,
      Colors.SeaGreen,
      Colors.WebGreen,
      Colors.YellowGreen,
      Colors.DarkKhaki,
      Colors.Goldenrod,
      Colors.Orange,
      Colors.OrangeRed,
      Colors.DarkRed
  };


  [Export]
  public int Power
  {
    get
    {
      return power;
    }
    set
    {
      power = value;
      updateTile();
    }
  }


  private int power = 1;
  private ColorRect square = null!;
  private Label label = null!;


  public override void _Ready()
  {
    square = GetNode<ColorRect>("Square");
    label = GetNode<Label>("Square/Label");
    updateTile();
  }


  private void updateTile()
  {
    if (square == null) return;

    if (Power > 0 && Power < _colors.Length)
    {
      square.Color = _colors[Power];
    }
    else
    {
      square.Color = _colors[0];
    }
    label.Text = Math.Pow(2, Power).ToString();
  }

}

