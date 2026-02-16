using System.Text;

namespace AdventureGame.Core
{ //Bulky class that implements all maze rules as well as creates win and lose variables 
    public class GameEngine
    {
        public Maze Maze { get; }
        public Player Player { get; }

        public bool IsGameOver { get; private set; }
        public bool PlayerWon { get; private set; }

        public GameEngine(int width, int height)
        {
            Maze = new Maze(width, height);
            Player = new Player();
            Maze.PlacePlayer(Player);
        }
        //Game rules that allow player movement and for engine to know what is on the current tile 
        public string MovePlayer(Direction direction)
        {
            if (IsGameOver)
                return "Game is over!";

            int newX = Player.X;
            int newY = Player.Y;

            switch (direction)
            {
                case Direction.Up: newY--; break;
                case Direction.Down: newY++; break;
                case Direction.Left: newX--; break;
                case Direction.Right: newX++; break;
            }
            //Ensures character can not move outside of maze or into a wall 
            if (!Maze.IsInside(newX, newY))
                return "Can't move off grid!";

            var tile = Maze.GetTile(newX, newY);

            if (tile.IsWall)
                return "A wall is in the way";

            if (tile.Monster != null)
            {
                string battleResult = Battle(tile.Monster);

                if (Player.Health <= 0)
                {
                    IsGameOver = true;
                    PlayerWon = false;
                    return battleResult + " You were killed. Game over!";
                }

                tile.Monster = null;
                Maze.MovePlayerTo(Player, newX, newY);
                return battleResult + " Monster defeated!";
            }

            if (tile.Item != null)
            {
                Item item = tile.Item;
                tile.Item = null;

                Player.PickUp(item);
                Maze.MovePlayerTo(Player, newX, newY);
                return item.PickupMessage;
            }

            if (tile.IsExit)
            {
                Maze.MovePlayerTo(Player, newX, newY);
                IsGameOver = true;
                PlayerWon = true;
                return "Exit found, you win!";
            }

            Maze.MovePlayerTo(Player, newX, newY);
            return "You've moved to a new tile.";
        }
        //Contains all battle logic showing health of player and monster after attack
        private string Battle(Monster monster)
        {
            var log = new StringBuilder();

            while (Player.Health > 0 && monster.Health > 0)
            {
                Player.Attack(monster);
                log.AppendLine($"You hit the monster. Monster HP: {monster.Health}");

                if (monster.Health <= 0)
                    break;

                monster.Attack(Player);
                log.AppendLine($"The monster hit you. Your HP: {Player.Health}");

                if (Player.Health <= 0)
                {
                    log.AppendLine("You were killed by a monster.");
                    break;
                }
            }

            return log.ToString().TrimEnd();
        }
    }
}
