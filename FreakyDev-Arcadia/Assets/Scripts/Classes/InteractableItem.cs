using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    public Item item; // The item that can be picked up

    public void Interact()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject); // Remove the item from the world after pickup
    }
}

