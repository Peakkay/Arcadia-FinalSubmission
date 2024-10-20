using System.Data;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;


public class PlayerStats : MonoBehaviour
{

    public Stat playerstats;
    public int baseAttackDamage;
    public int baseHealth;

    private void Start()
    {
        playerstats = new Stat();
        playerstats.maxHP = 100;
        playerstats.maxMana = 100;
        playerstats.attackDamage = 20;
        playerstats.CurrentHP = playerstats.maxHP; // Set health to maximum at the start
        playerstats.CurrentMana = playerstats.maxMana; // Initialize current mana
        StartCoroutine(PassiveRegen());
    }

    private IEnumerator PassiveRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Regenerate every second

            // Health regeneration
            if (playerstats.CurrentHP < playerstats.maxHP)
            {
                playerstats.CurrentHP += Mathf.RoundToInt(playerstats.healthRegenRate);
                playerstats.CurrentHP = Mathf.Min(playerstats.CurrentHP, playerstats.maxHP);
            }
            // Mana regeneration
            if (playerstats.CurrentMana < playerstats.maxMana)
            {
                playerstats.CurrentMana += Mathf.RoundToInt(playerstats.manaRegenRate);
                playerstats.CurrentMana = Mathf.Min(playerstats.CurrentMana, playerstats.maxMana);
                Debug.Log("Mana regenerated: " + playerstats.CurrentMana);
            }
        }
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
    public void RestoreFullHealthAndMana()
    {
        playerstats.CurrentHP = playerstats.maxHP;
        playerstats.CurrentMana = playerstats.maxMana;
    }
    public void UpdateStatsBasedOnCorruption()
    {
        int corruption = gameObject.GetComponent<PlayerController>().playerCorruptionLevel + RealityManager.Instance.worldCorruption;
        // Increase attack damage with corruption (e.g., 1% increase in attack per corruption point)
        playerstats.attackDamage = baseAttackDamage + corruption / 100 * baseAttackDamage;

        // Decrease max health with corruption (e.g., lose 1% max health per corruption point)
        playerstats.maxHP = baseHealth - corruption / 100 * baseHealth;

        // Ensure current health doesn't exceed max health after update
        if (playerstats.CurrentHP > playerstats.maxHP)
        {
            playerstats.CurrentHP = playerstats.maxHP;
        }
    }
}
