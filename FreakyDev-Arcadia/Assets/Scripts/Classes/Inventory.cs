using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    // Adds an item to the inventory
    public void AddItem(Item newItem)
    {
        itemList.Add(newItem);
    }

    // Removes an item from the inventory
    public void RemoveItem(Item itemToRemove)
    {
        itemList.Remove(itemToRemove);
    }

    // Sort items by type
    public void SortItemsByType()
    {
        itemList.Sort((x, y) => x.itemType.CompareTo(y.itemType));
    }

    public void Start()
{
    Inventory inventory = new Inventory();
    InventoryUI inventoryUI = new InventoryUI();
    // Add test items to the inventory
    Item sword = new Item("sword", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);
    Item potion = new  Item("potion", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);
    Item armor = new Item("potion", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);

    inventory.AddItem(sword);
    inventory.AddItem(potion);
    inventory.AddItem(armor);   

    // Call to update the UI with these items
    inventoryUI.UpdateInventoryUI(inventory);
}
}
