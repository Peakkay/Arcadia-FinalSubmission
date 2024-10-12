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

    // For fetch quests, list the items required to collect
    public List<QuestItem> requiredItems;
    public List<QuestItem> collectedItems = new List<QuestItem>(); // Track collected items
}

public enum QuestType
{
    Combat,
    Fetch,
    Dialogue
}


[System.Serializable]
public class QuestItem
{
    public Item item;  // The item required for the quest
    public int quantity;
    public int itemID => item.itemID;  // Use ItemID for comparison
}
