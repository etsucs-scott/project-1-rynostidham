using System;
using AdventureGame.Core;

namespace AdventureGame.Cli
{
    class Program
    {
        static void Main()
        {
            GameEngine engine = new GameEngine(10, 10);

            string lastMessage = "Welcome to the maze";

            while (!engine.IsGameOver)
            {
                Console.Clear();
                DrawMaze(engine);

                Console.WriteLine();
                Console.WriteLine(lastMessage);
                Console.WriteLine();
                Console.WriteLine($"HP: {engine.Player.Health}");
                //Picks up inputs form W A S D for movement 
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                Direction? direction = key.Key switch
                {
                    ConsoleKey.W => Direction.Up,
                    ConsoleKey.S => Direction.Down,
                    ConsoleKey.A => Direction.Left,
                    ConsoleKey.D => Direction.Right,
                    _ => null
                };

                if (direction == null)
                {
                    lastMessage = "Use W A S D to move.";
                    continue;
                }

                lastMessage = engine.MovePlayer(direction.Value);
            }

            Console.Clear();
            DrawMaze(engine);
            Console.WriteLine();

            Console.WriteLine(engine.PlayerWon ? "You win!" : "You lose.");
            Console.WriteLine("Press any key to exit the maze");
            Console.ReadKey(true);
        }

        static void DrawMaze(GameEngine engine)
        {
            Maze maze = engine.Maze;

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    if (engine.Player.X == x && engine.Player.Y == y)
                    {
                        Console.Write("@ ");
                        continue;
                    }

                    var tile = maze.Tiles[x, y];

                    if (tile.IsWall)
                        Console.Write("# ");
                    else if (tile.Monster != null)
                        Console.Write("M ");
                    else if (tile.Item is Weapon)
                        Console.Write("W ");
                    else if (tile.Item is Potion)
                        Console.Write("P ");
                    else if (tile.IsExit)
                        Console.Write("E ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
        }
    }
}
