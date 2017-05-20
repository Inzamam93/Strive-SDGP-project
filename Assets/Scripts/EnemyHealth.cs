using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float enemyMaxHealth;
    float currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Method to allow enemy to receive damage
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            enemyDie();
        }
    }

    void enemyDie()
    {
        Destroy(gameObject);
    }
}
