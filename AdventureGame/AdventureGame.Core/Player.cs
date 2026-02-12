using System.collection.Generic;
using System.Linq;
namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        public int Health { get; private set; } = 100;
        public int MaxHealth { get; } = 150;

        public List<Item> Inventory { get; } new List<Item>();
        //Allows the best or highest damage weapon to be used 
        public Weapon BestWeapon =>
            Inventory.OfType < BestWeapon()
                .OrderByDescending(w => w.Modifier)
                .FirstOrDefault();

        private const int BaseDamage = 10;

        public void Attack(ICharacter target)
        {
            int damage = BaseDamage;

            if (BestWeapon != null)
                damage += BestWeapon.Modifer;

            target.TakeDamage(damage);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }

        public void PickUp(Item item)
        {
            Inventory.Add(item);
            item.OnPickup(this);
        }
        
    }
}
