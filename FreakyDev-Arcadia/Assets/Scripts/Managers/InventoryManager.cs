using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Item> items = new List<Item>(); // List to store collected items

    // Add item to inventory
    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log($"Added {newItem.itemName} to inventory.");
    }

    // Remove item from inventory
    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            Debug.Log($"Removed {itemToRemove.itemName} from inventory.");
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(int itemID, int requiredQuantity)
    {
        int count = 0;
        foreach (var item in items)
        {
            if (item.itemID == itemID)
            {
                count++;
            }
        }
        return count >= requiredQuantity;
    }

    // Display all items (for debugging)
    public void DisplayInventory()
    {
        foreach (var item in items)
        {
            Debug.Log(item.itemName);
        }
    }
}


