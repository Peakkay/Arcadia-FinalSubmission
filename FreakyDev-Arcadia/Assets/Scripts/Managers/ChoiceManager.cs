using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : Singleton<ChoiceManager>
{
    public List<Choice> choices; // List of available choices in this context
    public bool choiceAvailable;

    public void StartChoiceSelection(NPCController NPC)
    {
        choiceAvailable = true;
        StartCoroutine(WaitForChoice(NPC)); // Start the coroutine to wait for player input
    }

    private IEnumerator WaitForChoice(NPCController NPC)
    {
        // Present the choices first
        PresentChoices(NPC);

        // Wait until the player presses a valid key corresponding to the choices
        yield return new WaitUntil(() =>
        {
            for (int i = 0; i < choices.Count; i++)
            {
                // Check if the player presses a key for a specific choice (Alpha1, Alpha2, etc.)
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    // Check if the choice is valid based on corruption levels
                    if (CanPlayerMakeChoice(choices[i], NPC))
                    {
                        Debug.Log($"You chose: {choices[i].choiceText}");
                        MakeChoice(i, NPC); // Call MakeChoice with the chosen index
                        return true; // Exit the wait condition once a valid key is pressed
                    }
                    else
                    {
                        Debug.Log("This choice is blocked due to corruption constraints.");
                    }
                }
            }
            return false; // Continue waiting until a valid input is detected
        });

        // Once the choice is made, clear the available choices
        ClearChoices();
    }

    public void PresentChoices(NPCController NPC)
    {
        foreach (Choice choice in choices)
        {
            // Check if the player can make this choice based on corruption levels
            if (CanPlayerMakeChoice(choice, NPC))
            {
                Debug.Log($"{choice.choiceText}");
            }
            else
            {
                Debug.Log($"{choice.choiceText} (Blocked due to corruption constraints)");
            }
        }

        Debug.Log("Press the corresponding number to make a choice.");
    }

    public bool CanPlayerMakeChoice(Choice choice, NPCController NPC)
    {
        int playerCorruption = FindObjectOfType<PlayerController>().playerCorruptionLevel;
        int worldCorruption = RealityManager.Instance.worldCorruption;
        int npcCorruption = NPC.corruptionLevel;

        // Check if the player's and NPC's corruption levels are within the allowed ranges
        if (playerCorruption >= choice.minPlayerCorruption &&
            playerCorruption <= choice.maxPlayerCorruption &&
            worldCorruption <= choice.maxWorldCorruption &&
            npcCorruption <= choice.maxNPCCorruption)
        {
            return true;
        }

        return false;
    }

    public void MakeChoice(int choiceIndex, NPCController NPC)
    {
        if (choiceIndex < 0 || choiceIndex >= choices.Count) return;

        Choice selectedChoice = choices[choiceIndex];
        ApplyChoiceOutcome(selectedChoice, NPC); // Apply the outcome of the choice
        ClearChoices();
    }

    public void ApplyChoiceOutcome(Choice choice, NPCController NPC)
    {
        Debug.Log($"Player chose: {choice.choiceText}");

        // Apply corruption impact on player
        if (choice.playercorruptionImpact != 0)
        {
            FindObjectOfType<PlayerController>().IncreaseCorruption(choice.playercorruptionImpact);
        }

        // Apply corruption impact on world
        if (choice.worldcorruptionImpact != 0)
        {
            RealityManager.Instance.AdjustWorldCorruption(choice.worldcorruptionImpact);
        }

        // Apply stat impact
        if (choice.statImpact != null)
        {
            FindObjectOfType<PlayerStats>().playerstats.AddStat(choice.statImpact);
        }

        // Unlock a new spell
        if (choice.newSpell != null)
        {
            TomeManager.Instance.LearnSpell(choice.newSpell);
            Debug.Log($"New spell unlocked: {choice.newSpell.spellName}");
        }

        // Shift reality, if applicable
        if (choice.targetReality != Reality.None)
        {
            RealityManager.Instance.PerformRealityShift(RealityManager.Instance.realityStates[choice.targetReality]);
        }

        // Start a new quest, if applicable
        if (choice.newQuest != null)
        {
            QuestManager.Instance.StartQuest(choice.newQuest);
        }
    }

    public void ClearChoices()
    {
        choices.Clear(); // Clear the list of choices
        choiceAvailable = false;
    }

    public void AddChoices(List<Choice> newChoices)
    {
        choices.AddRange(newChoices); // Add new choices to the list
    }
}



