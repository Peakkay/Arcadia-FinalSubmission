using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P4GameManager : Singleton<P4GameManager>
{

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; }
    public string currentPhase;
    public string currentScene;

    public bool P4Scene1Over;
    public bool P4Scene2Over;
    public bool P4Scene3Over;
    public bool P4Scene4Over;
    public bool P4Scene5Over;
    public bool P4Scene6Over;
    public Quest ReflectionOfBlame;
    public Quest BurdenOfPower;
    public Quest findKieran;
    public Quest findLisrael;

    bool keiranFound = false;
    bool lisraelFound = false;

     protected override void Awake()
    {
        base.Awake();
        // Remove any call to DontDestroyOnLoad here or control it with conditions
        // Only apply it if certain conditions are met.
    }

    // Start is called before the first frame update
    void Start()
    {
       // SceneManager.UnloadSceneAsync("SearchForRedemption");
       Debug.Log("started");
       keiranFound = false;
       lisraelFound = false;

        startPhase4();

        if(P4SceneDialougueManager.Instance != null)
        {
            P4SceneDialougueManager.Instance.startP4Scene1();
        }
    }

    void startPhase4(){
        QuestManager.Instance.StartQuest(ReflectionOfBlame);
        QuestManager.Instance.StartQuest(findKieran);
        Debug.Log("Phase 4 Started");

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Current Scene: " + currentScene);
        // Debug.Log("Current GameState: " + CurrentState);

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

        if(currentScene == "SearchForRedemption")
        {

            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(411) && 
                !DialogueManager.Instance.isDialogueActive && keiranFound)
                {
                    Debug.Log("p4s1 over");
                    P4Scene1Over = true;
                    P4SceneDialougueManager.Instance.startP4Scene2();
                }
            
            if(QuestManager.Instance.IsQuestCompleted(411)  && !DialogueManager.Instance.CheckTriggerDialogue(411) && !keiranFound)
            {
                Debug.Log("kieran found");
                keiranFound = true;

                P4SceneDialougueManager.Instance.startKieranDialogue();
            }

            if( keiranFound && DialogueManager.Instance.CheckTriggerDialogue(411) && !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("dia finished");
                currentScene = "FindingBalance";
              P4SceneDialougueManager.Instance.startP4Scene2();
              QuestManager.Instance.StartQuest(findLisrael);
            }
        }

        if(currentScene == "FindingBalance")
        {
             if(QuestManager.Instance.IsQuestCompleted(421)  && !DialogueManager.Instance.CheckTriggerDialogue(421) && !lisraelFound)
            {
                Debug.Log("lisrael found");
                lisraelFound = true;

                P4SceneDialougueManager.Instance.startLisrealDia();
            }

            if(lisraelFound && DialogueManager.Instance.CheckTriggerDialogue(421) && !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("dia finished");
                currentScene = "RebuildingRelationships";
              P4SceneDialougueManager.Instance.startP4Scene3();
             // QuestManager.Instance.StartQuest(findLisrael);
            }

            // if(QuestManager.Instance.IsQuestCompleted(421))
            // {
            //     Debug.Log("quest comp");
            //     P4SceneDialougueManager.Instance.startLisrealDia();
            // }
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
}
