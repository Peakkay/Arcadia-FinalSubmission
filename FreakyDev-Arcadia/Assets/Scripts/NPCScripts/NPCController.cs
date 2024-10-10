using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public string npcName = "NPC Name"; // Name of the NPC
    public string dialogue = "Hello! How can I help you?"; // Dialogue text

    public void Interact()
    {
        // Display dialogue or perform an action when interacted with
        Debug.Log($"{npcName}: {dialogue}");
        // You can replace this with your own dialogue system
    }
}

