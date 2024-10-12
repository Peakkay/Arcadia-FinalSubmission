using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "ScriptableObjects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName = "Enemy";      // Enemy name
    public int maxHP = 50;                   // Maximum health for the enemy
    public int attackDamage = 10;            // Attack damage
    public bool isQuestEnemy;                 // Indicates if this enemy is part of a quest
}
