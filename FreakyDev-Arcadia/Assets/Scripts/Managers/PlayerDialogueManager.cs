using UnityEngine;

public class PlayerDialogueManager : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        // Make sure the player has a DialogueTrigger component
        dialogueTrigger = GetComponent<DialogueTrigger>();
        if (dialogueTrigger == null)
        {
            dialogueTrigger = gameObject.AddComponent<DialogueTrigger>(); // Add if not already attached
        }
    }

    public void SetNewDialogue(Dialogue newDialogue)
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.dialogue = newDialogue; // Set the new dialogue
        }
    }

    public void TriggerCurrentDialogue()
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue(); // Start the dialogue
        }
    }
}
