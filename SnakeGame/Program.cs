namespace SnakeGame
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    internal class Program
    {

        //                  Elsana Kanybek      -       elkanybek


        static Int32 direction = 1;
        static Int32 foodX = 0;
        static Int32 foodY = 0;
        static Int32 victory = 9;
        static void Main()
        {
            Console.CursorVisible = false;
            
            MainMenu();
            Console.ReadKey();

            Int32[] snakeX = { Console.BufferWidth / 2 };
            Int32[] snakeY = { Console.BufferHeight / 2 };
            Task.Run(() =>      //Timeline 1
            {
                GetInputSnake();
            });
            Task.Run(() =>      //Timeline 2
            {
                AddFood();
            });

            Boolean GameOver = false;
            Boolean Win = false;
            while (!GameOver && !Win)
            {
                Console.Clear();
                BuildWalls();
                ShowSnake(ref snakeX, ref snakeY);
                ShowFood();
                EatFood(ref snakeX, ref snakeY);
                GameOver = IsSnakeDead(ref snakeX, ref snakeY);
                Win = IsSnakeWin(ref snakeX);
                Thread.Sleep(100);       //Adapt speed to your console. Because different size of consoles.
            }
            if (Win)
            {
                Console.SetCursorPosition(Console.BufferWidth / 3, Console.BufferHeight / 2);
                Console.Write("You ate " + victory + " fruits!!! ");
                Console.Write("Congradulation you won. ");
            }
            Console.Write("Game Over.");
            Console.ReadLine();
        }

        static void MainMenu()      //Instructions
        {
            Console.WriteLine("Intructions: ");
            Console.WriteLine("1. You are the snake.");
            Console.WriteLine("2. Your goal is to eat " + victory + " fruits to win and grow the snake's size.");
            Console.WriteLine("3. Don't touch the walls.");
            Console.WriteLine("4. Use the left, right, up, down arrows to move.");
            Console.WriteLine("Press any key, when ready.");
        }

        static void BuildWalls()
        {
            Console.SetCursorPosition(0, 0);        //Beginning position

            for (Int32 i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write("-");     //Draw up horizontal wall
            }

            for (Int32 i = 0; i < Console.BufferHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");     //Draw left vertical wall
            }

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            for (Int32 i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, Console.BufferHeight - 1);
                Console.Write("-");     //Draw down horizontal wall
            }

            for (Int32 i = 0; i < Console.BufferHeight; i++)
            {
                Console.SetCursorPosition(Console.BufferWidth - 1, i);
                Console.Write("|");     //Draw right vertical wall
            }
        }

        static void ShowSnake(ref Int32[] snakeX, ref Int32[] snakeY)
        {
            //Console.SetCursorPosition(Console.BufferHeight / 2, Console.BufferWidth / 2);
            //Position middle

            for (Int32 i = snakeX.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(snakeX[i], snakeY[i]);        //For each X and Y of the array
                if (i == 0)
                {
                    Console.Write("O");     //Head of the snake
                    switch (direction)      //Depending on the GetInputSnake()
                    {
                        case 1:
                            snakeX[i]--;
                            break;

                        case 2:
                            snakeX[i]++;
                            break;

                        case 3:
                            snakeY[i]--;
                            break;

                        case 4:
                            snakeY[i]++;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.Write("o");     //Body of the snake
                    snakeX[i] = snakeX[i - 1];
                    snakeY[i] = snakeY[i - 1];
                }
            }
        }

        static void GetInputSnake()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);     //User uses arrows to control directions
                switch (key.Key)        //Used in the ShowSnake()
                {
                    case ConsoleKey.LeftArrow:
                        direction = 1;
                        break;

                    case ConsoleKey.RightArrow:
                        direction = 2;
                        break;

                    case ConsoleKey.UpArrow:
                        direction = 3;
                        break;

                    case ConsoleKey.DownArrow:
                        direction = 4;
                        break;

                    default:
                        direction = 0;
                        break;
                }
            }
        }

        static void AddFood()
        {
            Random randX = new Random();
            Random randY = new Random();        //Random food 
            while (true)
            {
                foodX = randX.Next(0, Console.BufferWidth - 1);
                foodY = randY.Next(0, Console.BufferHeight - 1);
                Thread.Sleep(11000);     //The speed of the appearing food 
            }
        }

        static void ShowFood()
        {
            if (foodX != 0 && foodY != 0)
            {
                Console.SetCursorPosition(foodX, foodY);
                Console.Write("#");     //Appearing on the screen
            }
        }

        static void EatFood(ref Int32[] snakeX, ref Int32[] snakeY)
        {
            if (snakeX[0] == foodX && snakeY[0] == foodY)       //Taking the food
            {
                Int32[] tempX = snakeX;
                Int32[] tempY = snakeY;
                snakeX = new Int32[tempX.Length + 1];
                snakeY = new Int32[tempY.Length + 1];

                foodX = 0;
                foodY = 0;

                for (Int32 i = 0; i < tempX.Length; i++)
                {
                    snakeX[i] = tempX[i];
                    snakeY[i] = tempY[i];
                }
                snakeY[snakeX.Length - 1] = snakeX[snakeX.Length - 2]++;
                snakeY[snakeY.Length - 1] = snakeY[snakeY.Length - 2];
            }
        }

        static Boolean IsSnakeDead(ref Int32[] snakeX, ref Int32[] snakeY)
        {
            return snakeX[0] == Console.BufferWidth || snakeY[0] == Console.BufferHeight || snakeX[0] == 0 || snakeY[0] == 0;       //If snake touches the wall, game over.
        }

        static Boolean IsSnakeWin(ref Int32[] snakeX)
        {
            return snakeX.Length > victory;
        }
    }
}


