namespace AdventureGame.Core
{//Interface for all monsters and the player
    public interface ICharacter
    {
        int Health { get; }
        void Attack(ICharacter target);
        void TakeDamage(int amount);
    }
}
