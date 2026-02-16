using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{//Class for characters health, current inventory, and damage 
    public class Player : ICharacter
    {
        public int Health { get; private set; } = 100;
        public int MaxHealth { get; } = 150;

        public int X { get; set; }
        public int Y { get; set; }

        public List<Item> Inventory { get; } = new List<Item>();
        //Inventory sort system that insures the best weapon is being used 
        public Weapon BestWeapon =>
            Inventory
                .OfType<Weapon>()
                .OrderByDescending(w => w.Modifier)
                .FirstOrDefault();

        private const int BaseDamage = 10;

        public void Attack(ICharacter target)
        {
            int damage = BaseDamage;

            if (BestWeapon != null)
                damage += BestWeapon.Modifier;

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
