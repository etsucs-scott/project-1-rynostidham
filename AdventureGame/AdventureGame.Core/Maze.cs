using System;

namespace AdventureGame.Core
{//Class for creating the maze and getting our width and heighth of maze as well as player location
    public class Maze
    {
        public Tile[,] Tiles { get; }
        public int Width { get; }
        public int Height { get; }

        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }
        
        private readonly Random rng = new Random();

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new Tile[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    Tiles[x, y] = new Tile();

            GenerateMaze();
        }

        public class Tile
        {
            public bool IsWall { get; set; }
            public Item Item { get; set; }
            public Monster Monster { get; set; }
            public bool IsExit { get; set; }
        }

        public bool IsInside(int x, int y) =>
            x >= 0 && x < Width && y >= 0 && y < Height;

        public Tile GetTile(int x, int y) => Tiles[x, y];

        //Ensures player starts a grid 1,1 previous error spawned player in wall
        public void PlacePlayer(Player player)
        {
            PlayerX = 1;
            PlayerY = 1;
            player.X = PlayerX;
            player.Y = PlayerY;
        }

        public void MovePlayerTo(Player player, int x, int y)
        {
            PlayerX = x;
            PlayerY = y;
            player.X = x;
            player.Y = y;
        }
        //Implements the rng effect into game and allows for a new maze every generation 
        private void GenerateMaze()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    // Border walls
                    if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                    {
                        Tiles[x, y].IsWall = true;
                        continue;
                    }

                    // Random inner walls
                    if (rng.NextDouble() < 0.15)
                        Tiles[x, y].IsWall = true;

                    // Random monsters
                    if (!Tiles[x, y].IsWall && rng.NextDouble() < 0.10)
                        Tiles[x, y].Monster = new Monster();

                    // Random items
                    if (!Tiles[x, y].IsWall && Tiles[x, y].Monster == null && rng.NextDouble() < 0.10)
                    {
                        if (rng.NextDouble() < 0.5)
                            Tiles[x, y].Item = new Potion("Potion");
                        else
                            Tiles[x, y].Item = new Weapon("Sword", rng.Next(1, 6));
                    }
                }
            }

            // Place exit near bottom-right
            int exitX = Width - 2;
            int exitY = Height - 2;

            Tiles[exitX, exitY].IsWall = false;
            Tiles[exitX, exitY].Monster = null;
            Tiles[exitX, exitY].Item = null;
            Tiles[exitX, exitY].IsExit = true;
        }
    }
}
