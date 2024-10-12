using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public List<Quest> activeQuests = new List<Quest>(); // List to hold active quests
    public List<int> defeatedEnemies = new List<int>(); // Track defeated enemies

    // Start a new quest
    public void StartQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            defeatedEnemies.Clear(); // Clear any previously defeated enemies for the new quest
            quest.currentDialogueIndex = 0; // Reset dialogue index when starting a quest
            Debug.Log("Quest Started: " + quest.questName);
        }
        else
        {
            Debug.LogWarning("Quest already active: " + quest.questName);
        }
    }

    // Complete a specific quest
    public void CompleteQuest(Quest quest)
    {
        if (quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            activeQuests.Remove(quest); // Remove the quest from active quests
            Debug.Log("Quest Completed: " + quest.questName);
            // Additional logic for quest completion (e.g., rewards)
        }
    }

    // Record an enemy as defeated
    public void RecordEnemyDefeated(Enemy enemy)
    {
        foreach (var quest in activeQuests) // Check against all active quests
        {
            if (quest.requiredEnemies.Contains(enemy.enemyID) && !defeatedEnemies.Contains(enemy.enemyID))
            {
                defeatedEnemies.Add(enemy.enemyID);
                Debug.Log($"Recorded defeated enemy: {enemy.GetComponent<Enemy>().enemyStats.enemyName}");
                CheckQuestCompletion(quest); // Check if this quest is complete after recording
            }
        }
    }

    // Check if all enemies required for the quest have been defeated
    public void CheckQuestCompletion(Quest quest)
    {
        if (quest.questType == QuestType.Combat)
        {
            // Check if all required enemies are defeated
            foreach (var requiredEnemy in quest.requiredEnemies)
            {
                if (!defeatedEnemies.Contains(requiredEnemy))
                {
                    return; // Exit if any required enemy is not defeated
                }
            }
            CompleteQuest(quest); // Complete the quest if all required enemies are defeated
        }
    }

    // Check fetch quest completion
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

    // Check dialogue quest completion
    public bool CheckDialogueQuestCompletion(Quest quest)
    {
        // Check if the current dialogue index has reached the total number of dialogue lines
        return quest.currentDialogueIndex >= quest.dialogueMap.Count;
    }

    // Call this to update quests each frame or based on player actions
    public void UpdateActiveQuests()
    {
        foreach (var quest in activeQuests)
        {
            if (quest.questType == QuestType.Fetch && CheckFetchQuestCompletion(quest))
            {
                CompleteQuest(quest);
            }

            if (quest.questType == QuestType.Dialogue && CheckDialogueQuestCompletion(quest))
            {
                CompleteQuest(quest);
            }
        }
    }
}
