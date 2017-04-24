using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStatic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.Transform(Input.getAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	}
}
