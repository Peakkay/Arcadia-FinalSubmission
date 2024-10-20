using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : Singleton<NPCManager>
{
    public List<NPCController> npcList =new List<NPCController>();

    public void updateNPCList()
    {
        Debug.Log("Called");
        npcList.AddRange(FindObjectsOfType<NPCController>());
    }
    public NPCController GetNPCByID(int id)
    {
        foreach (var npc in npcList)
        {
            if (npc.NPCID == id)
            {
                return npc; // Return the NPC with the matching ID
            }
        }
        
        Debug.LogWarning($"NPC with ID {id} not found.");
        return null; // Return null if not found
    }
}
