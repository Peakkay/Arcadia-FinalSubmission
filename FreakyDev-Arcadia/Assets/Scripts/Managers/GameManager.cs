using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Game states
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
    public bool phase1Completed;
    public bool IntroSceneOver = false;
    public bool P1Scene1Over;
    public bool P1Scene2Over;
    public bool P1Scene3Over;
    public bool P1Scene4Over;
    public bool P1Scene5Over;
    public bool P1Scene6Over;
    public bool PhaseTransitionStarted;
    public bool phase2Completed;
    public bool P2Scene1Over;
    public bool P2Scene2Over;
    public bool P2Scene3Over;
    public bool P2Scene4Over;
    public bool KieranChoiceStarted;
    public bool phase3Completed;
    public bool phase4Completed;
    public bool phase5Completed;
    public Quest strangersGift;
    public Quest twistingTheFactions;
    public Quest confrontation;
    public Quest reflectionOrBlame;
    public Scene Scene0;
    public Scene phase1start;
    public Scene phase2start;
    public Scene phase3start;
    public Scene phase4start;
    public Scene phase5start;

    public bool P3Scene1Over;
    public bool P3Scene2Over;
    public bool P3Scene3Over;
    public bool P3Scene4Over;
    public bool P3Scene5Over;
    public bool P3Scene6Over;
    public bool P3PhaseTransition;
    public bool P4Scene1Over;

    public bool trigger1=true;
    public bool trigger2=true;
     public bool trigger3=true;
     
     public bool trigger4=true;

     public bool trigger5=true;

//    public int LiraelMeter;
//    public int KieranMeter;
//    public int CorruptionMeter;

//LIST OF SCENEFLAGS
    public bool introDialogueFinished;

    public bool enterLibrary;
    public bool pickupTome;

// LIST END

// LIST OF GAMEFLAGS
    public bool TomeUsed;
    public bool InvestigateAlong;
    public bool EmbraceFirstManipulation;
    public bool KieranAgree;
    public bool ContinuedManipulating;
    public bool seekAllies;
    public bool addressFaction;
    public bool choseDiplomacy;
    public Quest ReflectionOfBlame;
    public Quest BurdenOfPower;
    public Quest findKieran;
    public Quest findLisrael;

    bool keiranFound = false;
    bool lisraelFound = false;
// LIST END



    public GameObject player;


    protected override void Awake()
    {
        base.Awake();
        CurrentState = GameState.MainMenu; // Initialize to main menu
        SceneDialogueManager.Instance.StartScene0();
    }

    private void Update()
    {
        // Handle input based on game state
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
                // Additional states can be managed here
        }

        if(currentScene == "IntroScene" && !IntroSceneOver)
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(0) && !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("IntroOver");
                SceneDialogueManager.Instance.StartP1Scene1();
                StartPhase1();
            }
        }
        if(currentScene == "OrdinaryLife" && !P1Scene1Over && IntroSceneOver)
        {
            if(MapManager.Instance.currentMap==1)
            {
                Debug.Log("P1Scene1Over");
                SceneDialogueManager.Instance.StartP1Scene2();
            }
        }
        if(currentScene == "AwakeningOfPower" && !P1Scene2Over && P1Scene1Over)
        {
            if(QuestManager.Instance.IsQuestCompleted(0) && !DialogueManager.Instance.CheckTriggerDialogue(3))
            {
                SceneDialogueManager.Instance.StartTomeDialogue();
            }
        }
        if(currentScene == "AwakeningOfPower" && !P1Scene2Over && P1Scene1Over)
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(3) && !DialogueManager.Instance.isDialogueActive)
            {
                if(MapManager.Instance.currentMap == 0)
                {
                    SceneDialogueManager.Instance.StartP1Scene3();
                }
            }
        }        
        if(currentScene == "FirstDecision" && !P1Scene3Over && P1Scene2Over)
        {
            if(QuestManager.Instance.IsQuestCompleted(1) && ChoiceManager.Instance.choices.Count == 0 && !DialogueManager.Instance.isDialogueActive && !ChoiceManager.Instance.choiceAvailable && !SceneDialogueManager.Instance.startedCriminalScene)
            {
                Choice use = Resources.Load<Choice>("PlotFlow/Choices/Main/I/TesttheTome'sPower_Use");
                TomeUsed = (use.chosen)?true:false;
                SceneDialogueManager.Instance.StartCriminalScene();
            }
        }
        if(currentScene == "FirstDecision" && !P1Scene3Over && P1Scene2Over)
        {
            if((DialogueManager.Instance.CheckTriggerDialogue(6) || DialogueManager.Instance.CheckTriggerDialogue(5)) && !DialogueManager.Instance.isDialogueActive && !ChoiceManager.Instance.choiceAvailable)
            {
                SceneDialogueManager.Instance.StartP1Scene4();
            }
        }
        if(currentScene == "ConsequenceOfChoice" && !P1Scene4Over && P1Scene3Over)
        {
            if((DialogueManager.Instance.CheckTriggerDialogue(7)||DialogueManager.Instance.CheckTriggerDialogue(8)) && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartP1Scene5();
            }
        }
        if(currentScene == "IntroductionToConflict" && !P1Scene5Over && P1Scene4Over)
        {
            if(QuestManager.Instance.IsQuestCompleted(2) && !SceneDialogueManager.Instance.startedLirael && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartGoToLiraelDialogue();
            }
        }
        if(currentScene == "IntroductionToConflict" && !P1Scene5Over && P1Scene4Over)
        {
            if(QuestManager.Instance.IsQuestCompleted(3) && !DialogueManager.Instance.CheckTriggerDialogue(11) &!DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartLiraelDialogue();
            }
        }
        if(currentScene == "IntroductionToConflict" && !P1Scene5Over && P1Scene4Over)
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(11)&& !DialogueManager.Instance.CheckTriggerDialogue(12)&& !PhaseTransitionStarted && !DialogueManager.Instance.isDialogueActive && currentScene !="PhaseTransition")
            {
                Debug.Log("Start Transition");
                SceneDialogueManager.Instance.StartP1Scene6();
            }
        }
        if(currentScene == "PhaseTransition" && !P1Scene6Over && P1Scene5Over)
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(12) && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartP2Scene1();
                CompletePhase1();
            }
        }

        if(currentScene == "GatheringInformation" && !P2Scene1Over && P1Scene6Over && phase1Completed) // && P1Scene6Over && phase1Completed
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(13)&& !DialogueManager.Instance.CheckTriggerDialogue(14) && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartInfo();
            }
        }
        if(currentScene == "GatheringInformation" && !P2Scene1Over && P1Scene6Over && phase1Completed) //  && P1Scene6Over && phase1Completed
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(14) && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartP2Scene2();
            }
        }
        if(currentScene == "FirstManipulation" && !P2Scene2Over && P1Scene6Over && phase1Completed) //  && P1Scene6Over && phase1Completed
        {
            if(QuestManager.Instance.IsQuestCompleted(4) && DialogueManager.Instance.CheckTriggerDialogue(15) && !SceneDialogueManager.Instance.startedManipulate && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.Manipulate();
            }
        }
        if(currentScene == "FirstManipulation" && !P2Scene2Over) //  && P1Scene6Over && phase1Completed
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(16) && currentScene !="IntroductionOfKieran" && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.StartP2Scene3();
            }
        }
        if(currentScene == "IntroductionOfKieran" && !P2Scene3Over && P2Scene2Over) //  && P1Scene6Over && phase1Completed
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(17)&& !KieranChoiceStarted && !DialogueManager.Instance.isDialogueActive)
            {
                SceneDialogueManager.Instance.KieranDecision();
            }
        }
        if(currentScene == "IntroductionOfKieran" && !P2Scene3Over && P2Scene2Over) //  && P1Scene6Over && phase1Completed
        {
            if( !(DialogueManager.Instance.CheckTriggerDialogue(18)||DialogueManager.Instance.CheckTriggerDialogue(19))&&KieranChoiceStarted && !DialogueManager.Instance.isDialogueActive && !ChoiceManager.Instance.choiceAvailable)
            {
                SceneDialogueManager.Instance.KieranReply();
            }
        }
        if(currentScene == "IntroductionOfKieran" && !P2Scene3Over && P2Scene2Over) //  && P1Scene6Over && phase1Completed
        {
            if((DialogueManager.Instance.CheckTriggerDialogue(18)||DialogueManager.Instance.CheckTriggerDialogue(19))&&KieranChoiceStarted && !DialogueManager.Instance.isDialogueActive && !ChoiceManager.Instance.choiceAvailable)
            {
                SceneDialogueManager.Instance.StartP2Scene4();
            }
        }
        if(currentScene == "P3Transition" && !P2Scene4Over && P2Scene3Over) //  && P1Scene6Over && phase1Completed
        {
            if((DialogueManager.Instance.CheckTriggerDialogue(18)||DialogueManager.Instance.CheckTriggerDialogue(19))&&KieranChoiceStarted && !DialogueManager.Instance.isDialogueActive && !ChoiceManager.Instance.choiceAvailable)
            {
                SceneDialogueManager.Instance.StartP3Scene1();
                CompletePhase2();
            }
        }
        if (currentScene == "Reality Starts to Break" && !P3Scene1Over)
        {  
            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(69) && 
                !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("P3Scene1Over");
                P3Scene1Over = true;
                if (SceneDialogueManager.Instance != null)
                {
                    SceneDialogueManager.Instance.StartP3Scene2();
                }
            }
        }
          if (SceneDialogueManager.Instance.P3Scene2Open != null && QuestManager.Instance.IsQuestCompleted(69) && trigger1)
            {  
                DialogueManager.Instance.StartDialogue(SceneDialogueManager.Instance.P3Scene2Open);
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
                if (SceneDialogueManager.Instance != null)
                {
                    SceneDialogueManager.Instance.StartP3Scene3();
                }
            }
        }
        if (SceneDialogueManager.Instance.P3Scene3Open != null && QuestManager.Instance.IsQuestCompleted(70) && trigger2)
            {  
                DialogueManager.Instance.StartDialogue(SceneDialogueManager.Instance.P3Scene3Open);
                trigger2=false;
            }

        if (currentScene == "Consequence of Power" && !P3Scene3Over)
        {
            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(71)
                )
            {
                Debug.Log("P3Scene3Over");
                P3Scene3Over = true;
                if (SceneDialogueManager.Instance != null)
                {
                    SceneDialogueManager.Instance.StartP3Scene4();
                }
            }
        }
        if (SceneDialogueManager.Instance.P3Scene4Open != null && QuestManager.Instance.IsQuestCompleted(71) && trigger3)
            {  
                DialogueManager.Instance.StartDialogue(SceneDialogueManager.Instance.P3Scene4Open);
                trigger3=false;
            }

        if (currentScene == "Rise of Antogonist" && !P3Scene4Over)
        {
            if (DialogueManager.Instance != null && 
                QuestManager.Instance.IsQuestCompleted(71)
                )
            {
                Debug.Log("P3Scene4Over");
                P3Scene4Over = true;
                if (SceneDialogueManager.Instance != null)
                {
                    SceneDialogueManager.Instance.StartP3Scene5();
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

         if(DialogueManager.Instance != null && !trigger4 &&
                !DialogueManager.Instance.isDialogueActive && !CombatManager.Instance.combatActive && trigger5)
                {
                      Debug.Log("P3Scene5Over");
                      P3Scene5Over = true;
                    if (SceneDialogueManager.Instance != null)
                    {
                    SceneDialogueManager.Instance.StartP3Scene6();
                    }
                    trigger5=false;

                }

        if(!DialogueManager.Instance.isDialogueActive && !trigger5 && P3Scene5Over)
        {
            SceneDialogueManager.Instance.startP4Scene1();
        }


        if(currentScene == "SearchForRedemption")
        {

            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.CheckTriggerDialogue(411) && 
                !DialogueManager.Instance.isDialogueActive && keiranFound)
                {
                    Debug.Log("p4s1 over");
                    P4Scene1Over = true;
                    SceneDialogueManager.Instance.startP4Scene2();
                }
            
            if(QuestManager.Instance.IsQuestCompleted(411)  && !DialogueManager.Instance.CheckTriggerDialogue(411) && !keiranFound)
            {
                Debug.Log("kieran found");
                keiranFound = true;

                SceneDialogueManager.Instance.startKieranDialogue();
            }

            if( keiranFound && DialogueManager.Instance.CheckTriggerDialogue(411) && !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("dia finished");
                currentScene = "FindingBalance";
              SceneDialogueManager.Instance.startP4Scene2();
              QuestManager.Instance.StartQuest(findLisrael);
            }
        }

        if(currentScene == "FindingBalance")
        {
             if(QuestManager.Instance.IsQuestCompleted(421)  && !DialogueManager.Instance.CheckTriggerDialogue(421) && !lisraelFound)
            {
                Debug.Log("lisrael found");
                lisraelFound = true;

                SceneDialogueManager.Instance.startLisrealDia();
            }

            if(lisraelFound && DialogueManager.Instance.CheckTriggerDialogue(421) && !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("dia finished");
                currentScene = "RebuildingRelationships";
              SceneDialogueManager.Instance.startP4Scene3();
             // QuestManager.Instance.StartQuest(findLisrael);
            }

            // if(QuestManager.Instance.IsQuestCompleted(421))
            // {
            //     Debug.Log("quest comp");
            //     SceneDialogueManager.Instance.startLisrealDia();
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

        if (phase == "Phase1")
            StartPhase1(); // Initiate the first phase of the plot
        else if (phase == "Phase2")
            StartPhase2(); // Move to the second phase when Phase 1 is done
        else if (phase == "Phase3")
            StartPhase3(); // Move to the second phase when Phase 1 is done
        else if (phase == "Phase4")
            StartPhase4(); // Move to the second phase when Phase 1 is done
        else if (phase == "Phase5")
            StartPhase5(); // Move to the second phase when Phase 1 is done        
    }

    void StartPhase1()
    {
        // Initiate dialogues, quests, or events in Phase 1
        QuestManager.Instance.StartQuest(strangersGift);
    }
    public void CompletePhase1()
    {
        phase1Completed = true;
        StartPhase("Phase2");
    }

    public void StartPhase2()
    {
        // Initiate dialogues, quests, or events in Phase 2
        QuestManager.Instance.StartQuest(twistingTheFactions);
    }
    public void CompletePhase2()
    {
        phase2Completed = true;
        StartPhase("Phase3");
    }
    void StartPhase3()
    {
        // Initiate dialogues, quests, or events in Phase 3
        QuestManager.Instance.StartQuest(confrontation);
    }
    public void CompletePhase3()
    {
        phase3Completed = true;
        StartPhase("Phase4");
    }
    void StartPhase4()
    {
        // Initiate dialogues, quests, or events in Phase 4
        QuestManager.Instance.StartQuest(reflectionOrBlame);

    }
    public void CompletePhase4()
    {
        phase4Completed = true;
        StartPhase("Phase5");
    }
    void StartPhase5()
    {
        // Initiate dialogues, quests, or events in Phase 2
    }
    public void DetermineEnding()
    {
        phase5Completed = true;
    }
}
