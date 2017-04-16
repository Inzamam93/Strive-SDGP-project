using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class StreetLight : MonoBehaviour {
    PolygonCollider2D collider;
    public LayerMask layer;

    //retrieving the polygon collider
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //filtering out everyone other than the player
        if (collider.gameObject.CompareTag ("Player") )
        {
            //if player is not hidden -> set to Lit
            PlayerState playerState = collider.gameObject.GetComponent<PlayerState>();
            Debug.Log("Player was :"+ playerState.visibility);
            if (playerState.getVisibility() != Visibility.Hidden)
            {
                playerState.setVisibility(Visibility.Lit);
            }
            Debug.Log("Player was changed to: " + playerState.visibility);
        }
       
    }

    //checking constantly incase player was hidden halfway through and then became unhidden
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //As long as the player is not hidden, set the visibility to Hidden
            PlayerState playerState = collider.gameObject.GetComponent<PlayerState>();
            if (playerState.getVisibility() != Visibility.Hidden)
            {
                playerState.setVisibility(Visibility.Lit);
            }
        }
    }
}
