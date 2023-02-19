using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 CameraOffset;

    public float FollowSpeed;
    public float xMin;

    Vector3 velocity =  Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position + CameraOffset;
        Vector3 clamedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clamedPos, ref velocity, FollowSpeed * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}

//public Transform target;

//public float smoothSpeed = 0.125f;
//public Vector3 offset;

//private void LateUpdate()
//{
//Vector3 desiredPosition = target.position + offset;
// Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, smoothSpeed);
//transform.position = smoothPosition;

// This part is optional
//transform.LookAt(target);

// One thing I need to do with this code is change it too LateUpdate and the Vector3.lerp to Vector3.SmoothDamp
// (This would help with jitter and overload)
//}
