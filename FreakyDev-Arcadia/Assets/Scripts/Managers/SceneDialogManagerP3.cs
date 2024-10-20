using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDialogManagerP3 : Singleton<SceneDialogManagerP3>
{
    public Dialogue P3Scene1Open;
    public Dialogue P3Scene2Open;
    public Dialogue P3Scene3Open;
    public Dialogue P3Scene4Open;
    public Dialogue P3Scene5Open;
    public Dialogue P3Scene6Open;
    public Dialogue P3PhaseTransition;

    public GameObject commonElements;
    public GameObject player;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("SceneDialogueManager Awake");
    }

    public void StartP3Scene1()
    {
        SceneManager.LoadScene("Reality Starts to Break", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene1Loaded;
    }

    public void OnP3Scene1Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Reality Starts to Break")
        {
            Debug.Log("Reality Starts to Break");

            // Make sure the scene is set as the active scene
            GameManagerP3.Instance.currentScene = "Reality Starts to Break";
            SceneManager.SetActiveScene(scene);

            // Ensure common elements and player are moved to the correct scene and activated
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            player.SetActive(true);

            // Check for DialogueManager instance
            if (DialogueManager.Instance != null)
            {
                // Ensure dialogue is loaded and start it
                if (P3Scene1Open == null)
                {
                    P3Scene1Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/III/Reality Starts to Break/Dialogue 1");
                }

                if (P3Scene1Open != null)
                {
                    DialogueManager.Instance.StartDialogue(P3Scene1Open);
                }
                else
                {
                    Debug.LogError("Dialogue for P3Scene1Open not found!");
                }
            }
            else
            {
                Debug.LogError("DialogueManager instance is null!");
            }

            // Unsubscribe after loading the scene
            SceneManager.sceneLoaded -= OnP3Scene1Loaded;
        }
    }

    public void StartP3Scene2()
    {
        SceneManager.LoadScene("ConfrontationWithRivals", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene2Loaded;
    }

    public void OnP3Scene2Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "ConfrontationWithRivals")
        {
            Debug.Log("ConfrontationWithRivals");
            GameManagerP3.Instance.P3Scene1Over = true;
            GameManagerP3.Instance.currentScene = "ConfrontationWithRivals";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("Reality Starts to Break");

            if (P3Scene2Open == null)
            {
                P3Scene2Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/III/ConfrontationWithRivals/Dialogue 2");
            }

           

            SceneManager.sceneLoaded -= OnP3Scene2Loaded;
        }
    }

    public void StartP3Scene3()
    {
        SceneManager.LoadScene("Consequence of Power", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene3Loaded;
    }

    public void OnP3Scene3Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Consequence of Power")
        {
            Debug.Log("Consequence of Power");
            GameManagerP3.Instance.P3Scene2Over = true;
            GameManagerP3.Instance.currentScene = "Consequence of Power";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("ConfrontationWithRivals");

            if (P3Scene3Open == null)
            {
                P3Scene3Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/III/Consequence of Power/Dialogue 3");
            }

            Quest Newsquest = new Quest();
            Newsquest = Resources.Load<Quest>("PlotFlow/Quests/Main/III/LiraelQuest");
            QuestManager.Instance.StartQuest(Newsquest);
           
            SceneManager.sceneLoaded -= OnP3Scene3Loaded;
        }
    }

    public void StartP3Scene4()
    {
        SceneManager.LoadScene("Rise of Antogonist", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene4Loaded;
    }

    public void OnP3Scene4Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Rise of Antogonist")
        {
            Debug.Log("Rise of Antogonist");
            GameManagerP3.Instance.P3Scene3Over = true;
            GameManagerP3.Instance.currentScene = "Rise of Antogonist";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("Consequence of Power");
            MapManager.Instance.ChangeMap(5);

            if (P3Scene4Open == null)
            {
                P3Scene4Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/III/Rise of Antogonist/Dialogue 4");
            }
             
            Quest Newsquest1 = new Quest();
            Newsquest1 = Resources.Load<Quest>("PlotFlow/Quests/Main/III/AzraelQuest");
            QuestManager.Instance.StartQuest(Newsquest1);
            
          

            SceneManager.sceneLoaded -= OnP3Scene4Loaded;
        }
    }

    public void StartP3Scene5()
    {
        SceneManager.LoadScene("TheFinalConfrontation", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene5Loaded;
    }

    public void OnP3Scene5Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TheFinalConfrontation")
        {
            Debug.Log("TheFinalConfrontation");
            GameManagerP3.Instance.P3Scene4Over = true;
            GameManagerP3.Instance.currentScene = "TheFinalConfrontation";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("Rise of Antogonist");

            if (P3Scene5Open == null)
            {
                P3Scene5Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/III/TheFinalConfrontation/Dialogue 5");
            }

            if (P3Scene5Open != null)
            {
                DialogueManager.Instance.StartDialogue(P3Scene5Open);
            }
          

            SceneManager.sceneLoaded -= OnP3Scene5Loaded;
        }
    }
      public void StartP3Scene6()
    {
        SceneManager.LoadScene("Consequence of Battle", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene6Loaded;
    }
     public void OnP3Scene6Loaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Consequence of Battle")
        {
            Debug.Log("Consequence of Battle");
            GameManagerP3.Instance.P3Scene5Over = true;
            GameManagerP3.Instance.currentScene = "Consequence of Battle";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("TheFinalConfrontation");
            MapManager.Instance.ChangeMap(9);
            if (P3Scene6Open == null)
            {   Debug.Log("Hello");
                P3Scene6Open = Resources.Load<Dialogue>("PlotFlow/Dialogues/III/Consequence of Battle/Dialogue 6");
            }

            if (P3Scene6Open != null)
            {   Debug.Log("Hello");
                DialogueManager.Instance.StartDialogue(P3Scene6Open);
            }
          

            SceneManager.sceneLoaded -= OnP3Scene6Loaded;
        }
    }
}
