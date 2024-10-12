using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public Quest currentQuest;
    public List<EnemyStats> defeatedEnemies = new List<EnemyStats>();

    public void StartQuest(Quest quest)
    {
        currentQuest = quest;
        defeatedEnemies.Clear(); // Clear any previously defeated enemies
        Debug.Log("Quest Started: " + currentQuest.questName);
    }

    public void CompleteQuest()
    {
        if (currentQuest != null && !currentQuest.isCompleted)
        {
            currentQuest.isCompleted = true;
            Debug.Log("Quest Completed: " + currentQuest.questName);
            // Additional logic for quest completion (e.g., rewards)
        }
    }

    public void RecordEnemyDefeated(EnemyStats enemy)
    {
        if (!defeatedEnemies.Contains(enemy))
        {
            defeatedEnemies.Add(enemy);
            Debug.Log($"{enemy.enemyName} recorded as defeated.");

            // Check if the combat quest is completed
            CheckQuestCompletion();
        }
    }

    public void CheckQuestCompletion()
    {
        if (currentQuest != null && currentQuest.questType == QuestType.Combat)
        {
            // Check if all required enemies are defeated
            foreach (var requiredEnemy in currentQuest.requiredEnemies)
            {
                if (!defeatedEnemies.Contains(requiredEnemy))
                {
                    return; // Exit if any required enemy is not defeated
                }
            }
            CompleteQuest(); // Complete the quest if all required enemies are defeated
        }
    }

    public bool CheckFetchQuestCompletion(Quest quest)
    {
        if (quest.questType == QuestType.Fetch)
        {
            foreach (QuestItem requiredItem in quest.requiredItems)
            {
                // Check if the player has enough of the required items
                if (!InventoryManager.Instance.HasItem(requiredItem.itemID, requiredItem.quantity))
                {
                    Debug.Log("Fetch Quest not completed yet. Missing items.");
                    return false; // Missing required items
                }
            }
            return true; // All required items collected
        }
        return false;
    }
}
