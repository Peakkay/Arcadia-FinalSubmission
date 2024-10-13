using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class inventoryManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sword1;

    public GameObject panel;
    public GameObject allitems_panel;

    public UnityEngine.UI.Button armor1;
    Inventory inventory = new Inventory();

    void Start()
    {
         InventoryUI inventoryUI = new InventoryUI();
    // Add test items to the inventory
    Item sword = new Item("sword", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);
    Item potion = new  Item("potion", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);
    Item armor = new Item("potion", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);

    inventory.AddItem(sword);
    inventory.AddItem(potion);
    inventory.AddItem(armor);   

    // Call to update the UI with these items
    //inventoryUI.UpdateInventoryUI(inventory);

        UnityEngine.UI.Button sword1_button = sword1.GetComponent<UnityEngine.UI.Button>();
        sword1_button.onClick.AddListener(sword1Click);

        armor1.onClick.AddListener(armor1Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sword1Click(){

        Item sword1Item =  new Item("sword", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "sword", 2);

        if(sword1.transform.parent.name == "allitems")
        {
            inventory.AddItem( sword1Item);

            sword1.transform.SetParent(panel.transform);

            
            //InventoryUI invui = new InventoryUI();

            //sword1.transform.SetParent(panel.transform, false);


            


            Debug.Log("sword added   " );

        }

        else{
            inventory.RemoveItem(sword1Item);
            sword1.transform.SetParent(allitems_panel.transform);
            Debug.Log("sword removed");
        }
    }


    public void armor1Click(){
        Item armor1Item =  new Item("armor", Resources.GetBuiltinResource<Sprite>("UI/Skin/UISprite.psd"),1, "weapon", "common", "armor", 2);

        if(armor1.transform.parent.name == "allitems")
        {
            inventory.AddItem( armor1Item);

            armor1.transform.SetParent(panel.transform);

            
            //InventoryUI invui = new InventoryUI();

            //sword1.transform.SetParent(panel.transform, false);


            


            Debug.Log("sword added   " );

        }

        else{
            inventory.RemoveItem(armor1Item);
            armor1.transform.SetParent(allitems_panel.transform);
            Debug.Log("sword removed");
        }
    }

    
}
