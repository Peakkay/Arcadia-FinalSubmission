using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Quest
{
    public string questName;          // Name of the quest
    public string description;        // Description of the quest
    public bool isCompleted;          // Quest completion status
    public List<string> objectives;   // List of quest objectives

    public Quest(string name, string desc, List<string> objectives)
    {
        questName = name;
        description = desc;
        isCompleted = false;
        this.objectives = objectives;
    }

    // Mark quest as complete
    public void CompleteQuest()
    {
        isCompleted = true;
    }
}

