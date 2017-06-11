using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler {
    //HAS NOT BEEN ADDED ANYWHERE YET
    //Is added onto the item Slot prefavb
    public int id;
    private Inventory inventory;

    public void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //returns gameobject that has been dropped
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData> ();

        if (inventory.items[id].ID == -1)
        {
            //droppedItem.transform.SetParent()
        }

    }
}
