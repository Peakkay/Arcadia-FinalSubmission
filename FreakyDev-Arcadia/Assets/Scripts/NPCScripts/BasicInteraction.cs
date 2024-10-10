using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteraction : MonoBehaviour
{
    public float interactionDistance = 2f; // Maximum distance for interaction
    public LayerMask interactableLayer; // Layer for interactable objects

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Use 'E' for interaction
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        // Get the player's position
        Vector3 playerPosition = transform.position;

        // Cast a ray from the player's position to check for interactable objects
        RaycastHit2D hit = Physics2D.Raycast(playerPosition, mainCamera.transform.forward, interactionDistance, interactableLayer);
        
        if (hit.collider != null)
        {
            // If an interactable object is hit, call its interaction method
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}

