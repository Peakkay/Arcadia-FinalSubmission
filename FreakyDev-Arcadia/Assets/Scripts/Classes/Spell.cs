using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    public int spellID; // Unique identifier for the spell
    public string spellName; // Name of the spell
    public string spellType; // Type of spell (e.g., offensive, defensive)
    public int damage;
    public int manaCost; // Mana cost to cast the spell
    public float cooldown; // Cooldown time for the spell
    // Add additional properties as needed, such as damage, area of effect, etc.

    public void CastSpell(Enemy targetEnemy)
    {
        if (targetEnemy != null)
        {
            // Assuming you deduct mana from the player here if they are referenced
            PlayerStats playerStats = FindObjectOfType<PlayerStats>(); // Get player stats (or pass player reference)
            if (playerStats != null && playerStats.CurrentMana >= manaCost)
            {
                playerStats.CurrentMana -= manaCost; // Deduct mana cost
                targetEnemy.TakeDamage(damage); // Apply damage to the enemy
                Debug.Log($"{spellName} cast on {targetEnemy.enemyStats.enemyName} for {damage} damage!");
            }
            else
            {
                Debug.LogWarning("Not enough mana to cast the spell!");
            }
        }
    }
}

