Snake Game Overview:

Objective: Guide the snake to eat 9 fruits, grow, and avoid collisions with walls.
Controls: Use arrow keys (up, down, left, right) to navigate the snake.
Game Elements:
Snake: Displayed as "O" (head) and "o" (body).
Walls: Form boundaries to prevent snake movement outside.
Fruits: "#" symbols appearing randomly on the screen.
Gameplay:
Main Menu: Displays instructions and prompts the player to start when ready.
Snake Movement: Controlled by arrow keys, continuously updating in separate thread (GetInputSnake method).
Walls: Boundaries are built around the console screen.
Food Generation: Randomly placed on the screen, represented by "#" (triggered by AddFood method).
Collision Detection:
Wall Collision: Game over if the snake hits any wall.
Fruit Consumption: Snake grows when it consumes a fruit, adding a segment to its body.
Win Condition: Achieved when the snake's length surpasses 9 fruits.
Outcome:
Display "Game Over" if the snake collides with a wall.
Display victory message and total fruits consumed if the snake wins.
Speed: Adjustable speed (Thread.Sleep) for adapting to different console sizes.
Console Interaction: Hides the cursor for a cleaner interface.
Main Method Flow:
Display Main Menu.
Initialize snake and food.
Run input and food generation in separate threads.
Continuously update and display game elements.
Check for collisions and victory conditions.
Display appropriate messages on game outcome.
Note: Modify speed for different console sizes for optimal gameplay.