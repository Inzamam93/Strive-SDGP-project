using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class StreetLight : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        //filtering out everyone other than the player
        if (collider.gameObject.layer == LayerManager.playerActive)
        {
            PlayerState playerState = collider.gameObject.GetComponent<PlayerState>();
            playerState.SetLit(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //filtering out everyone other than the player
        if (collider.gameObject.layer == LayerManager.playerActive)
        {
            PlayerState playerState = collider.gameObject.GetComponent<PlayerState>();
            playerState.SetLit(false);
        }
    }
}
