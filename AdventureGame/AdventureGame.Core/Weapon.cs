namespace AdventureGame.Core
{//Class that displays weapons when picked up and assigns a modifier 
    public class Weapon : Item
    {
        public int Modifier { get; }

        public Weapon(string name, int modifier)
            : base(name, $"You picked up {name}!")
        {
            Modifier = modifier;
        }

        public override void OnPickup(Player player)
        {
            // Weapons stay in inventory
        }
    }
}
