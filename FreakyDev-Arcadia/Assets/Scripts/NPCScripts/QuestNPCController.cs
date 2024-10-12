using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPCController : NPCController
{
    public Quest quest;  // Reference to the quest

    public override void Interact()
    {
        // Display dialogue for the NPC
        Debug.Log($"{npcName}: {dialogue}");

        // Ensure the QuestManager is available
        if (QuestManager.Instance != null)
        {
            // Check if the quest has already been completed
            if (quest.isCompleted)
            {
                Debug.Log($"Quest '{quest.questName}' has already been completed.");
                return;
            }

            // Handle Fetch Quests
            if (quest.questType == QuestType.Fetch)
            {
                // Check if the fetch quest can be completed
                if (QuestManager.Instance.CheckFetchQuestCompletion(quest))
                {
                    QuestManager.Instance.CompleteQuest();
                    Debug.Log($"Fetch Quest '{quest.questName}' completed.");
                }
                else if (QuestManager.Instance.currentQuest != quest)
                {
                    // Start the fetch quest if not already started
                    QuestManager.Instance.StartQuest(quest);
                    Debug.Log($"Fetch Quest '{quest.questName}' started.");
                }
                else
                {
                    // If fetch quest is already in progress, notify the player
                    Debug.Log($"Fetch Quest '{quest.questName}' is still in progress. Collect required items.");
                }
            }
            // Handle Combat Quests
            else if (quest.questType == QuestType.Combat)
            {
                // Start the combat quest if not already started
                if (QuestManager.Instance.currentQuest != quest)
                {
                    QuestManager.Instance.StartQuest(quest);
                    Debug.Log($"Combat Quest '{quest.questName}' started.");

                    // Mark all enemies in the quest as quest enemies
                    foreach (var enemy in quest.requiredEnemies)
                    {
                        enemy.MarkAsQuestEnemy(true);
                    }
                }
                else
                {
                    // If combat quest is already in progress, notify the player
                    Debug.Log($"Combat Quest '{quest.questName}' is already in progress.");
                }
            }
        }
    }
}
