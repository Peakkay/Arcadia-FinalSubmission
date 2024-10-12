using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHP = 100;              // Maximum health
    public int CurrentHP { get; private set; } // Current health
    public int attackDamage = 20;        // Attack damage
    public int maxMana = 100;            // Maximum mana
    public int CurrentMana { get;set; } // Current mana

    private void Start()
    {
        CurrentHP = maxHP; // Set health to maximum at the start
        CurrentMana = maxMana; // Initialize current mana
    }

    // Method for the player to attack the enemy
    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(attackDamage);
    }

    // Method to heal the player
    public void Heal(int amount)
    {
        CurrentHP = Mathf.Min(CurrentHP + amount, maxHP);
        Debug.Log($"Player healed for {amount}. Current HP: {CurrentHP}");
    }

    // Method to take damage from enemies
    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            Debug.Log("Player defeated!");
            // Handle player death logic here
        }
        else
        {
            Debug.Log($"Player took {damage} damage. Current HP: {CurrentHP}");
        }
    }

}
