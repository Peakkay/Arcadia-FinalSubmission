using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerCorruptionLevel = 0; // Player's corruption level, starts at 0

    // Method to increase corruption
    public void IncreaseCorruption(int amount)
    {
        playerCorruptionLevel += amount;
        Debug.Log($"Player corruption increased by {amount}. New corruption level: {playerCorruptionLevel}");

        CheckCorruptionEffects(); // Handle effects of corruption
    }

    // Method to decrease corruption (for positive actions)
    public void DecreaseCorruption(int amount)
    {
        playerCorruptionLevel = Mathf.Max(playerCorruptionLevel - amount, 0); // Corruption can't be negative
        Debug.Log($"Player corruption decreased by {amount}. New corruption level: {playerCorruptionLevel}");

        CheckCorruptionEffects();
    }

    // Check if player corruption triggers any major gameplay effects
    private void CheckCorruptionEffects()
    {
        if (playerCorruptionLevel >= 50)
        {
            Debug.Log("Player has reached a high corruption level! Certain NPCs may react negatively.");
            // Apply additional logic here (e.g., change faction alignment, NPC reactions)
        }
        else if (playerCorruptionLevel == 0)
        {
            Debug.Log("Player is pure! Certain factions may view the player more favorably.");
            // Apply logic for low corruption state
        }
    }
}

