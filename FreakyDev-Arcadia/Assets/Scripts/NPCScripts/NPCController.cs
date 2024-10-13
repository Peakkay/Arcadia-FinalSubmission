
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public string npcName = "NPC Name";
    public string dialogue = "Hello!";
    public int NPCID;

    public Faction npcFaction; // New field for NPC's faction
    public int corruptionLevel; // New field to track NPC's corruption level (0-100)
    public bool isKeyNPC; // Flag to identify major NPCs
    public List<Choice> npcChoices;

    // Base interaction logic for all NPCs
    public virtual void Interact()
    {   DisplayDialogue(dialogue);
        Debug.Log($"{npcName}: {dialogue}");
        UpdateChoices();
        ChoiceManager.Instance.StartChoiceSelection();
    }
     protected void DisplayDialogue(string text)
    {
        // Ensure the DialogueManager is available
        if (DialogueManager.Instance != null)
        {
            // Create a new dialogue object
            Dialogue dialogueObject = new Dialogue
            {
                lines = new List<string>{ $"{npcName}: {text}" }
            };

            // Start the dialogue in the DialogueManager
            DialogueManager.Instance.StartDialogue(dialogueObject);
        }
        else
        {
            Debug.LogError("DialogueManager is not available.");
        }
    }
    // Method to increase corruption level
    public void CorruptNPC(int corruptionAmount)
    {
        corruptionLevel += corruptionAmount;
        if (corruptionLevel > 100) corruptionLevel = 100;
        Debug.Log($"{npcName} corruption level: {corruptionLevel}");
    }
    private void UpdateChoices()
    {
        ChoiceManager.Instance.ClearChoices(); // Clear existing choices
        ChoiceManager.Instance.AddChoices(npcChoices); // Add this NPC's choices

        // Optionally, display the choices using your UI system here
    }
}
