using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class Patrol : MonoBehaviour {
    public EnemyState enemyState;
    public CircleCollider2D collider;
    public bool stop = false;

    public float min = 2f;
    public float max = 3f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 3;

    }

    void OnTriggerEnter2D(CircleCollider2D collider)
    {
        if (collider.gameObject.layer == LayerManager.playerActive)
            stop = true;
    }

    void OnTriggerExit2D(CircleCollider2D collider)
    {
        if (collider.gameObject.layer == LayerManager.playerActive)
            stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if enemy is not patrolling
        if (enemyState.getState() == State.patrolling && !false)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 0.4f, max - min) + min, transform.position.y, transform.position.z);
        } else if (enemyState.getState() == State.attacking && !false)
        {
            transform.Translate(new Vector2(enemyState.transform.position.x - transform.position.x, 0));
        }
       
    }
}
