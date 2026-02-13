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
    //Checks walls, handles items, exits, monsters, etc
    public string MovePlayer(Direction direction)
    {
        if (IsGameOver)
            return "Game is over!";

        int newX = Player.X;
        int newY = Player.Y;

        switch (direction)
        {
            case Directionn.Up: newY--; break;
            case Direction.Down: newY--; break;
            case Direction.Left: newX--; break;
            case Direction.Right: newX++; break;
        }

        if (!Maze.IsInside(newX, newY))
            return "Can't move off grid!";

        var tile = Maze.GetTile (newX, newY);

        if (tile.IsWall)
            return "A wall is in the way";

        if (tile.Monster != null)
        {
            string battleResult = battleResult(tile.Monster);

            if (Player.Health <= 0)
            {
                IsGameOver = true;
                PlayerWon = false;
                return battleResult + "You were killed. Game over!";
            }

            tile.Monster = null;
            Maze.MovePlayerTo(Player, newX, newY);
            return battleResult + "Monster defeated";

            if (tile.Item != null)
            {
                Item item = tile.Item;
                tile.Item = null;

                Player.Pickup(item);

                Maze.MovePlayerTo(Player, newX, newY);
                return item.PickupMessage;
            }

            if (tile.IsExit)
            {
                Maze.MovePlayerTo(Player, newX, newY);
                IsGameOver = true;
                PlayerWon = true;
                return "Exit found you win!";
            }

            Maze.MovePlayerTo(Player, newX, newY);
            return "You've moved to a new tile";
        }
        //Retrives all damage done to player and monster and returns 
        private string Battle(Monster monster)
    {
        var log = new System.Text.StringBuilder();

        while (Player.Health > 0 && monster.Health > 0)
        {
            Player.Attack(monster);
            log.AppendLine($"Monster HP: {monster.Health}");

            if (monster.Health <= 0)
            {
                log.AppendLine($"You hit the monster. Monster HP: {monster.Health}");
                break;
            }

            monster.Attack(Player);
            log.AppendLine($"The monster hit you. Your HP: {Player.Health}");

            if Player.Health <= 0)
            {
                log.AppendLine("You were killed by a monster.");
                break;
            }
        }

        return log.ToString().TrimEnd();

        }
    }
}
