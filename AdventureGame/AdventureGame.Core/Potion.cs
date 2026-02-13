namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int HealAmount { get; } = 20;

        public Potion(string name)
            : base(name, $"You drink {name}!")
        {
        }

        public override void OnPickup(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}
