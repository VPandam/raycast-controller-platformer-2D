using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller : MonoBehaviour
{
    BoxCollider2D playerCollider;

    //Position of the corners of our collider.
    RaycastOrigins raycastOrigins;

    //We want to fire the rays from a small space inside the player bounds.
    const float skinWidth = .015f;

    //Number of rays
    [SerializeField] int horizontalRayCount = 4;
    [SerializeField] int verticalRayCount = 4;

    //Space between rays, changes depending of the number of rays.
    float horizontalRaySpacing, verticalRaySpacing;
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.bottomRight + Vector2.up * horizontalRaySpacing * i, Vector2.right * 2, Color.red);
        }
        for (int i = 0; i < verticalRayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.down * 2, Color.red);
        }

    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = playerCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = playerCollider.bounds;
        bounds.Expand(skinWidth * -2);

        //We want our rayCount to be always minimum 2
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.x / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.y / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight, bottomLeft, bottomRight;
    }




}
