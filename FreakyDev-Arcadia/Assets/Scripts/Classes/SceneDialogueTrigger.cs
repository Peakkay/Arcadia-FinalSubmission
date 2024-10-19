using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDialogueTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        // Automatically trigger dialogue when the scene starts
        dialogueTrigger.TriggerDialogue();
    }
}
