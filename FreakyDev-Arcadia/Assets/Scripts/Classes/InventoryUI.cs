using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory
    public GameObject itemSlotPrefab; // Prefab for each item slot
    public Transform itemGridPanel; // Grid panel to place item slots
    

    public  InventoryUI()
    {

    }

    public void UpdateInventoryUI(Inventory inv)
    {
        inventory = inv;

        // Clear previous items
        foreach (Transform child in itemGridPanel)
        {
            Destroy(child.gameObject);
        }

        // Populate new items
        foreach (Item item in inventory.itemList)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemGridPanel);
            itemSlot.transform.SetParent(itemGridPanel, false);
            // itemSlot.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = item.itemIcon;
            // itemSlot.transform.Find("Quantity").GetComponent<Text>().text = item.itemQuantity.ToString();
            
            // Add Tooltip functionality
            UnityEngine.UI.Button itemButton = itemSlot.GetComponent<UnityEngine.UI.Button>();
            itemButton.onClick.AddListener(() => ShowItemTooltip(item));
        }
    }

    private void ShowItemTooltip(Item item)
    {
        Debug.Log($"Showing tooltip for {item.itemName}");
        // Tooltip logic goes here
    }
}
