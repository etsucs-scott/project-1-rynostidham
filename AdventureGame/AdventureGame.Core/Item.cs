using System;
using AdventureGame.Core;

public abstract class Item
{
	public string Name { get; }
	public string PickupMessage {  get; }

	protected Item(string name, string pickupMessage)
	{
		Name = name;
		PickupMessage = pickupMessage;
	}

	public abstract void OnPickup(Player player);
}
