using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public string npcName = "NPC Name"; // Name of the NPC
    public string dialogue = "Hello!";  // Dialogue text

    // Base interaction logic for all NPCs
    public virtual void Interact()
    {
        Debug.Log($"{npcName}: {dialogue}");
    }
}
