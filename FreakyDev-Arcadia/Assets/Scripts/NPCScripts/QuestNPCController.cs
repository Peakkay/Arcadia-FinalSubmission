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
        
        // Ensure the DialogueManager is available
        if (DialogueManager.Instance != null)
        {
            // Start dialogue for the NPC
            Dialogue dialoguetext = new Dialogue { lines = new List<string> { $"{npcName}: {dialogue}" } };
            DialogueManager.Instance.StartDialogue(dialoguetext);
        }


        // Ensure the QuestManager is available
        if (QuestManager.Instance != null)
        {
            // Check if the quest has already been completed
            if (quest.isCompleted)
            {
                Debug.Log($"Quest '{quest.questName}' has already been completed.");
                return;
            }

            // Check if the quest is already in progress
            if (QuestManager.Instance.activeQuests.Contains(quest))
            {
                Debug.Log($"Quest '{quest.questName}' is already in progress.");

                // Check if it's a Dialogue quest and progress dialogue
                if (quest.questType == QuestType.Dialogue)
                {
                    if (quest.dialogueMap.ContainsKey(NPCID))
                    {
                        DisplayNextDialogue();
                    }
                    else
                    {
                        Debug.Log($"{npcName} does not have any dialogue for this quest.");
                    }
                }

                // Handle fetch quest completion
                if (quest.questType == QuestType.Fetch)
                {
                    if (QuestManager.Instance.CheckFetchQuestCompletion(quest))
                    {
                        QuestManager.Instance.CompleteQuest(quest); // Pass the quest
                        Debug.Log($"Fetch Quest '{quest.questName}' completed.");
                    }
                }

                // Handle combat quest completion
                if (quest.questType == QuestType.Combat)
                {
                    QuestManager.Instance.CheckQuestCompletion(quest); // Pass the quest
                }

                return; // Exit after handling the already in-progress quest
            }

            // Handle quest start for different quest types
            if (quest.questType == QuestType.Fetch || quest.questType == QuestType.Combat || quest.questType == QuestType.Dialogue)
            {
                QuestManager.Instance.StartQuest(quest);
                Debug.Log($"Quest '{quest.questName}' started.");

                if (quest.questType == QuestType.Dialogue)
                {
                    // Trigger the first dialogue
                    StartDialogue();
                }
            }
        }
    }

    private void StartDialogue()
    {
        // Check if the NPC has dialogue mapped
        if (quest.dialogueMap.TryGetValue(NPCID, out var npcDialogue))
        {
            if (quest.currentDialogueIndex < npcDialogue.Count)
            {
                Debug.Log($"Starting dialogue for quest '{quest.questName}': {npcDialogue[quest.currentDialogueIndex]}");
                 // Create a new dialogue object to pass to the DialogueManager
                Dialogue dialogue = new Dialogue { lines = new List<string> { $"{npcName}: {npcDialogue[quest.currentDialogueIndex]}" } };
                DialogueManager.Instance.StartDialogue(dialogue);
            }
            else
            {
                Debug.Log("No dialogue lines available.");
            }
        }
        else
        {
            Debug.Log($"No dialogue found for NPC with ID: {NPCID}");
        }
    }

    private void DisplayNextDialogue()
    {
        // Fetch the dialogue for this NPC
        if (quest.dialogueMap.TryGetValue(NPCID, out var npcDialogue))
        {
            // Check if there are more dialogue lines to display
            if (quest.currentDialogueIndex < npcDialogue.Count)
            {   Dialogue dialogue = new Dialogue { lines = new List<string> { $"{npcName}: {npcDialogue[quest.currentDialogueIndex]}" } };
                DialogueManager.Instance.StartDialogue(dialogue);
                // Display the current dialogue line
                Debug.Log($"{npcName}: {npcDialogue[quest.currentDialogueIndex]}");

                // Increment the dialogue index
                quest.currentDialogueIndex++;

                // Check if the dialogue is complete
                if (quest.currentDialogueIndex >= npcDialogue.Count)
                {
                    Debug.Log($"Dialogue for quest '{quest.questName}' completed.");
                    QuestManager.Instance.CompleteQuest(quest); // Pass the quest
                }
            }
            else
            {
                Debug.Log("No more dialogue lines.");
            }
        }
        else
        {
            Debug.Log($"No dialogue found for NPC with ID: {NPCID}");
        }
    }
}
