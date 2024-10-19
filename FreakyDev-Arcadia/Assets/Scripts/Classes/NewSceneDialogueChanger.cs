using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSceneDialogueChanger : MonoBehaviour
{
    public GameObject player;
    public DialogueTrigger dialogueTrigger;
    public void Update()
    {
        if(gameObject.GetComponent<Transporter>().sceneChange)
        {
            ChangeDialogue();
        }
    }
    public void ChangeDialogue()
    {
        player.GetComponent<DialogueTrigger>().dialogue =dialogueTrigger.dialogue;
        player.GetComponent<DialogueTrigger>().triggerID = dialogueTrigger.triggerID;
        player.GetComponent<DialogueTrigger>().triggerOnSceneLoad = dialogueTrigger.triggerOnSceneLoad;
        player.GetComponent<DialogueTrigger>().triggerAfterDialogue = dialogueTrigger.triggerAfterDialogue;
        player.GetComponent<DialogueTrigger>().triggerAfterQuest = dialogueTrigger.triggerAfterQuest;
        player.GetComponent<DialogueTrigger>().requiredQuestID = dialogueTrigger.requiredQuestID;
        player.GetComponent<DialogueTrigger>().requiredDialogueID = dialogueTrigger.requiredDialogueID;
        player.GetComponent<DialogueTrigger>().hasTriggered = dialogueTrigger.hasTriggered;
    }
}
