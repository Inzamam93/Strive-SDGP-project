using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProjectile : MonoBehaviour {

    public float projectileAliveTime; //time for projectile to remain alive/in air
	// Use this for initialization
	void Start () {
        //Destroy the game object currently referenced in script, after a set loading time
        Destroy(gameObject, projectileAliveTime);
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
