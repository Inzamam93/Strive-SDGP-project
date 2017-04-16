using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerAttributes : MonoBehaviour {
    //script that is put on OTHER game objects that can affect the players stats
    public float healthIncrement;
    public float staminaIncrement;
    public float hungerIncrement;
    public float thirstIncrement;
    public float warmthIncrement;

    public bool continousDecrement;

	// Use this for initialization

    void Update()
    {

    }

    void OnTriggerStay2D (Collider2D collider)
    {
        /*
        if (continousDecrement)
        {
            PlayerAttributes player = collider.gameObject.GetComponent<PlayerAttributes>();
            player.stamina = Mathf.Clamp(staminaIncrement + player.stamina * Time.deltaTime, 0, player.maxStamina);
            player.health = Mathf.Clamp(healthIncrement + player.health * Time.deltaTime, 0, player.maxHealth);
            player.hunger = Mathf.Clamp(healthIncrement + player.hunger * Time.deltaTime, 0, player.maxHunger);
            player.thirst = Mathf.Clamp(healthIncrement + player.thirst * Time.deltaTime, 0, player.maxThirst);
            player.warmth = Mathf.Clamp(healthIncrement + player.warmth * Time.deltaTime, 0, player.maxWarmth);
        }
        */
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        Debug.Log("Entered");
        /*
        if (!continousDecrement)
        {
            PlayerAttributes player = collider.gameObject.GetComponent<PlayerAttributes>();
            player.stamina = Mathf.Clamp(staminaIncrement + player.stamina, 0, player.maxStamina);
            player.health = Mathf.Clamp(healthIncrement + player.health, 0, player.maxHealth);
            player.hunger = Mathf.Clamp(healthIncrement + player.hunger, 0, player.maxHunger);
            player.thirst = Mathf.Clamp(healthIncrement + player.thirst, 0, player.maxThirst);
            player.warmth = Mathf.Clamp(healthIncrement + player.warmth, 0, player.maxWarmth);
            player.health = 40;
            Debug.Log(healthIncrement);
        }

        */
    }


}
