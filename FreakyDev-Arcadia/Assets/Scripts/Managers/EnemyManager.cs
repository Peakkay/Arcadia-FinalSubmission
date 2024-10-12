using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    // Dictionary to store enemies with their enemyID as the key
    private Dictionary<int, Enemy> enemyDictionary = new Dictionary<int, Enemy>();

    // Register an enemy to the dictionary
    public void RegisterEnemy(Enemy enemy)
    {
        if (!enemyDictionary.ContainsKey(enemy.enemyID))
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
            Debug.Log($"Enemy with ID {enemy.enemyID} registered.");
        }
    }

    // Remove an enemy from the dictionary (e.g., when defeated)
    public void UnregisterEnemy(Enemy enemy)
    {
        if (enemyDictionary.ContainsKey(enemy.enemyID))
        {
            enemyDictionary.Remove(enemy.enemyID);
            Debug.Log($"Enemy with ID {enemy.enemyID} unregistered.");
        }
    }

    // Find an enemy by its ID
    public Enemy FindEnemyByID(int enemyID)
    {
        if (enemyDictionary.TryGetValue(enemyID, out Enemy enemy))
        {
            return enemy;
        }
        else
        {
            Debug.LogWarning($"Enemy with ID {enemyID} not found.");
            return null;
        }
    }
}
