using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour {
    public Transform canvas;
    public KeyCode keyCode;

// Use this for initialization
	void Start () {
        GetComponentInChildren<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if the keycode that is set
		if (Input.GetKeyDown(keyCode))
        {
            //if canvas gameobject inactive in heirarchy
            if (GetComponentInChildren<Canvas>().enabled)
            {
                GetComponentInChildren<Canvas>().enabled = false;
                Time.timeScale = 1;

            } else
            {
                //Note that inventory is disabled before ItemDatabase since exception will be thrown id 
                GetComponentInChildren<Canvas>().enabled = true;
                Time.timeScale = 0;
            }
        }
	}
}
