using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public string description;
    public bool isCompleted = false;
    public QuestType questType;

    // For combat quests, list the enemies required to defeat
    public List<int> requiredEnemies;

    // For fetch quests, list the items required to collect
    public List<QuestItem> requiredItems;
    public List<QuestItem> collectedItems = new List<QuestItem>(); // Track collected items

    // For dialogue quests
    public Dictionary<int, List<string>> dialogueMap; // Map of NPC to dialogue lines
    public List<int> nPCID; // List of NPC IDs
    public List<string> dialogues; // List of dialogues for each NPC
    public int currentDialogueIndex = 0; // Track the current dialogue line index

    // List of objectives
    public List<QuestObjective> objectives; // List of objectives for the quest
    public QuestReward questReward; // The reward for completing this quest

    public void InitializeDialogueMap()
    {
        dialogueMap = new Dictionary<int, List<string>>();

        for (int i = 0; i < nPCID.Count; i++)
        {
            if (i < dialogues.Count)
            {
                // Create a new list for each NPC's dialogues
                dialogueMap[nPCID[i]] = new List<string> { dialogues[i] };
            }
        }
    }

    // Check if all objectives are completed
    public bool AreAllObjectivesCompleted()
    {
        foreach (var objective in objectives)
        {
            if (!objective.IsComplete()) return false;
        }
        return true; // All objectives are completed
    }
}

public enum QuestType
{
    Combat,
    Fetch,
    Dialogue
}

// Create an abstract base class for objectives
public abstract class QuestObjective
{
    public string Description { get; set; }
    public abstract bool IsComplete(); // Check if this objective is complete
}

// Example of a Combat Objective
public class CombatObjective : QuestObjective
{
    public int RequiredKills { get; set; }
    public int CurrentKills { get; set; }

    public override bool IsComplete()
    {
        return CurrentKills >= RequiredKills;
    }
}

// Example of a Fetch Objective
public class FetchObjective : QuestObjective
{
    public QuestItem RequiredItem { get; set; }
    public int CurrentAmount { get; set; }

    public override bool IsComplete()
    {
        return CurrentAmount >= RequiredItem.quantity;
    }
}

[System.Serializable]
public class QuestItem
{
    public Item item;  // The item required for the quest
    public int quantity;
    public int itemID => item.itemID;  // Use ItemID for comparison
}
