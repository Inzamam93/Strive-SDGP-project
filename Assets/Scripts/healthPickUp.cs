using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour {

    public float healthBoost;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.gameObject.layer==LayerMask.NameToLayer("Player Active"))
        {
            playerHealth player_health = otherObj.gameObject.GetComponent<playerHealth>();
            player_health.addHealth(healthBoost);
            Destroy(gameObject); //destroy object after player collider contacts pickUp's collider
        }
    }
}
