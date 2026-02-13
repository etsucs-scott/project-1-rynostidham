using System;

public class Maze
{
	public Tile[,] Tiles { get; }
	public int Width { get; }
	public int Height { get; }

	public int PlayerX { get; private set; }
	public int PlayerY { get; private set; }

	public Maze(int width, int height)
	{
		Width = width;
		Height = height;
		Tiles = new Tile[width, height];

		for (int x = 0; x < width; x++)
			for (int y = 0; y < height; y++)
				Tiles[x, y] = new Tile();
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

	public void PlacePlayer(Player player)
	{
		PlayerX = 0;
		PlayerY = 0;
		player.X = PlayerX;
		player.Y = PlayerY;
	}

	public void MovePlayerTo(Player player, intx, int y)
	{
		PlayerX = x;
		PlayerY = y;
		player.X = x;
		player.Y = y;
	}

}

