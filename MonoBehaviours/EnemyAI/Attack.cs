using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public GameObject target;
    public float weaponRange;
    public PlayerAttributes playerAttributes;
    public PlayerState playerState;
    public bool attacking;

	// Use this for initialization
	void Start () {
        playerAttributes = target.GetComponent<PlayerAttributes>();
        playerState = target.GetComponent<PlayerState>();
        attacking = false;
	}
	bool inRange(float weaponRange = 0)
    {
        return Vector3.Distance(target.transform.position, transform.position) < weaponRange;
    }
    void Melee(float damage)
    {
        //if (playerState = Visibility.Hidden)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position);
        if (hit.collider != null && hit.collider.gameObject.Equals(target))
        {
            playerAttributes.IncrementHealth(damage);
            if (!attacking)
            {

            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
