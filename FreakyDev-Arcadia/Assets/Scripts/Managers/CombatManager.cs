using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    public PlayerStats player; // Reference to the player
    public List<Enemy> enemies; // List of enemies involved in combat

    private bool playerTurn = true; // Boolean to check if it's player's turn
    private bool combatActive = false; // Track if combat is active

    public void StartCombat(PlayerStats player, List<Enemy> enemies)
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

                // Wait for player to select an action (attack, heal, or cast spell)
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
                    else if (Input.GetKeyDown(KeyCode.C)) // C for casting spell
                    {
                        PlayerAction("castSpell");
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
        // Ensure combat is active before performing actions
        if (!combatActive) return;

        // Attack, heal, or cast spell based on the action passed in
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
        else if (action == "castSpell")
        {
            Debug.Log("Player chose to cast a spell.");
            // For this example, we will cast a spell called "Fireball"
            int spellID = 1; // Example spell ID, you can change it based on player choice
            AttackWithSpell(spellID);
        }

        // Once the action is complete, set it to the enemy's turn
        playerTurn = false;
    }

    private void AttackEnemy()
    {
        if (enemies.Count > 0)
        {
            Enemy currentEnemy = enemies[0]; // Attack the first enemy in the list
            player.Attack(currentEnemy);

            Debug.Log($"Player attacked {currentEnemy.enemyStats.enemyName}. {currentEnemy.enemyStats.enemyName} now has {currentEnemy.currentHP} HP.");

            // Check if the enemy is defeated
            if (currentEnemy.currentHP <= 0)
            {
                Debug.Log($"{currentEnemy.enemyStats.enemyName} has been defeated.");

                // Check if this enemy is part of any active quests
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
    private void AttackWithSpell(int spellID)
    {
        if (enemies.Count > 0)
        {
            Enemy currentEnemy = enemies[0]; // Attack the first enemy in the list
            SpellManager.Instance.CastSpell(spellID, currentEnemy); // Use SpellManager to cast spell

            Debug.Log($"Player attacked {currentEnemy.enemyStats.enemyName}. {currentEnemy.enemyStats.enemyName} now has {currentEnemy.currentHP} HP.");

            // Check if the enemy is defeated
            if (currentEnemy.currentHP <= 0)
            {
                Debug.Log($"{currentEnemy.enemyStats.enemyName} has been defeated.");

                // Check if this enemy is part of any active quests
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
            Enemy currentEnemy = enemies[0]; // Attack the first enemy in the list
            currentEnemy.Attack(player);

            Debug.Log($"{currentEnemy.enemyStats.enemyName} attacked the player. Player now has {player.CurrentHP} HP.");

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
        combatActive = false;
        player.GetComponent<PlayerMovement>().canMove = true;

        foreach (Quest activeQuest in QuestManager.Instance.activeQuests)
        {
            if (activeQuest.questType == QuestType.Combat)
            {
                QuestManager.Instance.CheckQuestCompletion(activeQuest);
            }
        }

        player = null;
        enemies.Clear();
    }

    public bool IsCombatActive()
    {
        return combatActive;
    }
}
