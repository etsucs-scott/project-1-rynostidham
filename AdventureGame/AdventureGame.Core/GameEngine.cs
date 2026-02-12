using System;

public class GameEngine 
{
    public Maze Maze { get; }
    public Player Player { get; }

    public bool IsGameOver { get; private set; }
    public bool PlayerWon { get; private set; }

    public GameEngine(int widht, int height)
    {
        Maze = new Maze(width, height);
        Player = new Player();
        Maze.PlacePlayer(Player);
    }

    public string MovePlayer(Direction direction)
    {
        // returns a message describing what happened 
    }
}
