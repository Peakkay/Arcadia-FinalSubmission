using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem" ,menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public int itemID;  // Unique identifier for each item
    public Sprite icon;
    public Stat stats;
    public bool isEquipped = false; // Track whether the item is equipped or not
    public ItemType itemType; // Enum to represent different item types (e.g., weapon, armor, etc.)
    public Item(string name, string desc, int id,Stat stat)
    {
        itemName = name;
        description = desc;
        itemID = id;
        stats = stat;
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Accessory,
    Tome,
    Consumable,
    None
}


