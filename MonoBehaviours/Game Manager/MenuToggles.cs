using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggles : MonoBehaviour {
    public KeyCode inventoryToggle;
    public KeyCode pauseMenuToggle;
    private KeyCode active;

    public GameObject inventory;
    public GameObject pauseMenu;
    public GameObject[] menus;

	void Update () {
        for (int i = 0; i < menus.Length; i++)
        {
            Debug.Log(i);
        }
	}

    void ToggleMenu(Component canvas, KeyCode keyToggle)
    {
        if (Input.GetKeyDown(keyToggle))
        {

            if (canvas.GetComponent<Canvas>().enabled)
            {
                canvas.GetComponent<Canvas>().enabled = false;
            }
            else
            {
                canvas.GetComponent<Canvas>().enabled = true;
            }
        }
    }

}

class Menu
{
    //public GameObject gameObject;
   // public KeyCode keyCode;
}
