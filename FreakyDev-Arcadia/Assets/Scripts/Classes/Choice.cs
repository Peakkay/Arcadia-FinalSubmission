using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChoice", menuName = "Choice")]
public class Choice : ScriptableObject
{
    public string choiceText;  // Text displayed for the choice
    public int playercorruptionImpact;  // Change in corruption from this choice
    public int worldcorruptionImpact;
    public Stat statImpact;  // Impact on player's stats
    public Spell newSpell;  // A spell the player might gain from this choice
    public Reality targetReality; // Reality shift from this choice, if any
    public Quest newQuest;  // New quest to start from this choice
    public int requiredWorldCorruption = 0; // Min world corruption to make the choice
    public int requiredNPCCorruption = 0; // Min NPC corruption to make the choice
    public int maxWorldCorruption = 0; // Min world corruption to make the choice
    public int maxNPCCorruption = 0; // Min NPC corruption to make the choice
    public int minPlayerCorruption = 0;
    public int maxPlayerCorruption = 0;
    public bool chosen = false;

    // Method to apply the outcomes of this choice
}
