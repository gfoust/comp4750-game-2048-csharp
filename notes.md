# Stage 4

## Make a game scene
- Use panel as root node
  + Size 496x577
  + Add new `StyleBoxFlat` theme override
  + Border-width 8 (#eee)
- Add label to panel
  + Text "2048"
  + Font size 64px
  + Shadow 4px #00000080
  + Anchor across the top, center align
- Add board to panel
  + offset 8, 88
- Run
  + Set main scene
  + Set window dimensions 496x577
  + Set stretch mode = canvas items

## Make a game over screen
- Add CanvasLayer (name GameOverScreen)
- Add Panel to CanvasLayer
  + 481 x 481
  + offset 8, 88
- Add Label to Panel
  + Text "Game Over"
  + Save previous label's settings and load them here
  + Center; add newline to push up slightly
- Add Button to Panel ("Play again")
  + Anchor across bottom
  + Theme Overrides -> Font Sizes -> 48
- Run program to show
- Hide it

## Detect when game is won
- Add game_over(bool) signal to board
- Add `goal_reached` function
  + Export a goal variable for goal
- Add branch to end of `_on_tile_move_done` to emit signal when goal reached
  + Point out that listening will remain false

## Add game over logic
- Add script to game
- Add handler for game_over signal
  + Set label text, show screen
  + Focus button
- Add handler for button press
- Add reset function to board
- Test win and reset

## Detect when game is lost
- Note that `empty_tiles == 0` is not enough
- Add `no_more_moves_possible` function
- Remove return
  + Discuss issue with breaking out of nested loop
  + Allow loop to finish
- Move `listening = true` to end
- Add branch to test for lost game at the end
