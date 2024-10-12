using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPCController : NPCController
{
    public Quest quest;  // Reference to the quest

public override void Interact()
    {
        // Initialize the dialogue map if it's not already initialized
        if (quest.dialogueMap == null || quest.dialogueMap.Count == 0)
        {
            quest.InitializeDialogueMap();
        }
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

            // If the quest is already in progress
            if (QuestManager.Instance.currentQuest == quest)
            {
                Debug.Log($"Quest '{quest.questName}' is already in progress.");

                // Check if it's a Fetch quest and if it can be completed
                if (quest.questType == QuestType.Fetch)
                {
                    if (QuestManager.Instance.CheckFetchQuestCompletion(quest))
                    {
                        QuestManager.Instance.CompleteQuest();
                        Debug.Log($"Fetch Quest '{quest.questName}' completed.");
                    }
                    else
                    {
                        // Display the next dialogue line if the quest is a dialogue quest
                        if (quest.questType == QuestType.Dialogue)
                        {
                            // Verify this NPC has dialogue mapped
                            if (quest.dialogueMap.ContainsKey(this.NPCID))
                            {
                                DisplayNextDialogue();
                            }
                            else
                            {
                                Debug.Log($"{npcName} does not have any dialogue for this quest.");
                            }
                        }
                    }
                }
                else if (quest.questType == QuestType.Combat)
                {
                    // Check if the combat quest can be completed
                    QuestManager.Instance.CheckQuestCompletion();
                }
                return; // Exit after handling the already in-progress quest
            }

            // Handle Fetch Quests
            if (quest.questType == QuestType.Fetch)
            {
                // Start the fetch quest if not already started
                QuestManager.Instance.StartQuest(quest);
                Debug.Log($"Fetch Quest '{quest.questName}' started.");
            }
            // Handle Combat Quests
            else if (quest.questType == QuestType.Combat)
            {
                // Start the combat quest
                QuestManager.Instance.StartQuest(quest);
                Debug.Log($"Combat Quest '{quest.questName}' started.");

                // Mark all enemies in the quest as quest enemies
                foreach (var enemy in quest.requiredEnemies)
                {
                    EnemyManager.Instance.FindEnemyByID(enemy).MarkAsQuestEnemy(true);
                }
            }
            // Handle Dialogue Quests
            else if (quest.questType == QuestType.Dialogue)
            {
                // Trigger dialogue for the quest
                StartDialogue();
            }
        }
    }

    private void StartDialogue()
    {
        List<string> npcDialogue = quest.dialogueMap[this.NPCID];
        if (quest.currentDialogueIndex < npcDialogue.Count)
        {
            Debug.Log($"Starting dialogue for quest '{quest.questName}': {npcDialogue[quest.currentDialogueIndex]}");
        }
        else
        {
            Debug.Log("No dialogue lines available.");
        }
    }

    private void DisplayNextDialogue()
    {
        // Fetch the list of dialogue lines for this NPC
        List<string> npcDialogue = quest.dialogueMap[this.NPCID];

        // Check if there are more dialogue lines to display
        if (quest.currentDialogueIndex < npcDialogue.Count)
        {
            // Display the current dialogue line
            Debug.Log($"{npcName}: {npcDialogue[quest.currentDialogueIndex]}");

            // Increment the dialogue index
            quest.currentDialogueIndex++;

            // Check for quest completion after the last dialogue line
            if (quest.currentDialogueIndex >= quest.dialogues.Count)
            {
                Debug.Log($"Dialogue for quest '{quest.questName}' completed.");
                QuestManager.Instance.CompleteQuest();
            }
        }
        else
        {
            Debug.Log("No more dialogue lines.");
        }
    }
}
