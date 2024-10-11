using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public string npcName = "NPC Name"; // Name of the NPC
    public string dialogue = "Hello! Prepare to fight!"; // Dialogue text for combat initiation

    public List<EnemyStats> enemies; // List of enemies linked to this NPC

    public void Interact()
    {
        // Display dialogue or perform an action when interacted with
        Debug.Log($"{npcName}: {dialogue}");

        // Start combat when interacting
        if (CombatManager.Instance != null)
        {
            Debug.Log("Tried Combat");
            PlayerStats player = FindObjectOfType<PlayerStats>();
            CombatManager.Instance.StartCombat(player, enemies);
        }
    }
}
