using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    public float damage;
    public float damageRate; //How often damage ocurs
    public float pushBackForce; //Push player away upon contact
    playerHealth player_health;
    float nextDamage; //Next time damage occurs
	// Use this for initialization
	void Start () {
        /*nextDamage=0 means player can be damaged immediately after initial damage
         * nextDamage=Time.time means player can receive damage whenever we start/object first comes to life.
         */
        nextDamage = 0f; 
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Player should be damaged only when in contact with enemy's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        //if (other.gameObject.layer == LayerMask.NameToLayer("Player Active") && nextDamage < Time.time)
        {
            player_health = other.gameObject.GetComponent<playerHealth>();
            player_health.addDamage(damage);
            nextDamage = Time.time + damageRate;
           
            pushBack(other.transform);  //pushing object, other's transform away from enemy
        }
    }

    void pushBack(Transform pushedObject)
    {
        //direction of player push
        Vector2 pushDirection = new Vector2(0, pushedObject.position.y - transform.position.y).normalized;
        //Vector2 pushDirection = new Vector2(pushedObject.position.x - transform.position.x, 0).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushedRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushedRB.velocity = Vector2.zero;
        pushedRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
