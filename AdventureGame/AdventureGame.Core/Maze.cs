using System;

public class Maze
{
	public Tile[,] Tiles { get; }
	
	public Maze(int width, int height)
	{
		Tiles = new Tile[width, height];

		for (int x = 0; x < width; x++)
			for (int y = 0; y < height; y++)
				Tiles[x, y] = new Tile();
	}

	public class Tile
	{
		public bool IsWall { get; set; }
		public Item item {  get; set; }
		public Monster Monster { get; set; }
		public bool IsExit { get; set; }
	}
	
}
