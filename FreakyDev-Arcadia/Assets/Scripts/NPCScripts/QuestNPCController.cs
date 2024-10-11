using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPCController : NPCController
{
    public Quest quest;  // Reference to the quest

    public override void Interact()
    {
        // Display dialogue or perform an action when interacted with
        Debug.Log($"{npcName}: {dialogue}");

        // Start the quest when interacting
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.StartQuest(quest); // Start the quest using the QuestManager
            Debug.Log($"Quest '{quest.questName}' started.");

            foreach (var enemy in quest.requiredEnemies)
            {
                enemy.MarkAsQuestEnemy(true);
            }            
        }
    }
}
