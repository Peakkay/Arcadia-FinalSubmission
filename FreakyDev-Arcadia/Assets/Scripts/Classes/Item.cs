using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public string description;
    public int itemID;  // Unique identifier for each item
    public Sprite icon;

    public Item(string name, string desc, int id)
    {
        itemName = name;
        description = desc;
        itemID = id;
    }
}


