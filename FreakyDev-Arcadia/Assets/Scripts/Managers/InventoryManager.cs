using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Item> items = new List<Item>(); // List to store collected items
    private PlayerStats playerStats;

    public void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public bool HasItemOfType(ItemType type)
    {
        foreach (Item item in items)
        {
            if (item.itemType == type && item.isEquipped)
            {
                return true; // Found an item of the specified type that is equipped
            }
        }
        return false; // No equipped item of the specified type found
    }
    public void UnequipItemOfType(ItemType type)
    {
        foreach (Item item in items)
        {
            if (item.itemType == type && item.isEquipped)
            {
                UnequipItem(item);
                return; // Found an item of the specified type that is equipped
            }
        }
        return; // No equipped item of the specified type found
    }

    // Equip an item
    public void EquipItem(Item item)
    {
        if (item.isEquipped) return; // If the item is already equipped, ignore
        UnequipItemOfType(item.itemType);
        item.isEquipped = true;
        playerStats.ApplyItemBonus(item); // Apply the stat bonuses to the player
        Debug.Log($"{item.itemName} has been equipped.");
        playerStats.PrintStats(); // Print updated stats for debugging
    }
    public void UnequipItem(Item item)
    {
        if (!item.isEquipped) return; // If the item is not equipped, ignore

        item.isEquipped = false;
        playerStats.RemoveItemBonus(item); // Remove the stat bonuses
        Debug.Log($"{item.itemName} has been unequipped.");
        playerStats.PrintStats(); // Print updated stats for debugging
    }

    // Add item to inventory
    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log($"{newItem.itemName} has been added to inventory");
        QuestManager.Instance.UpdateActiveQuests();
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


