using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction
{
    public Fact fact;
    public int influenceLevel; // Influence in the world
    public int reputation; // How much the player is respected/hated by this faction
    public List<NPCController> members; // Key NPCs who belong to this faction

    public Faction(Fact faction)
    {
        fact = faction;
        influenceLevel = 0;
        reputation = 0;
        members = new List<NPCController>();
    }

    // Method to modify influence level
    public void ChangeInfluence(int amount)
    {
        influenceLevel += amount;
        Debug.Log($"{fact} influence changed by {amount}. Current influence: {influenceLevel}");
    }

    // Method to modify reputation
    public void ChangeReputation(int amount)
    {
        reputation += amount;
        Debug.Log($"{fact} reputation changed by {amount}. Current reputation: {reputation}");
    }

    // Add more faction-specific behavior here
}

public enum Fact
{
    OrderOfTheTome,
    TheFallen,
    Neutral
}

