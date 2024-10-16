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

        // Check for all colliders in the interaction layer
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playerPosition, interactionDistance, interactableLayer);

        foreach (var hitCollider in hitColliders)
        {
            // If an interactable object is hit, call its interaction method
            IInteractable interactable = hitCollider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Check distance to the interactable
                float distanceToInteractable = Vector2.Distance(playerPosition, hitCollider.transform.position);
                if (distanceToInteractable <= interactionDistance)
                {
                    interactable.Interact();
                    break; // Exit the loop after interacting
                }
            }
        }
    }
}
