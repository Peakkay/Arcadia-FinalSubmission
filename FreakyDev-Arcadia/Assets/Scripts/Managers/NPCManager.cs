using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : Singleton<NPCManager>
{
    // Array or list to hold NPCs
    public NPCController[] npcs;

    private void Start()
    {
        // Initialize NPCs if needed
        foreach (var npc in npcs)
        {
            // Initialize each NPC here
            Debug.Log($"NPC Initialized: {npc.name}");
        }
    }

    public void InteractWithNPC(NPCController npc)
    {
        // Handle interaction logic
        npc.Interact();
    }
}


