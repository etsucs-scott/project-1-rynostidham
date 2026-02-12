using System;
using AdventureGame.Core;

public class Potion : Item 
{
	//Potions always heal for 20
	public int HealAmount { get; } = 20;

	public Potion(string name)
		:base(name, $"You drink {name}!")
	{
	}
	
    public override void OnPickup(Player player)
    {
        player.Heal(HealAmount);
    }
	
}
