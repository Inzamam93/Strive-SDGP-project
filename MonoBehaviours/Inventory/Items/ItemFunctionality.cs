using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsableItemFunctionality : MonoBehaviour {
    public bool active;

    public KeyCode toggleKey;
    Component itemData;
	// Use this for initialization
	void Start () {
        //**does this need to be in update?
        itemData = GetComponent<ItemData>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(toggleKey))
        {
            Instantiate(this.gameObject);
            this.gameObject.transform.SetParent(FindObjectOfType<Player>().transform);
        }
	}

    //functionality is different for each item
    abstract public void functionality();
    

}
