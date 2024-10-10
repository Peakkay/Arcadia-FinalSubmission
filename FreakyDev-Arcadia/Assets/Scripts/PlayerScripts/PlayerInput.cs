using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void Start()
    {
        // Get the PlayerMovement component attached to the same GameObject
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerMovement.MovePlayerTo(new Vector3(0, playerMovement.tileSize, 0)); // Move up
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerMovement.MovePlayerTo(new Vector3(0, -playerMovement.tileSize, 0)); // Move down
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerMovement.MovePlayerTo(new Vector3(-playerMovement.tileSize, 0, 0)); // Move left
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerMovement.MovePlayerTo(new Vector3(playerMovement.tileSize, 0, 0)); // Move right
        }
    }
}


