using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import Unity's Scene Management

public class GameManager : Singleton<GameManager>
{
    public string currentSceneName; // To track the current scene
    public bool isPaused = false;    // Game pause state

    void Start()
    {
        // Initialize the game state by getting the active scene
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Load a new scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Use Unity's SceneManager to load the scene
        currentSceneName = sceneName;      // Update current scene name
    }

    // Restart the current scene
    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneName); // Restart the currently active scene
    }

    // Pause the game
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1; // Freeze or unfreeze time
        // Optionally show/hide pause menu UI here
    }

    // Save game state (example: player position, inventory, etc.)
    public void SaveGame()
    {
        // Implement saving logic here
        Debug.Log("Game Saved!");
    }

    // Load game state
    public void LoadGame()
    {
        // Implement loading logic here
        Debug.Log("Game Loaded!");
    }
}



