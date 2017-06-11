using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //walk variables
    [SerializeField] //In keeping with Object Oriented Practice. This makes the variable available in the Inspector view as well.
    float walkSpeed;
    
    //jump variables   
    bool grounded = false;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    [SerializeField]
    float jumpHeight;

    //shoot variables
    public GameObject projectile;
    public Transform shootPoint; //transforming the projectile object at the tip
    float fireRate = 1f; //Shoot one projectile every half a second
    float nextFire=2f; //Setting player to be able to fire immediately after firing once

    //2D physics object
    Rigidbody2D rb2D; 

    //player's direction
    bool facingRight;

    //Reference to the game engine animator to invoke 2D animations
    Animator anim;



    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        //jump code 
        //if (grounded && Input.GetAxis("Jump") > 0)
        if (grounded==true && Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            //setting grounded in animator parameter
            anim.SetBool("grounded", grounded);
            rb2D.AddForce(new Vector2(0, jumpHeight));
         
        }

        //player shooting
        //GetAxisRaw gets value of either - 1,0 or 1
        //if (Input.GetAxisRaw("Fire1") > 0) //fire1=left mouse btn 
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        // check if character is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, groundLayer);//drawing a circle and checking if it intersects ground.
        //if false, then player is falling
        anim.SetBool("grounded", grounded);
        anim.SetFloat("verticalVelocity", rb2D.velocity.y);

        //Move object through x - axis
        float move = Input.GetAxis("Horizontal");
      
        // rb2D.AddForce((Vector2.right*speed)*h);
        anim.SetFloat("walkSpeed", Mathf.Abs(move));
        anim.SetBool("jumpSpeed", grounded);
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

    //Controlling player's facing direction
    void flip()
    {
        facingRight = !facingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }

    //Method to shoot/fire 
    public void shoot()
    {
        //if current time is greater than time of next fire => fire
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
        }
        if (facingRight)
        {
            //Instantiate( object to be instantiated, where/location to instantiate, rotation of object) 
            //Quaternion : avoiding x,y or z axis lock 
            Instantiate(projectile, shootPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else if (!facingRight)
        {
            //using quaternion euler to rotate via angle in degrees
            Instantiate(projectile, shootPoint.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
        }
    }
}
