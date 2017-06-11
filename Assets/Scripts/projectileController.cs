using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
    //Main Projectile Control code
    //Declaration of variables
    public float projectileSpeed;
    Rigidbody2D projectileRB;
    // Use this for initialization
    //Using the awake function instead of start to ensure function executes when object first comes to life
    void Awake()
    {
        //looking for rigid body 2d existing on current object
        projectileRB = GetComponent<Rigidbody2D>();

        /*
         * ForceMode2D.Impulse: Add an instant force impulse to the rigidbody2D, using its mass.
         * This mode is useful for applying forces that happen instantly, such as forces from explosions or collisions.
         */
        if (transform.localRotation.z > 0) //if there is rotation on z axis
        {
            projectileRB.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse); //setting rigid body to move in x axis only.
        }
        else
        {
            projectileRB.AddForce(new Vector2(-1, 0) * projectileSpeed, ForceMode2D.Impulse);
        }

    }


    //Method to stop object from moving completely.Removes all forces in rigidbody.
    public void removeForce()
    {
        projectileRB.velocity = new Vector2(0, 0); //setting x to 0, to stop rigid body movement
    }
}
