# Stage 2

## Get rid of individual tile

- Delete tile from board
- This will break Board
	+ In `_Input` change if branches to `pass`
	+ In `moveTiles` remove `tween_property`

## Add tiles dynamically

- Make `GRID_SIZE` (int)
- Make/initialize `grid` variable
- Make `addTileToGrid`
  + Save `busy = false` line for later
  + Make `empty_tiles` variable
  + Put in nth empty slot, where n is random
  + Note: NOT `Tile.new()`; instead...
- Make `make_tile`
  + Make `tile_scene` variable
  + Create / initialize tile
- Add input for `ui_accept` to call `add_tile_to_grid`

## Make tiles slide

- Discuss abstraction, leading to iterator
  + Discuss C# iterators (IEnumerator)
  + Discuss our iterator interface (iterate over vectors)
- Make `Dir` enum
- Make `SliceItr` iterator
  + Implement interface
	+ Discuss yield
- Make `slide` method
  + Note: rearranging array has no visual effect
- Revisit `moveTile` (=> `moveTiles`)
  + Tween all tiles positions
  + Don't cover tween properties yet
- Debugging
  - Add `addTileToGrid()` to `_Ready`
  - Add `busy = false` to end of `addTileToGrid`
  - Add `set_parallel`
  - Add trans/ease
