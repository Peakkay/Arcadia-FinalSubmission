using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public Stat playerstats;
    private void Start()
    {
        playerstats = new Stat();
        playerstats.maxHP = 100;
        playerstats.maxMana = 100;
        playerstats.attackDamage = 20;
        playerstats.CurrentHP = playerstats.maxHP; // Set health to maximum at the start
        playerstats.CurrentMana = playerstats.maxMana; // Initialize current mana
    }

    // Method for the player to attack the enemy
    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(playerstats.attackDamage);
    }

    // Method to heal the player
    public void Heal(int amount)
    {
        playerstats.CurrentHP = Mathf.Min(playerstats.CurrentHP + amount, playerstats.maxHP);
        Debug.Log($"Player healed for {amount}. Current HP: {playerstats.CurrentHP}");
    }

    // Method to take damage from enemies
    public void TakeDamage(int damage)
    {
        playerstats.CurrentHP -= damage;
        if (playerstats.CurrentHP <= 0)
        {
            playerstats.CurrentHP = 0;
            Debug.Log("Player defeated!");
            // Handle player death logic here
        }
        else
        {
            Debug.Log($"Player took {damage} damage. Current HP: {playerstats.CurrentHP}");
        }
    }

    public void ApplyItemBonus(Item item)
    {
        playerstats.AddStat(item.stats);
    }

    // Remove item bonuses
    public void RemoveItemBonus(Item item)
    {
        playerstats.RemoveStat(item.stats);
    }

    // Debug method to check current stats
    public void PrintStats()
    {
        Debug.Log($"");
    }
}
