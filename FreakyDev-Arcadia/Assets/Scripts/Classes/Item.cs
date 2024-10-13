using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public int itemID;
    public string itemType; // e.g., "Weapon", "Potion", etc.
    public string rarity; // e.g., "Common", "Rare", etc.
    public string description; // Description for tooltip
    public int itemQuantity;

    public Item(string name, Sprite icon, int id, string type, string rarity, string desc, int iq)
    {
        itemName = name;
        itemIcon = icon;
        itemID = id;
        itemType = type;
        this.rarity = rarity;
        description = desc;
        itemQuantity = iq;

    }
}
