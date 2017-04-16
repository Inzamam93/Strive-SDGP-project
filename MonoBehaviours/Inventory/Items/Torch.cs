using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Torch : UsableItemFunctionality {
    public bool inView;
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        //if the light trigger) is falling on an enemy
        GameObject player = FindObjectOfType<Player> ().gameObject;

       
        //if enemy is facing you, he should be stunned?
    }

	// Update is called once per frame
	void Update () {
		
	}
    
    public override void functionality()
    {
        Player player = GetComponent<Player>();

        //ADD this functionality to the player class
        //player.setHidden(true);
        

    }
}
