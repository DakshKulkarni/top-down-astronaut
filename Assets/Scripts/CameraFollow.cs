using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // Assign Player Transform
    public float smoothSpeed = 0.125f;
    public Vector3 offset;           // Usually (0, 0, -10)

    public Vector2 minBounds;        // Set in Inspector
    public Vector2 maxBounds;        // Set in Inspector

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // Clamp camera within bounds
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, desiredPosition.z), smoothSpeed);
        transform.position = smoothedPosition;
    }
}
