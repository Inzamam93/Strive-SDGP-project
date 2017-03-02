using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public bool grounded;
    //public Vector2 velocity;
    public Rigidbody2D rb2D;
    bool facingRight;
    Animator anim;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //facingRight = true;
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        // rb2D.AddForce((Vector2.right*speed)*h);
        anim.SetFloat("walkSpeed", Mathf.Abs(move));

        rb2D.velocity=new Vector2(move* walkSpeed, rb2D.velocity.y);

        if(move<0 && !facingRight)
        {
            flip();
        }
        else if (move>0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }

}
