using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P3GameManager : Singleton<P3GameManager>
{
    // Start is called before the first frame update

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

    public bool P3Scene1Over;
    public bool P3Scene2Over;
    public bool P3Scene3Over;

    public Quest Confrontation;
    public Quest ShadowsintheRanks;

    public Quest Showdown;

    public GameObject player;
    // protected override void Awake()
    // {
    //     base.Awake();
    //     CurrentState = GameState.MainMenu; // Initialize to main menu
    //     SceneDialogueManager.Instance.StartScene0();
    // }



    
    void Start()
    {
        P3SceneDialougeManager.Instance.StartP3Scene1();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene == "P3Scene1")
        {
            if(DialogueManager.Instance.CheckTriggerDialogue(311) && !DialogueManager.Instance.isDialogueActive)
            {
                Debug.Log("Dialouge 311 triggered");
 
               // StartPhase1();
            }
        }
    }
}
