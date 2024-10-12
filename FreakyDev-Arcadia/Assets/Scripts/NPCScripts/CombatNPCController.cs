using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatNPCController : NPCController
{
    public List<Enemy> enemies; // List of enemies linked to this NPC

    public override void Interact()
    {
        base.Interact(); // Call base class interaction logic (dialogue)
        Debug.Log($"{npcName}: Prepare for combat!");

        // Start combat when interacting
        if (CombatManager.Instance != null)
        {
            PlayerStats player = FindObjectOfType<PlayerStats>();
            CombatManager.Instance.StartCombat(player, enemies);
        }
    }
}
