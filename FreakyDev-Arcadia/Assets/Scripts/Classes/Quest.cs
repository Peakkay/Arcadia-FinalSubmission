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
    public Dictionary<int, List<string>> dialogueMap; // Map of NPC to dialogue lines
    public List<int> nPCID;
    public List<string> dialogues;
    public int currentDialogueIndex = 0; // Track the current dialogue line index

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
