using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //walk variables
    public float walkSpeed;
    public float runSpeed;
    //jump variables
    public float jumpSpeed;
    public bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    
    public Rigidbody2D rb2D;
    bool facingRight;
    Animator anim;



    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //facingRight = true;
       // rb2D.freezeRotation = true;
    }


    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            //grounded in animator parameter
            anim.SetBool("grounded", grounded);
            rb2D.AddForce(new Vector2(0, jumpHeight));

        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        // check if character is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, groundLayer);//drawing a circle and checking if it intersects ground.
        //if false, then player is falling
        anim.SetBool("grounded", grounded);

        anim.SetFloat("verticalVelocity", rb2D.velocity.y);

        float move = Input.GetAxis("Horizontal");
      
        // rb2D.AddForce((Vector2.right*speed)*h);
        anim.SetFloat("walkSpeed", Mathf.Abs(move));
        anim.SetBool("jumpSpeed", grounded);
        rb2D.velocity=new Vector2(move* walkSpeed, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(Vector2.up * jumpSpeed);
        }

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
