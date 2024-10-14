using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestReward
{
    public List<Item> rewardItems;         // List of items rewarded
    public int playercorruptionImpact; 
    public int worldcorruptionImpact;
    public int npccorruptionImpact;
    public NPCController targetNPC;
    public Spell newSpell;                 // Spell rewarded
    public Quest newQuest;                 // New quest unlocked after completing this quest
}
