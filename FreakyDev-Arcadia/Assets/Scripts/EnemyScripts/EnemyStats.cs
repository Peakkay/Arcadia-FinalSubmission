using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string enemyName = "Enemy";  // Enemy name
    public int maxHP = 50;              // Maximum health for the enemy
    public int CurrentHP { get; private set; } // Current health
    public int attackDamage = 10;       // Attack damage

    private void Start()
    {
        CurrentHP = maxHP; // Set health to maximum at the start
    }

    // Method for the enemy to attack the player
    public void Attack(PlayerStats player)
    {
        player.TakeDamage(attackDamage);
    }

    // Method for the enemy to take damage from the player
    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            Debug.Log($"{enemyName} defeated!");
            // Handle enemy death logic here
        }
        else
        {
            Debug.Log($"{enemyName} took {damage} damage. Current HP: {CurrentHP}");
        }
    }
}
