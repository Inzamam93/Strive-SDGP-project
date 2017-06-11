using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {

    public float ratSpeed;

    public PlayerState player;

    Animator ratAnimator;

    //facing direction
    //public GameObject ratGraphic; //Attach basic enemy AI 

    /*if player enters or leaves the enemy's aggression zone
    enemy flips based on player's entry/exit from zone.
    *Note: This zone is represented by a collider in Killer Rat object.
    */
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f; //setting player to flip evry 5 seconds 
    float nextFlipChance = 0f; //flip immediately after flipTime

    //Rat Attacking
    public float chargeTime; //time to run/charge towards player
    float startChargeTime; //time to start charging. Set at timezone when player enters the enemy zone.
    bool charging; //true=charging , false=idle

    //Physics
    Rigidbody2D ratRb;

    // Use this for initialization
	void Start () {
        ratAnimator = GetComponentInChildren<Animator>();
        ratRb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//whether rat can flip 
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5) flipFacing();
            nextFlipChance = Time.time * flipTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if(player.isLit())
        //if (otherObj.tag == "Player")
            if (otherObj.gameObject.layer == LayerMask.NameToLayer("Player Active"))
                {
                if (facingRight && otherObj.transform.localScale.x < transform.position.x)
                {
                    flipFacing();
                }
                else if (!facingRight && otherObj.transform.position.x > transform.position.x)
                {
                    flipFacing();
                }
                //no more flipping. Already facing right direction
                canFlip = false;
                charging = true;
                startChargeTime = Time.time + chargeTime;
            }
    }

    private void OnTriggerStay2D(Collider2D otherObj)
    {
        if (player.isLit())
            /*if (otherObj.tag == "Player")*/
            if (otherObj.gameObject.layer==LayerMask.NameToLayer("Player Active")){
                if (startChargeTime < Time.time)
                {
                    //start chargin in current facing direction
                    if (!facingRight)
                    {
                        ratRb.AddForce(new Vector2(-1, 0) * ratSpeed);

                    }else
                    {
                        ratRb.AddForce(new Vector2(1, 0) * ratSpeed); 
                    }
                    ratAnimator.SetBool("isCharging", charging=true); //initiate rat movement animation
                }
            }
    }

    private void OnTriggerExit2D(Collider2D otherObj)
    {
            //if (otherObj.tag == "Player")
            if (otherObj.gameObject.layer == LayerMask.NameToLayer("Player Active"))
            {
                canFlip = true;
                charging = false;
                ratRb.velocity = new Vector2(0f, 0f);
                ratAnimator.SetBool("isCharging", charging = false);
            }
    }
    void flipFacing()
    {
            if (!canFlip)
            {
                return;
            }
        //float facingX = ratGraphic.transform.localScale.x;
        //facingX *= -1f;
        //ratGraphic.transform.localScale = new Vector3(facingX, 
        //    ratGraphic.transform.localScale.y, ratGraphic.transform.localScale.z);
        //facingRight = !facingRight;

        float facingX = transform.localScale.x;
        facingX *= -1f;
        transform.localScale = new Vector3(facingX,
            transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
}
