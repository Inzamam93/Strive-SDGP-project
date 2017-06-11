using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public EnemyState enemy;
    public Vector3 speedRot;
    public Transform target;
    public float speed;
    public float attackSpeed;
    public bool stop;
    public float dist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(target.position, transform.position) > dist)
        {
            if (enemy.getState() == State.vigilant)
            {
                transform.Rotate(speedRot * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            if (enemy.getState() == State.attacking)
            {
                transform.Rotate(speedRot * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, target.position, attackSpeed * Time.deltaTime);
            }
        } else 
            Debug.Log("Too Close");
        
	}

}
