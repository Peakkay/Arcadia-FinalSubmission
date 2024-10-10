using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStats enemyStats;

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            List<EnemyStats> enemiesInCombat = new List<EnemyStats> { enemyStats }; // Assuming 1 enemy for simplicity
            CombatManager.Instance.StartCombat(playerStats, enemiesInCombat);
        }
    }
}
