using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Waypoint : MonoBehaviour {
    public Vector2 location;
    public Waypoint next;
    public Waypoint previous;
    bool jumpNext;
    bool jumpPrev;

    void Update()
    {
        location = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (jumpNext && collider.gameObject.layer == LayerManager.enemies)
        {
            //collider.gameObject.GetComponent<EnemyState>().Jump(next.location - location);
        }
        else if (jumpNext && collider.gameObject.layer == LayerManager.enemies)
        {
            //collider.gameObject.GetComponent<EnemyState>().Jump(next.location - location);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(location, new Vector3(.3f,.3f,.3f));
        if (next != null)
            Gizmos.DrawLine(location, next.location);
    }
}
