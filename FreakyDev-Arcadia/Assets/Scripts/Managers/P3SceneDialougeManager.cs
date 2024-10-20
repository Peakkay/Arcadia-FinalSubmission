using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P3SceneDialougeManager : Singleton<P3SceneDialougeManager>
{
    // Start is called before the first frame update

    public GameObject commonElements;

    public Dialogue P3Scene1Open;
    public Dialogue P3Scene2Open;

    public Dialogue P3Scene3Open;

    public Dialogue P3Scene4Open;

    public Dialogue P3Scene5Open;
    public Dialogue P3Scene6Open;
    public Dialogue P3Scene7Open;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     protected override void Awake()
    {
        base.Awake();
        Debug.Log("SceneDialogueManager Awake");
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartP3Scene1()
    {
        SceneManager.LoadScene("RealityStartsToBreak", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene1Loaded;
    }

    private void OnP3Scene1Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "RealityStartsToBreak")
        {
            Debug.Log("RealityStartsToBreak Loaded");
           // GameManager.Instance.P1Scene2Over = true;
            GameManager.Instance.currentScene = "RealityStartsToBreak";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("AwakeningOfPower");
            if (P3Scene1Open == null)
            {
                P3Scene1Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene1/NPC3..asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene1Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene1Loaded;
        }
    }

    public void StartP3Scene2()
    {
        SceneManager.LoadScene("ConfrontationWithRivals", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene2Loaded;
    }

    private void OnP3Scene2Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "ConfrontationWithRivals")
        {
            Debug.Log("ConfrontationWithRivals Loaded");
           // GameManager.Instance.P3Scene2Over = true;
            GameManager.Instance.currentScene = "ConfrontationWithRivals";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("RealityStartsToBreak");
            if (P3Scene2Open == null)
            {
                P3Scene2Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene2/321.asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene2Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene2Loaded;
        }
    }

    public void StartP3Scene3()
    {
        SceneManager.LoadScene("ConsequenceOfPower", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene2Loaded;
    }

    private void OnP3Scene3Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "ConsequenceOfPower")
        {
            Debug.Log("ConsequenceOfPower Loaded");
          //  GameManager.Instance.P3Scene3Over = true;
            GameManager.Instance.currentScene = "ConsequenceOfPower";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("ConfrontationWithRivals");
            if (P3Scene3Open == null)
            {
                P3Scene3Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene3/331.asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene3Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene3Loaded;
        }
    }

     public void StartP3Scene4()
    {
        SceneManager.LoadScene("RiseOfAntogonist", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene4Loaded;
    }

    private void OnP3Scene4Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "RiseOfAntogonist")
        {
            Debug.Log("RiseOfAntogonist Loaded");
          //  GameManager.Instance.P3Scene3Over = true;
            GameManager.Instance.currentScene = "RiseOfAntogonist";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("ConsequenceOfPower");
            if (P3Scene4Open == null)
            {
                P3Scene4Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene4/341.asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene4Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene4Loaded;
        }
    }


     public void StartP3Scene5()
    {
        SceneManager.LoadScene("TheFinalConfrontation", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene5Loaded;
    }

    private void OnP3Scene5Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "TheFinalConfrontation")
        {
            Debug.Log("TheFinalConfrontation Loaded");
          //  GameManager.Instance.P3Scene3Over = true;
            GameManager.Instance.currentScene = "TheFinalConfrontation";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("RiseOfAntogonist");
            if (P3Scene5Open == null)
            {
                P3Scene5Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene5/351.asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene5Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene5Loaded;
        }
    }


    public void StartP3Scene6()
    {
        SceneManager.LoadScene("ConsequenceOfBattle", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene6Loaded;
    }

    private void OnP3Scene6Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "ConsequenceOfBattle")
        {
            Debug.Log("ConsequenceOfBattle Loaded");
          //  GameManager.Instance.P3Scene3Over = true;
            GameManager.Instance.currentScene = "ConsequenceOfBattle";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("TheFinalConfrontation");
            if (P3Scene6Open == null)
            {
                P3Scene6Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene6/361.asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene6Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene6Loaded;
        }
    }


    public void StartP3Scene7()
    {
        SceneManager.LoadScene("PhaseTransition", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP3Scene7Loaded;
    }

    private void OnP3Scene7Loaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "PhaseTransition")
        {
            Debug.Log("PhaseTransition Loaded");
          //  GameManager.Instance.P3Scene3Over = true;
            GameManager.Instance.currentScene = "PhaseTransition";
            SceneManager.SetActiveScene(scene);
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            SceneManager.UnloadSceneAsync("ConsequenceOfBattle");
            if (P3Scene7Open == null)
            {
                P3Scene7Open = Resources.Load<Dialogue>("Assets/Scripts/PlotFlow/Dialogues/III/Scene6/361.asset");
            }
            DialogueManager.Instance.StartDialogue(P3Scene7Open); // Null check before calling the method
            SceneManager.sceneLoaded -= OnP3Scene7Loaded;
        }
    }


      
    

    
}
