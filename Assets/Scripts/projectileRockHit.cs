using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileRockHit : MonoBehaviour {
    //reference to projectileController.cs
    public projectileController projectile_controller; //Ensure projectileController.cs is attached in inspector @ projectile_controller
    public float rockDamage;
    public GameObject shatterEffect;
	// Use this for initialization
	void Awake () {
        //object referencing projectileController (parent)
        projectile_controller.GetComponentInParent<projectileController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    //method to find out when colliders touch each other
    //when projectile's collider collides with other object's collider
    void OnTriggerEnter2D(Collider2D other)
    {
        //if other object's layer is set to shootable
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            //stop projectile movement to mimic a collision
            projectile_controller.removeForce();
            //instantiate shatter effect after collision at the current x,y,z position(transform.position)
            Instantiate(shatterEffect, transform.position, transform.rotation); //transform.rotation= rotation of projectile
            Destroy(gameObject); //destroying projectile rock object(i.e the child object and not the parent). After destruction, only child object is destroyed.
        }
    }

    //in case rock cannot find initial contact
    private void OnTriggerStay2D(Collider2D other)
    {
        //copy of OnTriggerEnter2D method code
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            projectile_controller.removeForce();     
            Instantiate(shatterEffect, transform.position, transform.rotation); 
            Destroy(gameObject); 
        }
    }
}
