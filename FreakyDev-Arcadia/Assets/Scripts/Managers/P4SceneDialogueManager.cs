using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P4SceneDialougueManager : Singleton<P4SceneDialougueManager>
{
    // Start is called before the first frame update

    public GameObject commonElements;
    public GameObject player;

    public Dialogue d411;
    public Dialogue d421;
    public Dialogue d431;
    public Dialogue d441;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startP4Scene1()
    {
        Debug.Log("p4s1 started");
           SceneManager.LoadScene("SearchForRedemption", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP4Scene1Loaded;
       
        

    }

    public void OnP4Scene1Loaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("p4s1 loaded");

            // Make sure the scene is set as the active scene
            P4GameManager.Instance.currentScene = "SearchForRedemption";
            SceneManager.SetActiveScene(scene);

            // Ensure common elements and player are moved to the correct scene and activated
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            player.SetActive(true);
             d411 = Resources.Load<Dialogue>("PlotFlow/Dialogues/IV/Scene1/411");

            
           // DialogueManager.Instance.StartDialogue(d411);
           SceneManager.UnloadSceneAsync("SCENE4");
        SceneManager.sceneLoaded -= OnP4Scene1Loaded;

        


    }

    public void startKieranDialogue(){
        Debug.Log("starting kieran dial");
        d411 = Resources.Load<Dialogue>("PlotFlow/Dialogues/IV/Scene1/411");
        if(d411 != null)
            DialogueManager.Instance.StartDialogue(d411);
        else{
            Debug.Log("kieran dia null");
        }
    }

    public void startLisrealDia(){
        Debug.Log("starting lisreal dial");
        d421 = Resources.Load<Dialogue>("PlotFlow/Dialogues/IV/Scene2/421");
        DialogueManager.Instance.StartDialogue(d421);
    }


    public void startP4Scene2()
    {
        SceneManager.LoadScene("FIndingBalance", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP4Scene2Loaded;

    }

    public void OnP4Scene2Loaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("p4s2 loaded");

            // Make sure the scene is set as the active scene
            P4GameManager.Instance.currentScene = "FindingBalance";
            SceneManager.SetActiveScene(scene);

            // Ensure common elements and player are moved to the correct scene and activated
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            player.SetActive(true);

            d421 = Resources.Load<Dialogue>("PlotFlow/Dialogues/IV/Scene2/421");
            // DialogueManager.Instance.StartDialogue(d411);
        SceneManager.sceneLoaded -= OnP4Scene2Loaded;
        SceneManager.UnloadSceneAsync("SearchForRedemption");
        
    }

    public void startP4Scene3()
    {
        SceneManager.LoadScene("RebuildingRelationships", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnP4Scene3Loaded;

    }

    public void OnP4Scene3Loaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("p4s3 loaded");

            // Make sure the scene is set as the active scene
            P4GameManager.Instance.currentScene = "RebuildingRelationships";
            SceneManager.SetActiveScene(scene);

            // Ensure common elements and player are moved to the correct scene and activated
            SceneManager.MoveGameObjectToScene(commonElements, scene);
            player.SetActive(true);

            d431 = Resources.Load<Dialogue>("PlotFlow/Dialogues/IV/Scene3/3open");
            DialogueManager.Instance.StartDialogue(d431);
           
        SceneManager.sceneLoaded -= OnP4Scene2Loaded;
         SceneManager.UnloadSceneAsync("FIndingBalance");
        
        
    }
}
