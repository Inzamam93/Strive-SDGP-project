using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]

public class Player : PlayerAttributes {
    //isLit is true when the player is underneath a light sources trigger or is using his torch
    //Note that isLit just reduces the distance at which the player can be spotted. The player can still be spotted or heard

    //isHidden is true when the player is hiding somewhere and cannot be spotted
    bool isLit = true;
    bool isHidden = true;
    bool isSpottable = true;
    Controller2D controller;
	void Start () {
        controller = GetComponent<Controller2D> ();
	}
	
}
