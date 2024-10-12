using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    void Start()
    {
        // Example dialogue lines to test
        Dialogue dialogue= new Dialogue();
        dialogue.lines = new string[] { "Hello, traveler!"
            , "Welcome to our village."
            , "How can I assist you today?" };

        // Start the dialogue when the scene begins
        dialogueManager.StartDialogue(dialogue);
    }
}
