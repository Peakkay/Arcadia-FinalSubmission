using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    public void LoadScene(string sceneName)
    {
        // Logic to load a new scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

