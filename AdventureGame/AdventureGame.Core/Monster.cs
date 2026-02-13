using System;

public class Monster : ICharacter 
{
	private static readonly Random rng = new Random();

	public int Health { get; private set; }
	
	public int AttackPower { get; }
	//Monster does random damage from 30-50
	public Monster()
	{
		Health = rng.Next(30, 51);
		AttackPower = 10;
	}

	public void Attack(ICharacter target)
	{
		target.TakeDamage(AttackPower);
	}

	public void TakeDamage(int amount)
	{
		Health -= amount;
		if (Health < 0)
			Health = 0;
	}
}
