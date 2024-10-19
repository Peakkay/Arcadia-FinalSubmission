using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDialogueManager : Singleton<SceneDialogueManager>
{
    public GameObject commonElements;
    public GameObject player;
    public Dialogue Scene0;
    public Dialogue P1Scene1Open;
    public Dialogue P1Scene2Open;
    public Dialogue TomeDialogue;
    public Dialogue P1Scene3Open;
    public Dialogue P1Scene4Open;
    public Dialogue P1Scene5Open;
    public Dialogue P1Scene6Open;
    public Dialogue P1PhaseTransition;
    public Dialogue P2Scene1Open;
    public Dialogue P2Scene2Open;
    public Dialogue P2Scene3Open;
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
            if (P2Scene2Open == null)
            {
                P2Scene2Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene2/OpeningDialogue");
            }
            DialogueManager.Instance.StartDialogue(P2Scene2Open); // Null check before calling the method
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
            if (P2Scene2Open == null)
            {
                P2Scene2Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/I/Scene3/OpeningDialogue");
            }
            DialogueManager.Instance.StartDialogue(P2Scene3Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP1Scene3Loaded;
        }
    }
}

