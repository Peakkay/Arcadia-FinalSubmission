using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public string npcName = "NPC Name"; // Name of the NPC
    public string dialogue = "Hello!";  // Dialogue text
    public int NPCID;

    // Base interaction logic for all NPCs
    public virtual void Interact()
    {
        // Initialize dialogue and display it using DialogueManager
        DisplayDialogue(dialogue);
    }

    // Method to display dialogue using the DialogueManager
    protected void DisplayDialogue(string text)
    {
        // Ensure the DialogueManager is available
        if (DialogueManager.Instance != null)
        {
            // Create a new dialogue object
            Dialogue dialogueObject = new Dialogue
            {
                lines = new List<string> { $"{npcName}: {text}" }
            };

            // Start the dialogue in the DialogueManager
            DialogueManager.Instance.StartDialogue(dialogueObject);
        }
        else
        {
            Debug.LogError("DialogueManager is not available.");
        }
    }
}
