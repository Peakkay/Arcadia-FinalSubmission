using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public Quest currentQuest;
    public List<int> defeatedEnemies = new List<int>();

    public void StartQuest(Quest quest)
    {
        currentQuest = quest;
        defeatedEnemies.Clear(); // Clear any previously defeated enemies
        currentQuest.currentDialogueIndex = 0; // Reset dialogue index when starting a quest
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

    public void RecordEnemyDefeated(Enemy enemy)
    {
        if (currentQuest != null && currentQuest.requiredEnemies.Contains(enemy.enemyID))
        {
            if (!defeatedEnemies.Contains(enemy.enemyID))
            {
                defeatedEnemies.Add(enemy.enemyID);
                Debug.Log($"Recorded defeated enemy: {enemy.GetComponent<Enemy>().enemyStats.enemyName}");
            }
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
        public bool CheckDialogueQuestCompletion(Quest quest)
    {
        // Check if the current dialogue index has reached the total number of dialogue lines
        return quest.currentDialogueIndex >= quest.dialogueMap.Count;
    }
}
