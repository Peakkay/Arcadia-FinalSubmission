using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    public PlayerStats player; // Reference to the player
    public List<EnemyStats> enemies; // List of enemies involved in combat

    private bool playerTurn = true; // Boolean to check if it's player's turn
    private bool combatActive = false; // Track if combat is active
    private List<EnemyStats> defeatedEnemies = new List<EnemyStats>(); // Track defeated enemies for quest system

    public void StartCombat(PlayerStats player, List<EnemyStats> enemies)
    {
        this.player = player;
        this.enemies = enemies;
        combatActive = true; // Combat is now active

        player.GetComponent<PlayerMovement>().canMove = false; // Disable movement during combat
        Debug.Log("Combat started with player and enemies.");

        StartCoroutine(CombatLoop());
    }

    private IEnumerator CombatLoop()
    {
        // Continue the combat until player or all enemies are defeated
        while (player.CurrentHP > 0 && enemies.Count > 0)
        {
            if (playerTurn)
            {
                Debug.Log("Player's Turn.");
                bool actionSelected = false;

                // Wait for player to select an action (attack or heal)
                while (!actionSelected)
                {
                    if (Input.GetKeyDown(KeyCode.A)) // A for attack
                    {
                        PlayerAction("attack");
                        actionSelected = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.H)) // H for heal
                    {
                        PlayerAction("heal");
                        actionSelected = true;
                    }

                    yield return null; // Wait for the next frame
                }

                yield return new WaitUntil(() => !playerTurn); // Wait until player finishes action
            }
            else
            {
                Debug.Log("Enemy's Turn.");
                EnemyAction();
                yield return new WaitForSeconds(2f); // Small delay for enemy action
            }
        }

        // Check combat outcome
        if (player.CurrentHP <= 0)
        {
            Debug.Log("Player has been defeated.");
        }
        else if (enemies.Count == 0)
        {
            Debug.Log("All enemies defeated. Combat won.");
        }

        EndCombat();
    }

    public void PlayerAction(string action)
    {
        // Attack or heal based on the action passed in
        if (action == "attack")
        {
            Debug.Log("Player chose to attack.");
            AttackEnemy();  // Call attack logic
        }
        else if (action == "heal")
        {
            Debug.Log("Player chose to heal.");
            player.Heal(20); // Heal player by 20 HP (or any amount you choose)
        }

        // Once the action is complete, set it to the enemy's turn
        playerTurn = false;
    }

private void AttackEnemy()
{
    if (enemies.Count > 0)
    {
        EnemyStats currentEnemy = enemies[0]; // Attack the first enemy in the list
        player.Attack(currentEnemy);

        Debug.Log($"Player attacked {currentEnemy.enemyName}. {currentEnemy.enemyName} now has {currentEnemy.CurrentHP} HP.");

        // Check if the enemy is defeated
        if (currentEnemy.CurrentHP <= 0)
        {
            Debug.Log($"{currentEnemy.enemyName} has been defeated.");
            
            // Check if this enemy is part of the quest
            if (currentEnemy.isQuestEnemy)
            {
                // Mark the enemy as defeated for quest tracking
                QuestManager.Instance.RecordEnemyDefeated(currentEnemy);
            }
            
            enemies.RemoveAt(0); // Remove the defeated enemy
        }

        playerTurn = false; // End player's turn
    }
}

    private void EnemyAction()
    {
        if (enemies.Count > 0)
        {
            EnemyStats currentEnemy = enemies[0]; // Attack the first enemy in the list
            currentEnemy.Attack(player);

            Debug.Log($"{currentEnemy.enemyName} attacked the player. Player now has {player.CurrentHP} HP.");

            // Check if player is defeated
            if (player.CurrentHP <= 0)
            {
                Debug.Log("Player defeated.");
            }
            else
            {
                playerTurn = true; // End enemy's turn, start player's turn
            }
        }
    }

    public void EndCombat()
    {
        Debug.Log("Combat ended.");
        combatActive = false; // Combat is no longer active
        player.GetComponent<PlayerMovement>().canMove = true; // Re-enable movement after combat

        // Check if there is an active quest and update quest progress
        if (QuestManager.Instance != null && QuestManager.Instance.currentQuest != null)
        {
            QuestManager.Instance.CheckQuestCompletion(); // Notify QuestManager of defeated enemies
        }

        player = null;
        enemies.Clear();
        defeatedEnemies.Clear();
    }

    public bool IsCombatActive()
    {
        return combatActive;
    }
}
