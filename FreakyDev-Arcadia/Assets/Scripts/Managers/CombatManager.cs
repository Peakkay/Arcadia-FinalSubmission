using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    private PlayerStats player;
    private List<EnemyStats> enemies;
    private int currentEnemyIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartCombat(PlayerStats player, List<EnemyStats> enemies)
    {
        this.player = player;
        this.enemies = enemies;
        currentEnemyIndex = 0;
        Debug.Log("Combat Started!");
        StartCoroutine(CombatLoop());
    }

    private IEnumerator CombatLoop()
    {
        while (player.CurrentHP > 0 && enemies.Count > 0)
        {
            yield return PlayerTurn();

            if (enemies.Count > 0)
            {
                yield return EnemyTurn();
            }
        }

        if (player.CurrentHP <= 0)
        {
            Debug.Log("You were defeated!");
        }
        else
        {
            Debug.Log("You defeated the enemies!");
        }
    }

    private IEnumerator PlayerTurn()
    {
        Debug.Log("Player's Turn! Choose an action: A to Attack, H to Heal");
        bool actionTaken = false;

        while (!actionTaken)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Attack();
                actionTaken = true;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                Heal(20); // Provide the healing amount, e.g., 20
                actionTaken = true;
            }
            yield return null; // Wait for player input
        }
    }

    public void Attack()
    {
        EnemyStats enemy = enemies[currentEnemyIndex];
        player.Attack(enemy);
        Debug.Log($"You attacked {enemy.enemyName}, dealing {player.attackDamage} damage!");

        if (enemy.CurrentHP <= 0)
        {
            Debug.Log($"{enemy.enemyName} was defeated!");
            enemies.RemoveAt(currentEnemyIndex);
        }
    }

    public void Heal(int amount)
    {
        player.Heal(amount);
        Debug.Log($"You healed for {amount} HP. Your current HP: {player.CurrentHP}");
    }

    private IEnumerator EnemyTurn()
    {
        EnemyStats enemy = enemies[currentEnemyIndex];
        yield return new WaitForSeconds(1f); // Simulate delay for enemy turn
        enemy.Attack(player);
        Debug.Log($"{enemy.enemyName} attacked you, dealing {enemy.attackDamage} damage!");

        if (player.CurrentHP <= 0)
        {
            Debug.Log("You were defeated by the enemy!");
        }
    }
}
