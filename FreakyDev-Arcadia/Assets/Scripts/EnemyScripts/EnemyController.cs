using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            List<Enemy> enemiesInCombat = new List<Enemy> { enemy }; // Assuming 1 enemy for simplicity
            CombatManager.Instance.StartCombat(playerStats, enemiesInCombat);
        }
    }
}
