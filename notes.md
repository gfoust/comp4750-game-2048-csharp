# Stage 1

1.  Start with Tile scene
	- Node2D
	- Add ColorRect
	  + Set color
	  + Set size to 119x119 (Layout, Transform)
	  + Set offset to (1, 1)
	  + This makes it 120x120, with border at top-left
	- Add Label (under ColorRect)
	  + Set text
	  + Fill ColorRect
	  + Set Horizontal and Vertical Align properties
	  + Set font size = 48px
2.  Make a tile script (C#!)
	- Make power var (export, init 1)
	- How can we get label?
	- Create _ready method
	  + Use `GetNode` to get label (compare to GD)
	  + Set label text to `str(2**power)` (view)
	  + Make the Color array
		  * readonly vs static
	  + Set color to `_colors[power]`
3.  Make a board scene
	- Add a ColorRect for background (481x481, #666)
	  + Discuss: ColorRect could be the root node
	- Add a tile (to the middle)
	  + Discuss instantiate scene vs node
	- We want tile to change when power changes
	  + Make property
	  + Make `_updateTile`
		+ Make a guard for before ready
	  + Make tile a tool
	- Add script
	  + Add tile variable; init in _Ready
	  + Use _input method to move tile to edges
	  + Add tween to animate the movement
		  * IMPORTANT: must use GDScript name ("position") for tween
	- Notice what happens when you change directions quickly
	  + Make a `_busy` variable (false)
			+ Make `_moveTile` that does the tween
			  * Branches on input call `_moveTile`
				* Set `_busy` to true
			+ Make a `_onMoveTileDone` for when it is done
			  * Set `_busy` to false
				* Discuss lambdas
			+ Make guard for `_Input`
