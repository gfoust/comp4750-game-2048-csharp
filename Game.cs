using Godot;
using System;

public partial class Game : Panel
{
  Board board = null!;
  Label gameOverLabel = null!;
  CanvasLayer gameOverScreen = null!;
  Button playAgainButton = null!;

  public override void _Ready()
  {
    board = GetNode<Board>("Board");
    gameOverScreen = GetNode<CanvasLayer>("GameOverScreen");

    gameOverLabel = GetNode<Label>("%GameOverLabel");
    playAgainButton = GetNode<Button>("%PlayAgainButton");

    gameOverScreen.Hide();
  }


  public void OnGameOver(bool win)
  {
    if (win)
    {
      gameOverLabel.Text = "You win!\n";
    }
    else
    {
      gameOverLabel.Text = "You lose!\n";
    }

    gameOverScreen.Show();
    playAgainButton.GrabFocus();
  }

  public void OnNewGameButtonPress()
  {
    gameOverScreen.Hide();
    board.Reset();
  }
}
