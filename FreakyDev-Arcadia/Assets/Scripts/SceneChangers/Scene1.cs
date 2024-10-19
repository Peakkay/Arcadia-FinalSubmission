using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string loadScene;
    public string currentScene;
    public GameObject commonElements;

    public void Update()
    {
        if(gameObject.GetComponent<Transporter>().sceneChange)
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(loadScene, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(commonElements,SceneManager.GetSceneByName(loadScene));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
