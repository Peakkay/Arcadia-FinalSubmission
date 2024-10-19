using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    // Store game state
    public string currentPhase;
    public bool phase1Completed;
    public bool phase2Completed;
    public bool phase3Completed;
    public bool phase4Completed;
    public bool phase5Completed;

    // Quest statuses
    public bool strangersGiftCompleted;
    public bool informationGatheringCompleted;
    public bool confrontationCompleted;
    public bool reflectionOrBlameCompleted;

    // Game flags
    public bool TomeUsed;
    public bool InvestigateAlong;
    public bool EmbraceFirstManipulation;
    public bool KieranAgree;
    public bool ContinuedManipulating;
    public bool seekAllies;
    public bool adressFaction;
    public bool choseDiplomacy;
}

public class SaveManager : MonoBehaviour
{
    // Singleton instance
    public static SaveManager Instance { get; private set; }
    private string saveFilePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        saveFilePath = Application.persistentDataPath + "/savefile.json";
    }

    // Save Game Method
    public void SaveGame(GameManager gameManager)
    {
        GameData data = new GameData();

        // Save game phases and quest data from GameManager
        data.currentPhase = gameManager.currentPhase;
        data.phase1Completed = gameManager.phase1Completed;
        data.phase2Completed = gameManager.phase2Completed;
        data.phase3Completed = gameManager.phase3Completed;
        data.phase4Completed = gameManager.phase4Completed;
        data.phase5Completed = gameManager.phase5Completed;


        // Save game flags
        data.TomeUsed = gameManager.TomeUsed;
        data.InvestigateAlong = gameManager.InvestigateAlong;
        data.EmbraceFirstManipulation = gameManager.EmbraceFirstManipulation;
        data.KieranAgree = gameManager.KieranAgree;
        data.ContinuedManipulating = gameManager.ContinuedManipulating;
        data.seekAllies = gameManager.seekAllies;
        data.adressFaction = gameManager.adressFaction;
        data.choseDiplomacy = gameManager.choseDiplomacy;

        // Serialize and save data to file
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);

        DisplayDialogue("Game saved successfully!");
    }

    // Load Game Method
    public void LoadGame(GameManager gameManager)
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            // Load game phases and quest data into GameManager
            gameManager.currentPhase = data.currentPhase;
            gameManager.phase1Completed = data.phase1Completed;
            gameManager.phase2Completed = data.phase2Completed;
            gameManager.phase3Completed = data.phase3Completed;
            gameManager.phase4Completed = data.phase4Completed;
            gameManager.phase5Completed = data.phase5Completed;

            // Load game flags
            gameManager.TomeUsed = data.TomeUsed;
            gameManager.InvestigateAlong = data.InvestigateAlong;
            gameManager.EmbraceFirstManipulation = data.EmbraceFirstManipulation;
            gameManager.KieranAgree = data.KieranAgree;
            gameManager.ContinuedManipulating = data.ContinuedManipulating;
            gameManager.seekAllies = data.seekAllies;
            gameManager.adressFaction = data.adressFaction;
            gameManager.choseDiplomacy = data.choseDiplomacy;

            DisplayDialogue("Game loaded successfully!");
        }
        else
        {
            DisplayDialogue("No save file found.");
        }
    }

    // Delete Save
    public void DeleteSave()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            DisplayDialogue("Save file deleted!");
        }
        else
        {
            DisplayDialogue("No save file found to delete.");
        }
    }

    // DisplayDialogue method to call DialogueManager
    private void DisplayDialogue(string message)
    {
        Dialogue dialogueObject = new Dialogue();
        dialogueObject.lines = new List<string> { message }; // Create a dialogue with the message
        DialogueManager.Instance.StartDialogue(dialogueObject); // Display in dialogue box
    }
}
