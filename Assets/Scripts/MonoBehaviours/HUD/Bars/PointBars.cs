using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBars : MonoBehaviour {

    public Image healthBar;
    public Image staminaBar;
    public Image hungerBar;
    public Image thirstBar;

    public PlayerAttributes player;
	
	void Update () {
        healthBar.fillAmount = player.health / player.maxHealth/1.0f;
        staminaBar.fillAmount = player.stamina / player.maxStamina/1.0f;
        hungerBar.fillAmount = player.hunger / player.maxHunger/1.0f;
        thirstBar.fillAmount = player.thirst / player.maxThirst/1.0f;
    }
}
