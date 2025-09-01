# Stage 5

## Track largest probability
- Add `maxPower` variable to Board
- Increment when merging
- Rewrite `goal_reached`

## Pick starting power
- Make array of probabilities
  ```cs
  readonly int[,] POWER_PROBABILITIES = {
    { 100,  0,  0,  0 },
    { 100,  0,  0,  0 },
    {  95,  5,  0,  0 },
    {  90, 10,  0,  0 },
    {  88, 12,  0,  0 },
    {  85, 15,  0,  0 },
    {  83, 15,  2,  0 },
    {  82, 15,  3,  0 },
    {  81, 15,  3,  1 },
    {  80, 15,  3,  2 },
    {  80, 15,  3,  2 },
  };
```
- Make `pickPower` function
- Use when making tile
