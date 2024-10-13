using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChoice", menuName = "Choice")]
public class Choice : ScriptableObject
{
    public string choiceText;  // Text displayed for the choice
    public int corruptionImpact;  // Change in corruption from this choice
    public Stat statImpact;  // Impact on player's stats
    public Spell newSpell;  // A spell the player might gain from this choice
    public Reality targetReality; // Reality shift from this choice, if any
    public Quest newQuest;  // New quest to start from this choice

    // Method to apply the outcomes of this choice
}
