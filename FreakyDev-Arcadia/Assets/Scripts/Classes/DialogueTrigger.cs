using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // Assign the dialogue for this trigger
    public int triggerID;
    public bool triggerOnSceneLoad = false; // Optional: Trigger on scene load
    public bool triggerAfterDialogue = false;
    public bool triggerAfterQuest = false;  // Optional: Trigger after a quest is complete
    public int requiredQuestID; // Optional: Quest required to trigger this dialogue
    public int requiredDialogueID;
    public bool hasTriggered = false; // Ensure dialogue only triggers once

    private void Start()
    {
        if (triggerOnSceneLoad && !hasTriggered)
        {
            TriggerDialogue();
        }
    }

    private void Update()
    {
        if (triggerAfterQuest && !hasTriggered)
        {
            if (QuestManager.Instance.IsQuestCompleted(requiredQuestID)) // Assuming QuestManager checks quests
            {
                TriggerDialogue();
            }
        }
        if(triggerAfterDialogue && !hasTriggered)
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(requiredDialogueID))
            {
                TriggerDialogue();
            }
        }
    }

    public void TriggerDialogue()
    {
        if (!hasTriggered)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            hasTriggered = true; // Prevent re-triggering the dialogue
        }
    }

}
