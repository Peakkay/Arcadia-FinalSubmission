using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSystem : MonoBehaviour
{
    public List<Choice> choices; // List of available choices in this context
    public GameObject choiceUI;   // Reference to UI component for displaying choices

    // Method to display the choices
    public void PresentChoices()
    {
        choiceUI.SetActive(true); // Enable the choice UI
        foreach (Choice choice in choices)
        {
            // Display each choice (could be buttons in the UI, etc.)
            Debug.Log($"{choice.choiceText}");
        }
    }

    // Method to handle player's choice selection
    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex < 0 || choiceIndex >= choices.Count) return;

        Choice selectedChoice = choices[choiceIndex];
        ApplyChoiceOutcome(selectedChoice); // Apply the outcome of the choice
        choiceUI.SetActive(false); // Hide choice UI after selection
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
        if (choice.targetReality != Reality.Normal)
        {
            RealityManager.Instance.PerformRealityShift(RealityManager.Instance.realityStates[choice.targetReality]);
        }

        // Start a new quest, if applicable
        if (choice.newQuest != null)
        {
            QuestManager.Instance.StartQuest(choice.newQuest);
        }
    }
}


