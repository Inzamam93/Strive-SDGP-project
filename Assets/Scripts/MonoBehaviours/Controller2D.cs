using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PolygonCollider2D))]
public class Controller2D : MonoBehaviour {

    public const float SkinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    PolygonCollider2D collider;
    RaycastOrigins raycastOrigins;

	void Start ()
    {
        collider = GetComponent<PolygonCollider2D> ();
        UpdateRaycastOrigins();
	}
	
    void Update()
    {
        //Updating raycast origins struct reference and calculating rayspacing in each frame
        UpdateRaycastOrigins ();
        CalculateRaySpacing();

        //Drawing the red raycast lines
        for (int i = 0; i < verticalRayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + i * new Vector2(horizontalRaySpacing, 0), Vector2.up * -2, Color.red);
        }
    }
    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        //reduces skinwidth from all sides
        bounds.Expand(SkinWidth * -2);

        //setting the positions in the structure reference
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    void CalculateRaySpacing ()
    {
        Bounds bounds = collider.bounds;
        //reduces skinwidth from all sides
        bounds.Expand(SkinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.x / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.y / (verticalRayCount - 1);
    }
    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
