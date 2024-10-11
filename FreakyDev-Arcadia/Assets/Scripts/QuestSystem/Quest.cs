using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public bool isCompleted = false;
    public QuestType questType;

    // For combat quests, list the enemies required to defeat
    public List<EnemyStats> requiredEnemies;
}

public enum QuestType
{
    Combat,
    Fetch,
    Dialogue
}

