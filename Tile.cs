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
      updateTile(true);
    }
  }


  private int power = 1;
  private ColorRect square = null!;
  private Label label = null!;


  public override void _Ready()
  {
    square = GetNode<ColorRect>("Square");
    label = GetNode<Label>("Square/Label");
    updateTile(false);
  }


  private void updateTile(bool animate)
  {
    if (square == null) return;

    Color color;
    if (Power > 0 && Power < _colors.Length)
    {
      color = _colors[Power];
    }
    else
    {
      color = _colors[0];
    }
    if (animate)
    {
      CreateTween().TweenProperty(square, "color", color, 0.3333);
    }
    else
    {
      square.Color = color;
    }
    label.Text = Math.Pow(2, Power).ToString();
  }

}

