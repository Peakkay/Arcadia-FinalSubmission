using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDialogueManager : Singleton<SceneDialogueManager>
{
    public GameObject commonElements;
    public GameObject player;
    public GameObject bgvisual;
    public Dialogue Scene0;
    public Dialogue P1Scene1Open;
    public Dialogue P1Scene2Open;
    public Dialogue TomeDialogue;
    public Dialogue P1Scene3Open;
    public Dialogue CriminalDialogue =  new Dialogue();
    public bool startedCriminalScene;
    public Dialogue P1Scene4Open;
    public Dialogue P1Scene5Open;
    public Dialogue GoToLirael;
    public bool startedLirael = false;
    public Dialogue LiraelDialogue;
    public Dialogue P1Scene6Open;
    public Dialogue P1PhaseTransition;
    public bool PhaseTransitionStarted;
    public Dialogue P2Scene1Open;
    public Dialogue InfoDialogue;
    public Dialogue P2Scene2Open;
    public Dialogue ManipulateDialogue;
    public bool startedManipulate;
    public Dialogue P2Scene3Open;
    public NPCController kieran;
    public Dialogue kieranReply;
    public Dialogue P2Scene4Open;
    public Dialogue P2Scene5Open;
    public Dialogue P2Scene6Open;
    public Dialogue P2PhaseTransition;
    public Dialogue P3Scene1Open;
    public Dialogue P3Scene2Open;
    public Dialogue P3Scene3Open;
    public Dialogue P3Scene4Open;
    public Dialogue P3Scene5Open;
    public Dialogue P3Scene6Open;
    public Dialogue P3PhaseTransition;
    public Dialogue P4Scene1Open;
    public Dialogue P4Scene2Open;
    public Dialogue P4Scene3Open;
    public Dialogue P4Scene4Open;
    public Dialogue P4Scene5Open;
    public Dialogue P4Scene6Open;
    public Dialogue P4PhaseTransition;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("SceneDialogueManager Awake");
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartScene0()
    {
        Debug.Log("StartScene0 Called");
        SceneManager.LoadScene("IntroScene", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnScene0Loaded; // Subscribe to the sceneLoaded event
    }

    private void OnScene0Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroScene")
        {
            GameManager.Instance.currentPhase = "Phase1";
            GameManager.Instance.currentScene = "IntroScene";
            Debug.Log("IntroScene Loaded");
            SceneManager.SetActiveScene(scene); // Now safe to set it as the active scene
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            Scene0 = Resources.Load<Dialogue>("PlotFlow/Dialogues/Scene0/Intro");
            DialogueManager.Instance.StartDialogue(Scene0);
            // Unsubscribe from the event to avoid multiple triggers
            SceneManager.sceneLoaded -= OnScene0Loaded;
        }
    }

    public void StartP1Scene1()
    {
        SceneManager.LoadScene("OrdinaryLife", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP1Scene1Loaded;
    }

    private void OnP1Scene1Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OrdinaryLife")
        {
            Debug.Log("OrdinaryLife Loaded");
            GameManager.Instance.IntroSceneOver = true;
            GameManager.Instance.currentScene = "OrdinaryLife";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            player.SetActive(true);
            MapManager.Instance.ChangeMap(4);
            SceneManager.UnloadSceneAsync("IntroScene");
            P1Scene1Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene1/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P1Scene1Open);
            SceneManager.sceneLoaded -= OnP1Scene1Loaded;
        }
    }

    public void StartP1Scene2()
    {
        SceneManager.LoadScene("AwakeningOfPower", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP1Scene2Loaded;
    }

    private void OnP1Scene2Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "AwakeningOfPower")
        {
            Debug.Log("AwakeningOfPower Loaded");
            GameManager.Instance.P1Scene1Over = true;
            GameManager.Instance.currentScene = "AwakeningOfPower";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("OrdinaryLife");
            if (P1Scene2Open == null)
            {
                P1Scene2Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene2/OpeningDialogue");
            }
            DialogueManager.Instance.StartDialogue(P1Scene2Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP1Scene2Loaded;
        }
    }

    public void StartTomeDialogue()
    {
        if(TomeDialogue == null)
        {
            TomeDialogue = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene2/TomePickupDialogue");
        }
        DialogueManager.Instance.StartDialogue(TomeDialogue);
    }

    public void StartP1Scene3()
    {
        SceneManager.LoadScene("FirstDecision", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP1Scene3Loaded;
    }

    private void OnP1Scene3Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FirstDecision")
        {
            Debug.Log("FirstDecision Loaded");
            GameManager.Instance.P1Scene2Over = true;
            GameManager.Instance.currentScene = "FirstDecision";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("AwakeningOfPower");
            if (P1Scene3Open == null)
            {
                P1Scene3Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene3/OpeningDialogue");
            }
            DialogueManager.Instance.StartDialogue(P1Scene3Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP1Scene3Loaded;
        }
    }

    public void StartCriminalScene()
    {
        if(GameManager.Instance.TomeUsed)
        {
            CriminalDialogue = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene3/TomeUseDialogue");
        }
        else
        {
            CriminalDialogue = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene3/TomeObserveDialogue");
        }
        startedCriminalScene = true;
        DialogueManager.Instance.StartDialogue(CriminalDialogue);
    }
    public void StartP1Scene4()
    {
        SceneManager.LoadScene("ConsequenceOfChoice", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP1Scene4Loaded;
    }

    private void OnP1Scene4Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "ConsequenceOfChoice")
        {
            Debug.Log("ConsequenceOfChoice Loaded");
            GameManager.Instance.P1Scene3Over = true;
            GameManager.Instance.currentScene = "ConsequenceOfChoice";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("FirstDecision");
            if(GameManager.Instance.TomeUsed)
            {
                P1Scene4Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene4/TomeUseDialogue");
            }
            else
            {
                P1Scene4Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene4/TomeObserveDialogue");
            }
            DialogueManager.Instance.StartDialogue(P1Scene4Open); // Null check before calling the method
            MapManager.Instance.ChangeMap(4);
            player.transform.position = new Vector3(-4,3,0);
            player.GetComponent<PlayerMovement>().targetPosition = new Vector3(-4,3,0);
            SceneManager.sceneLoaded -= OnP1Scene4Loaded;
        }
    }

    public void StartP1Scene5()
    {
        SceneManager.LoadScene("IntroductionToConflict", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP1Scene5Loaded;
    }

    private void OnP1Scene5Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroductionToConflict")
        {
            Debug.Log("IntroductionToConflict Loaded");
            GameManager.Instance.P1Scene4Over = true;
            GameManager.Instance.currentScene = "IntroductionToConflict";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("ConsequenceOfChoice");
            P1Scene5Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene5/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P1Scene5Open); // Null check before calling the method
            Quest Newsquest = new Quest();
            Newsquest = Resources.Load<Quest>("PlotFlow/Quests/Main/I/News");
            QuestManager.Instance.StartQuest(Newsquest);
            SceneManager.sceneLoaded -= OnP1Scene5Loaded;
        }
    }

    public void StartGoToLiraelDialogue()
    {
        GoToLirael = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene5/GoToLirael");
        DialogueManager.Instance.StartDialogue(GoToLirael);
        startedLirael = true;
    }

    public void StartLiraelDialogue()
    {
        LiraelDialogue = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene5/LiraelDialogue");
        DialogueManager.Instance.StartDialogue(LiraelDialogue);
    }

    public void StartP1Scene6()
    {
        SceneManager.LoadScene("PhaseTransition", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP1Scene6Loaded;
    }

    private void OnP1Scene6Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "PhaseTransition")
        {
            Debug.Log("PhaseTransition Loaded");
            GameManager.Instance.P1Scene5Over = true;
            GameManager.Instance.currentScene = "PhaseTransition";
            bgvisual.SetActive(true);
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("IntroductionToConflict");
            MapManager.Instance.NoMap();
            player.SetActive(false);
            GameManager.Instance.PhaseTransitionStarted = true;
            P1Scene6Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene6/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P1Scene6Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP1Scene5Loaded;
        }
    }
    public void StartP2Scene1()
    {
        SceneManager.LoadScene("GatheringInformation", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP2Scene1Loaded;
    }

    private void OnP2Scene1Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GatheringInformation")
        {
            Debug.Log("GatheringInformation Loaded");
            GameManager.Instance.P1Scene6Over = true;
            GameManager.Instance.currentScene = "GatheringInformation";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("PhaseTransition");
            bgvisual.SetActive(false);
            MapManager.Instance.ChangeMap(2);
            player.SetActive(true);
            player.transform.position = new Vector3(-5,2,0);
            player.GetComponent<PlayerMovement>().targetPosition = new Vector3(-5,2,0);
            P2Scene1Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene1/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P2Scene1Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP2Scene1Loaded;
        }
    }

    public void StartInfo()
    {
        InfoDialogue = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene1/LiraelDialogue");
        DialogueManager.Instance.StartDialogue(InfoDialogue); // Null check before calling the method
    }
    public void StartP2Scene2()
    {
        SceneManager.LoadScene("FirstManipulation", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP2Scene2Loaded;
    }

    private void OnP2Scene2Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FirstManipulation")
        {
            Debug.Log("FirstManipulation Loaded");
            GameManager.Instance.P2Scene1Over = true;
            GameManager.Instance.currentScene = "FirstManipulation";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("GatheringInformation");
            MapManager.Instance.ChangeMap(3);
            player.transform.position = new Vector3(-8,-9,0);
            player.GetComponent<PlayerMovement>().targetPosition = new Vector3(-8,-5,0);
            P2Scene2Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene2/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P2Scene2Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP2Scene2Loaded;
        }
    }

    public void Manipulate()
    {
        ManipulateDialogue = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene2/ManipulateDialogue");
        DialogueManager.Instance.StartDialogue(ManipulateDialogue);
        startedManipulate = true;
    }

    public void StartP2Scene3()
    {
        SceneManager.LoadScene("IntroductionOfKieran", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP2Scene3Loaded;
    }

    private void OnP2Scene3Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroductionOfKieran")
        {
            Debug.Log("IntroductionOfKieran Loaded");
            GameManager.Instance.P2Scene2Over = true;
            GameManager.Instance.currentScene = "IntroductionOfKieran";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("FirstManipulation");
            MapManager.Instance.ChangeMap(0);
            player.transform.position = new Vector3(20,-20,0);
            player.GetComponent<PlayerMovement>().targetPosition = new Vector3(20,-20,0);
            P2Scene3Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene3/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P2Scene3Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP2Scene3Loaded;
        }
    }
    public void KieranDecision()
    {
        kieran = FindObjectOfType<NPCController>();
        kieran.npcChoices.Add(Resources.Load<Choice>("Plotflow/Choices/Main/II/Scene3/KieranAgree"));
        kieran.npcChoices.Add(Resources.Load<Choice>("Plotflow/Choices/Main/II/Scene3/KieranDisagree"));
        kieran.UpdateChoices();
        ChoiceManager.Instance.StartChoiceSelection(kieran);
        GameManager.Instance.KieranChoiceStarted = true;
        Choice kieranagree = Resources.Load<Choice>("Plotflow/Choices/Main/II/Scene3/KieranAgree");
        GameManager.Instance.KieranAgree = (kieranagree.chosen)?true:false;
    }

    public void KieranReply()
    {
        if(GameManager.Instance.KieranAgree)
        {
            kieranReply = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene3/kieranAgreeReply");
        }
        else{
            kieranReply = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene3/kieranDisagreeReply");
        }
        DialogueManager.Instance.StartDialogue(kieranReply);
    }
    public void StartP2Scene4()
    {
        SceneManager.LoadScene("P3Transition", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP2Scene4Loaded;
    }

    private void OnP2Scene4Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "P3Transition")
        {
            Debug.Log("P3Transition Loaded");
            GameManager.Instance.P2Scene3Over = true;
            GameManager.Instance.currentScene = "P3Transition";
            bgvisual.SetActive(true);
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("IntroductionOfKieran");
            MapManager.Instance.NoMap();
            player.SetActive(false);
            GameManager.Instance.PhaseTransitionStarted = true;
            P2Scene4Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/II/Scene4/OpeningDialogue");
            DialogueManager.Instance.StartDialogue(P2Scene4Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP2Scene4Loaded;
        }
    }
}

