using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class inventoryUIManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject panel;
    public GameObject allitems_panel;


    public GameObject itemPrefab;
    InventoryManager inventoryManag;
    Inventory inventory = new Inventory();
    int shownItems= 0;
    
    public void Start()
    {
    // Add test items to the inventory
    // Item sword = new Item("sword", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);
    // Item potion = new  Item("potion", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);
    // Item armor = new Item("potion", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);

    // inventory.AddItem(sword);
    // inventory.AddItem(potion);
    // inventory.AddItem(armor);   

    // Call to update the UI with these items
    //inventoryUI.UpdateInventoryUI(inventory);
    inventoryManag = InventoryManager.Instance;

    List<Item> allitems = InventoryManager.Instance.items;
    Item sword1Item =  new Item("sword","A simple sword",101,new Stat());
    
    Item armor1Item =  new Item("armor","simple armor",102, new Stat());

    // allitems.Add(sword1Item);
    // allitems.Add(armor1Item);

    foreach( Transform child in allitems_panel.transform)
    {
        Destroy(child.gameObject);
    }

    foreach( Transform child in panel.transform)
    {
        Destroy(child.gameObject);
    }

    Debug.Log(allitems.Count);
    
    foreach(Item i in allitems)
    {
        GameObject itemInstance = Instantiate(itemPrefab);
        TMP_Text textComponent = itemInstance.GetComponentInChildren<TMP_Text>();
        Debug.Log(i.itemName);

        if(textComponent != null){
            textComponent.text = i.itemName;
            
        }

        UnityEngine.UI.Button b = itemInstance.GetComponentInChildren<UnityEngine.UI.Button>();
        b.onClick.AddListener(() => OnButtonClick(i, itemInstance));


        if(shownItems<allitems.Count)
        {
            if(i.isEquipped == false)

                itemInstance.transform.SetParent(allitems_panel.transform);
            else
                itemInstance.transform.SetParent(panel.transform);
           // shownItems++;
        }

    }




    }

    void OnButtonClick(Item item, GameObject b)
    {
        Debug.Log($"Clicked on {item.itemName}");
        if(b.transform.parent.name == "allitems")
        {
            if(item != null)
                inventoryManag.EquipItem(item);
            else  
                Debug.Log("null error");
           // Debug.Log("item equipped");
            b.transform.SetParent(panel.transform);

        }
        else {
            inventoryManag.UnequipItem(item);
            b.transform.SetParent(allitems_panel.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            //SceneManager.LoadScene("TestScene");
             gameObject.SetActive(false);
        }
    }

    // public void sword1Click(){

    //     Item sword1Item =  new Item("sword","A simple sword",101,new Stat());

    //     if(sword1.transform.parent.name == "allitems")
    //     {
    //         inventory.AddItem( sword1Item);

    //         sword1.transform.SetParent(panel.transform);

            
    //         //InventoryUI invui = new InventoryUI();

    //         //sword1.transform.SetParent(panel.transform, false);


            


    //         Debug.Log("sword added   " );

    //     }

    //     else{
    //         inventory.RemoveItem(sword1Item);
    //         sword1.transform.SetParent(allitems_panel.transform);
    //         Debug.Log("sword removed");
    //     }
    // }


    // public void armor1Click(){
    //     Item armor1Item =  new Item("armor","simple armor",102, new Stat());
    //     if(armor1.transform.parent.name == "allitems")
    //     {
    //         inventory.AddItem( armor1Item);

    //         armor1.transform.SetParent(panel.transform);

            
    //         //InventoryUI invui = new InventoryUI();

    //         //sword1.transform.SetParent(panel.transform, false);


            


    //         Debug.Log("sword added   " );

    //     }

    //     else{
    //         inventory.RemoveItem(armor1Item);
    //         armor1.transform.SetParent(allitems_panel.transform);
    //         Debug.Log("sword removed");
    //     }
    // }

    
}
