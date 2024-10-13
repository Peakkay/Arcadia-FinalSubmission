using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : Singleton<ChoiceManager>
{
    public List<Choice> choices; // List of available choices in this context
    public bool choiceAvailable;

    public void StartChoiceSelection()
    {
        choiceAvailable = true;
        StartCoroutine(WaitForChoice()); // Start the coroutine to wait for player input
    }
    private IEnumerator WaitForChoice()
    {
        // Present the choices first
        PresentChoices();

        // Wait until the player presses a valid key corresponding to the choices
        yield return new WaitUntil(() =>
        {
            for (int i = 0; i < choices.Count; i++)
            {
                // Check if the player presses a key for a specific choice (Alpha1, Alpha2, etc.)
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    Debug.Log($"You chose: {choices[i].choiceText}");
                    MakeChoice(i); // Call MakeChoice with the chosen index
                    return true; // Exit the wait condition once a valid key is pressed
                }
            }
            return false; // Continue waiting until a valid input is detected
        });

        // Once the choice is made, clear the available choices
        ClearChoices();
    }
    // Method to display the choices
    public void PresentChoices()
    {
        foreach (Choice choice in choices)
        {
            // Display each choice (could be buttons in the UI, etc.)
            Debug.Log($"{choice.choiceText}");
        }
        Debug.Log("Press the corresponding number to make a choice.");
    }

    // Method to handle player's choice selection
    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex < 0 || choiceIndex >= choices.Count) return;

        Choice selectedChoice = choices[choiceIndex];
        ApplyChoiceOutcome(selectedChoice); // Apply the outcome of the choice
        ClearChoices();
    }
    public void ApplyChoiceOutcome(Choice choice)
    {
        Debug.Log($"Player chose: {choice.choiceText}");

        // Apply corruption impact
        if (choice.corruptionImpact != 0)
        {
            FindObjectOfType<PlayerController>().IncreaseCorruption(choice.corruptionImpact);
        }

        // Apply stat impact
        if (choice.statImpact != null)
        {
            FindObjectOfType<PlayerStats>().IncreaseStat(choice.statImpact); // Implement IncreaseStat in PlayerController
        }

        // Unlock a new spell
        if (choice.newSpell != null)
        {
            TomeManager.Instance.LearnSpell(choice.newSpell);
            Debug.Log($"New spell unlocked: {choice.newSpell.spellName}");
        }

        // Shift reality, if applicable
        if (choice.targetReality != null)
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


