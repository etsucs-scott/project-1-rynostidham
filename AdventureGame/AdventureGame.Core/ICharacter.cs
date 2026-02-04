using System;

public interface ICharacter
{
    int Health { get; }
    void Attack(ICharacter target);
    void TakeDamage(int amount);
}
