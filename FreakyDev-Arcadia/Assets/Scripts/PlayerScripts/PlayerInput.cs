using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.canMove) // Check if movement is allowed
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        // Check for movement keys and ensure the player is not currently moving
        if (!playerMovement.IsMoving) // Check if the player is currently moving
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMovement.Move(Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerMovement.Move(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                playerMovement.Move(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerMovement.Move(Vector3.right);
            }
        }
    }
}
