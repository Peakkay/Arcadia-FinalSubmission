using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDialogueManager : MonoBehaviour
{
    public PlayerDialogueManager playerDialogueManager;

    // Store dialogues for different scenes
    public Dialogue scene1Dialogue;
    public Dialogue scene2Dialogue;
    public Dialogue defaultDialogue;

    private void Start()
    {
        // Ensure we find the PlayerDialogueManager in the scene
        if (playerDialogueManager == null)
        {
            playerDialogueManager = FindObjectOfType<PlayerDialogueManager>();
        }

        // Add listener for scene load event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Choose the correct dialogue based on the scene
        Dialogue newDialogue = GetSceneDialogue(scene.name);
        playerDialogueManager.SetNewDialogue(newDialogue);
    }

    private Dialogue GetSceneDialogue(string sceneName)
    {
        // Choose dialogue based on scene name
        switch (sceneName)
        {
            case "OrdinaryLife":
                return scene1Dialogue;
            case "AwakeningOfPower":
                return scene2Dialogue;
            default:
                return defaultDialogue; // Default dialogue if no match
        }
    }

    private void OnDestroy()
    {
        // Remove the listener when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
