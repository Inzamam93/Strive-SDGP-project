using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {
    public float maxPlayerHealth;
    float currentHealth;
    Player playerControl;
    public GameObject deathFX;
	// Use this for initialization
	void Start () {
        currentHealth = maxPlayerHealth;

        playerControl = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            playerDie();
        }
    }

    public void playerDie()
    {
        //Instantiate( object to be instantiated, where/location to instantiate, rotation of object) 
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    } 
}
