using UnityEngine;
using System.Collections.Generic;

public class TestCombatTrigger : MonoBehaviour
{
    public PlayerStats player;
    public List<EnemyStats> enemies;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Press 'C' to start combat
        {
            if (CombatManager.Instance != null)
            {
                CombatManager.Instance.StartCombat(player, enemies);
            }
        }
    }
}
