# Stage 3

## Create a "back grid"
- Make `backgrid` variable
- Move slide logic into `slideOne`; rename `slide` to `slideAll`
  + Everything inside `if (this[src.Current] != null)` goes to `slideOne`
  + Note `slideOne` must return bool to update `changed`
- Update `slideOne` with logic for merging tiles
- Update `moveTiles` to iterate over both grids
- Update `onTileMoveDone` to delete merged
- Update `Tile` to animate color changes
  + Use `init` parameter to distinguish between initial value and change
