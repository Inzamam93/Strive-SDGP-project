using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemydeathFX;

    //Related to items on enemy death
    public bool itemAvailable; //if true, Item pick up is available
    public GameObject droppedItem;

    //HUD variables
    public Slider enemyHealthBar; //Attach enemy health bar slider in inspector

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;

        //enemyHealthBar.maxValue = enemyMaxHealth;
        //enemyHealthBar.value = currentHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Method to allow enemy to receive damage
    public void addDamage(float damage)
    {
        enemyHealthBar.maxValue = currentHealth;
        enemyHealthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            enemyDie();
        }
    }

    void enemyDie()
    {
        Destroy(gameObject);
        Instantiate(enemydeathFX, transform.position, transform.rotation);
        if (itemAvailable == true)
        {
            Instantiate(droppedItem, transform.position, transform.rotation);
        }
    }
}
