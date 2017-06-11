using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {
    List<Item> database;
    List<GameObject> instantiatedItems;
    public Transform itemDatabase;
    public GameObject activeItem;
	// Use this for initialization
	void Start () {
        database = itemDatabase.GetComponent<ItemDatabase>().getDatabase();

	}
	
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)){
            //if (activeItem==itemDatabase[1])
            activeItem.SetActive(false);
        }
    }
}
