using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //Contains information on whether the player is being lit by a light source, if the player is unlit, hiding somewhere, or has been spotted
    // Use this for initialization
    public Visibility initVisibility;
    public Audibility initAudibility;
    public Visibility visibility;
    public Audibility audibility;
    Rigidbody2D rigidbody;

    //initial visibility depends on the level therefore can be set in inspector
    void Start()
    {
        visibility = initVisibility;
        audibility = initAudibility;
        //test
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Hide();
    }

    public Visibility getVisibility()
    {
        return visibility;
    }
    public Audibility getAudiblity()
    {
        return audibility;
    }
    //Audibility can be set through these methods
    public void setVisibility(Visibility newVisibility)
    {
        visibility = newVisibility;
    }

    public void setAudibility(Audibility newAudibility)
    {
        audibility = newAudibility;
    }

    public void Hide()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            setVisibility(Visibility.Hidden);
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    //****TESTING METHOD *** remove
    void Move()
    {
        rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 20);
    }
}

    

//Lit player can be spotted as long as the raycast hits him.
//Unlit players cannot be seen unless the player is within a certain range
//Hidden players cannot be seen. Players can hide behind trees etc. (Possible to change the players layer to avoid raycast hitting?)
    //What about raycasts hitting the other objects in the background? (Will having multiple layers solve?)
public enum Visibility
{
    Lit,
    Unlit,
    Hidden,
    Spotted
}

public enum Audibility
{
    silent,
    running,
}

enum Location
{

}