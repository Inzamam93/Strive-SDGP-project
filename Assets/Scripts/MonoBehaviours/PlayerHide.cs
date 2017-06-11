using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour {
    public KeyCode keyCode;
    public Collider2D targetCollider;

	// Update is called once per frame
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider == targetCollider && collider.gameObject.layer == LayerManager.playerActive)
        {
            if (Input.GetKey(keyCode))
            {
                collider.gameObject.layer = LayerManager.playerHidden;
            }
        }
    }
}
