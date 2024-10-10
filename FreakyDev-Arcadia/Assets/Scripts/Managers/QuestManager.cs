using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests; // List of active quests

    void Start()
    {
        activeQuests = new List<Quest>();
        InitializeQuests();
    }

    // Initialize quests (could also be loaded from a file or database)
    void InitializeQuests()
    {
        // Example quests
        Quest quest1 = new Quest("Find the Lost Item", "Locate the lost item in the village.", new List<string> { "Search the village", "Return the item" });
        activeQuests.Add(quest1);
    }

    // Mark a quest as completed
    public void CompleteQuest(Quest quest)
    {
        if (activeQuests.Contains(quest))
        {
            quest.CompleteQuest();
            Debug.Log($"Quest '{quest.questName}' completed!");
            // Optionally remove the quest from the list or handle rewards
        }
    }

    // Display all active quests (for testing purposes)
    public void DisplayActiveQuests()
    {
        foreach (Quest quest in activeQuests)
        {
            string status = quest.isCompleted ? "Completed" : "Active";
            Debug.Log($"Quest: {quest.questName} - {status}");
        }
    }
}


