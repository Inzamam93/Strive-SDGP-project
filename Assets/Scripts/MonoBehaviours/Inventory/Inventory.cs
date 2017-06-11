using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Inventory component is added on to the inventoryManager game object
//Handles populating slots of the slot panel
//Handles initial adding and storing of items that are added in a list
public class Inventory : MonoBehaviour {
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    //contains a list of the items
    public List<Item> items = new List<Item>();
    //contains list of inventory slots
    public List<GameObject> slots = new List<GameObject>();
    

    //empty slots still have an item which was instantiated using the overloaded constructor item that sets their id to -1
    void Start()
    {
        //grabbing the component item database
        database = GetComponent<ItemDatabase>();

        //the amount of slots that are available
        slotAmount = 20;

        //CHANGE the name of Items Panel: confuses heirarchy and purpose.
        inventoryPanel = GameObject.Find("Items Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            //false was added to fix(40 times) scaling issue
            // by setting worldPositionStays to false as a second parameter to SetParent.
            slots[i].transform.SetParent(slotPanel.transform, false);
        }

        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
    }

    //Adding item to inventory and instantiating and setting the sprite
    public void AddItem(int id)
    {
        //Fetch item that is to be added from the database
        Item itemToAdd = database.FetchItemById(id);
        if (itemToAdd.Stackable && isItemInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    //getting the item gameobjects component ItemData
                    ItemData data = slots[1].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    //getting the child of the gameobject Item and accessing its Text component
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            //finding an empty slot and instantiating item GameObject
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;

                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform, false);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.transform.localPosition = Vector2.zero;
                    //Regardless of whether item is stackable or not we set the amount to 1
                    //Needs to happen after item is added
                    slots[i].transform.GetChild(0).GetComponent<ItemData>().amount = 1;
                    break;
                }
            }
        }
    }

    bool isItemInInventory(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
            {
                return true;
            }
        }
        return false;
    }
}
