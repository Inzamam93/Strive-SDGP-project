using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    public float maxPlayerHealth;
    float currentHealth;
    Player playerControl;
    public GameObject deathFX;

    //HUD variables
    public Slider healthBar;
    public Image damageScreen;

    //damage indicator/damage screen variables
    bool damaged;
    Color damagedColor = new Color(255f, 255f, 255f, 0.5f);
    float smoothColor = 5f;

    respawn respawnAt;
    //public int respawnSceneNo;
    // Use this for initialization
    void Start () {
        currentHealth = maxPlayerHealth;

        playerControl = GetComponent<Player>();

        //Initialising HUD values
        healthBar.maxValue = maxPlayerHealth; //maximum possible health
        healthBar.value = maxPlayerHealth; //current health value

        damaged = false;

        respawnAt = FindObjectOfType<respawn>();
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged)
        {
            damageScreen.color = damagedColor;
        }else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
	}
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthBar.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0)
        {
            playerDie();

        }
    }

    //For health pick up
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxPlayerHealth)
        {
            currentHealth = maxPlayerHealth;
        }
        healthBar.value = currentHealth;
    }

    public void playerDie()
    {
        //Instantiate( object to be instantiated, where/location to instantiate, rotation of object) 
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        damageScreen.color = damagedColor;
        respawnAt.restartLevel();
    } 
}
