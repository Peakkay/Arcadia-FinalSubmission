using System.Collections.Generic;
using UnityEngine;

public class FactionManager : Singleton<FactionManager>
{
    public Dictionary<Faction, int> factionInfluence; // Tracks influence over each faction (0-100)
    public Faction OrderOfTheTome;
    public Faction Neutral;
    public Faction TheFallen;

    private void Start()
    {
        OrderOfTheTome = new Faction(Fact.OrderOfTheTome);
        Neutral = new Faction(Fact.Neutral);
        TheFallen = new Faction(Fact.Neutral);
        factionInfluence = new Dictionary<Faction, int>
        {
            { OrderOfTheTome, 50 },
            { TheFallen, 50 },
            { Neutral, 50 }
        };
    }

    // Method to adjust faction influence based on NPC corruption
    public void UpdateFactionInfluence(Faction faction, int influenceChange)
    {
        if (factionInfluence.ContainsKey(faction))
        {
            factionInfluence[faction] += influenceChange;
            factionInfluence[faction] = Mathf.Clamp(factionInfluence[faction], 0, 100);
            Debug.Log($"Faction {faction} influence updated to {factionInfluence[faction]}");
        }
    }

    // Method to check current faction standings
    public void ShowFactionInfluence()
    {
        foreach (var faction in factionInfluence)
        {
            Debug.Log($"{faction.Key}: {faction.Value}% influence");
        }
    }
    public void ManipulateNPC(NPCController npc, int corruptionAmount)
    {
        if (npc.isKeyNPC)
        {
            npc.CorruptNPC(corruptionAmount);

            // Adjust faction influence based on the NPC's faction
            UpdateFactionInfluence(npc.npcFaction, corruptionAmount / 2);

            if (npc.corruptionLevel >= 100)
            {
                Debug.Log($"{npc.npcName} has been fully corrupted!");
            }
        }
    }
}
