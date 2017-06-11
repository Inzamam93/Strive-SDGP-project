using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileRockHit : MonoBehaviour
{

    public projectileController projectile_controller; //reference to projectileController.cs
    public float rockDamage; //default weapon consist of rocks. 
    public GameObject shatterEffect;
    EnemyHealth hurtEnemy;
    // Use this for initialization
    void Awake()
    {
        //object referencing projectileController (parent)
        projectile_controller.GetComponentInParent<projectileController>();

    }
 

    //method to find out when colliders touch each other
    //when projectile's collider collides with other object's collider
    void OnTriggerEnter2D(Collider2D other)
    {
        //if other object's layer is set to shootable
       
        //if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        if (other.tag=="Shootable")
        {
            //stop projectile movement to mimic a collision
            projectile_controller.removeForce();
            //Instantiate( object to be instantiated, where/location to instantiate, rotation of object) 
            //instantiate shatter effect after collision at the current x,y,z position(transform.position)
            Instantiate(shatterEffect, transform.position, transform.rotation); //transform.rotation= rotation of projectile
            Destroy(gameObject); //destroying projectile rock object(i.e the child object and not the parent). After destruction, only child object is destroyed.
        }
        //if an enemy is detected via tag, hurt enemy
        //if (other.tag == "Enemy")
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
            //call function from EnemyHealth script to add damage
            hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.addDamage(rockDamage);
        }
    }

    //This is a safe guard, in case rock cannot find initial contact
    //Will be useful when adding calculated damage
    void OnTriggerStay2D(Collider2D other)
    {
        //copy of OnTriggerEnter2D method code
        //if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
            if (other.tag == "Shootable")
            {
            projectile_controller.removeForce();
            Instantiate(shatterEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //if an enemy is detected via tag, hurt enemy
        //if (other.tag == "Enemy")
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
            //call function from EnemyHealth script to add damage
            hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.addDamage(rockDamage);
        }
    }

}
