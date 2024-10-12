using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats enemyStats; // Reference to the enemy stats ScriptableObject
    public int currentHP;        // Current health
    public bool isQuestEnemy;     // Indicates if this enemy is part of a quest
    public int enemyID;

    private void Start()
    {
        currentHP = enemyStats.maxHP; // Set current HP to maximum
        EnemyManager.Instance.RegisterEnemy(this);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log($"{enemyStats.enemyName} defeated!");
            // Handle enemy death logic here (e.g., disabling the enemy)
            EnemyManager.Instance.UnregisterEnemy(this);
        }
        else
        {
            Debug.Log($"{enemyStats.enemyName} took {damage} damage. Current HP: {currentHP}");
        }
    }

    public void Attack(PlayerStats player)
    {
        player.TakeDamage(enemyStats.attackDamage);
        Debug.Log($"{enemyStats.enemyName} attacked {player.name} for {enemyStats.attackDamage} damage.");
    }

    public void MarkAsQuestEnemy(bool value)
    {
        isQuestEnemy = value;
    }
}
