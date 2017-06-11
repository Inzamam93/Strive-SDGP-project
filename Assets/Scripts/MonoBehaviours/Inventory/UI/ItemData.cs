using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Item item;
    public int amount;
    public int slot;

    //holds the original parent of the item (item slot)
    private Transform originalParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //if an item exists then set var originalParent to hold the slot
        if (item.ID != -1)
        {
            originalParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item.ID != -1)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item.ID != -1)
        {
            //event data holds the mouse position
            this.transform.position = eventData.position;
            //setting it back to the original parent
            this.transform.SetParent(originalParent);
        }
    }
}
