using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerP3 : Singleton<GameManagerP3>
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; }
    public bool P3Scene1Over;
    public bool P3Scene2Over;
    public bool P3Scene3Over;
    public bool P3Scene4Over;
    public bool P3Scene5Over;
    public bool P3Scene6Over;
    public bool P3PhaseTransition;
    public bool phase3Completed;

    public bool trigger1=true;
    public bool trigger2=true;

     public bool trigger3=true;
     
     public bool trigger4=true;

     public bool trigger5=true;
    public GameObject player;
    public string currentPhase;
    public string currentScene;

    public Quest Confrontation;

    protected override void Awake()
    {
        base.Awake();
        // Remove any call to DontDestroyOnLoad here or control it with conditions
        // Only apply it if certain conditions are met.
    }

    private void Start()
    {
        // Initialize quest and scene only after Start() to ensure everything is properly loaded
        if (QuestManager.Instance != null && Confrontation != null)
        {
            QuestManager.Instance.StartQuest(Confrontation);
        }
        else
        {
            Debug.LogError("QuestManager or Confrontation is null!");
        }

        if (SceneDialogManagerP3.Instance != null)
        {
            Debug.Log("Start");
            SceneDialogManagerP3.Instance.StartP3Scene1();
        }
        else
        {
            Debug.LogError("SceneDialogManagerP3 instance is null!");
        }
    }

    private void Update()
    {
       

        switch (CurrentState)
        {
            case GameState.Playing:
                // Example: Check for pause input
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;

            case GameState.Paused:
                // Example: Check for resume input
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ResumeGame();
                }
                break;
        }

        // Scene checks and transitions
        if (currentScene == "Reality Starts to Break" && !P3Scene1Over)
        {  
            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(69) && 
                !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("P3Scene1Over");
                P3Scene1Over = true;
                if (SceneDialogManagerP3.Instance != null)
                {
                    SceneDialogManagerP3.Instance.StartP3Scene2();
                }
            }
        }
          if (SceneDialogManagerP3.Instance.P3Scene2Open != null && QuestManager.Instance.IsQuestCompleted(69) && trigger1)
            {  
                DialogueManager.Instance.StartDialogue(SceneDialogManagerP3.Instance.P3Scene2Open);
                trigger1=false;
            }

        if (currentScene == "ConfrontationWithRivals" && !P3Scene2Over)
        {
            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(70) && 
                !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("P3Scene2Over");
                P3Scene2Over = true;
                if (SceneDialogManagerP3.Instance != null)
                {
                    SceneDialogManagerP3.Instance.StartP3Scene3();
                }
            }
        }
        if (SceneDialogManagerP3.Instance.P3Scene3Open != null && QuestManager.Instance.IsQuestCompleted(70) && trigger2)
            {  
                DialogueManager.Instance.StartDialogue(SceneDialogManagerP3.Instance.P3Scene3Open);
                trigger2=false;
            }

        if (currentScene == "Consequence of Power" && !P3Scene3Over)
        {
            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(71) && 
                !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("P3Scene3Over");
                P3Scene3Over = true;
                if (SceneDialogManagerP3.Instance != null)
                {
                    SceneDialogManagerP3.Instance.StartP3Scene4();
                }
            }
        }
         if (QuestManager.Instance.IsQuestCompleted(71) && trigger3)
            {  
                DialogueManager.Instance.StartDialogue(SceneDialogManagerP3.Instance.P3Scene4Open);
                trigger3=false;
            }
        if (currentScene == "Rise of Antogonist" && !P3Scene4Over)
        {
            if (QuestManager.Instance.IsQuestCompleted(71))
            {
                Debug.Log("P3Scene4Over");
                P3Scene4Over = true;
                if (SceneDialogManagerP3.Instance != null)
                {
                    SceneDialogManagerP3.Instance.StartP3Scene5();
                }
            }
        }
         if (currentScene == "TheFinalConfrontation" && !P3Scene5Over && trigger4)
         {
              List<Enemy> azraelfight = new List<Enemy>();
              azraelfight.AddRange(FindObjectsOfType<Enemy>());
              CombatManager.Instance.StartCombat(player.GetComponent<PlayerStats>(),azraelfight);
              trigger4=false;

         }

         if(DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(73) && 
                !DialogueManager.Instance.isDialogueActive && !CombatManager.Instance.combatActive && trigger5)
                {
                      Debug.Log("P3Scene5Over");
                      P3Scene5Over = true;
                    if (SceneDialogManagerP3.Instance != null)
                    {
                    SceneDialogManagerP3.Instance.StartP3Scene6();
                    }
                    trigger5=false;

                }
    }

    public void StartGame()
    {
        CurrentState = GameState.Playing;
    }

    public void PauseGame()
    {
        CurrentState = GameState.Paused;
        Time.timeScale = 0; // Freeze game time
        // Show pause menu UI (if implemented)
    }

    public void ResumeGame()
    {
        CurrentState = GameState.Playing;
        Time.timeScale = 1; // Resume game time
        // Hide pause menu UI (if implemented)
    }

    public void GameOver()
    {
        CurrentState = GameState.GameOver;
        // Show game over UI (if implemented)
    }

    public void LoadMainMenu()
    {
        CurrentState = GameState.MainMenu;
        LoadScene("MainMenu"); // Replace with your actual main menu scene name
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#endif
    }

    public void StartPhase(string phase)
    {
        currentPhase = phase;

        if (phase == "Phase3")
        {
            StartPhase3();
        }
    }

    void StartPhase3()
    {
        // Initiate dialogues, quests, or events in Phase 3
        if (QuestManager.Instance != null && Confrontation != null)
        {
            QuestManager.Instance.StartQuest(Confrontation);
        }
    }

    public void CompletePhase3()
    {
        phase3Completed = true;
        StartPhase("Phase4");
    }
}
