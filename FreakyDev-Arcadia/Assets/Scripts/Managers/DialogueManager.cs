using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("UI Elements")]
    public GameObject dialoguePanel; // Panel for the dialogue UI
    public Text dialogueText;         // Text component for the dialogue text

    private Queue<string> dialogueQueue; // Queue to manage the dialogue lines
    private bool isDialogueActive;

    protected override void Awake()
    {
        base.Awake(); // Ensure the singleton setup is called
        dialogueQueue = new Queue<string>();
        dialoguePanel.SetActive(false); // Hide the panel initially
    }

    // Starts the dialogue using a Dialogue object
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueQueue.Clear();
        foreach (string line in dialogue.lines) // Ensure this accesses the lines correctly
        {
            dialogueQueue.Enqueue(line);
        }

        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    // Displays the next line of dialogue
    public void DisplayNextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueQueue.Dequeue(); // This should work if dialogue.lines is defined correctly
        dialogueText.text = line; // Update the text display
    }

    // Ends the dialogue session
    public void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false); // Hide the dialogue panel
    }

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space)) // Press Space to continue
        {
            DisplayNextLine();
        }
    }
}
