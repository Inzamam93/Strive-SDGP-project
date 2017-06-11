using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //Contains information on whether the player is being lit by a light source, if the player is unlit, hiding somewhere, or has been spotted
    // Use this for initialization
    public Visibility visibility;
    public Audibility audibility;

    public int hiddenPlayerLayer;
    public int playerLayer; 

    [SerializeField]
    bool lit;
    [SerializeField]
    bool hidden;
    [SerializeField]
    bool spotted;

    public void SetLit(bool lit)
    {
        this.lit = lit;
        //even if the player is lit, his state is not truly lit if the player is hidden, therefore the state wont change
        visibility = Visibility.Lit;
    }

    public void SetHidden(bool hidden)
    {
        //the player can only hide if he is not spotted
        //spotted: if player is in sight, he can run away from range/cut off line off sight behind another collider and then hide
        //(note that cutting off line of sight and hiding are not the same)
        if (!spotted)
        {
            this.hidden = hidden;
            gameObject.layer = LayerManager.playerHidden;
        }
        //if player is to be set to unhidden his layer must be changed back to playerActive
        if (!hidden)
        {
            gameObject.layer = LayerManager.playerActive;
        }
    }


    public void SetSpotted(bool spotted)
    {
        this.spotted = spotted;
    }

    public bool isLit()
    {
        return lit;
    }
    public bool isHidden()
    {
        return hidden;
    }
    public bool isSpotted()
    {
        return spotted;
    }

    public string location;
    Rigidbody2D rigidbody;

    //initial visibility depends on the level therefore can be set in inspector
    void Start()
    {
        //test
        rigidbody = GetComponent<Rigidbody2D>();
    }


}

    

//Lit player can be spotted as long as the raycast hits him.
//Unlit players cannot be seen unless the player is within a certain range
//Hidden players cannot be seen. Players can hide behind trees etc. (Possible to change the players layer to avoid raycast hitting?)
    //What about raycasts hitting the other objects in the background? (Will having multiple layers solve?)
public enum Visibility
{
    Lit,
    Unlit
}

public enum Audibility
{
    silent,
    running,
}