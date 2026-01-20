using UnityEngine;

[DefaultExecutionOrder(1000)]
public class SmoothAxis : MonoBehaviour
{
    [Header("Follow Targets")]
    public Transform target;
    public Vector3 positionOffset = Vector3.zero;
    public float positionSmooth = 5f;

    [Header("Rotation Settings")]
    public float rotationSmooth = 5f;

    [Tooltip("Enable to follow rotation fully, except locked axes")]
    public bool followRotation = true;

    [Header("Axis Locks")]
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    public float targetAngleX = 0f;
    public float targetAngleY = 0f;
    public float targetAngleZ = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position + positionOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, positionSmooth * Time.deltaTime);

        if (followRotation)
        {
            Vector3 targetEuler = target.rotation.eulerAngles;

            if (lockX) targetEuler.x = targetAngleX;
            if (lockY) targetEuler.y = targetAngleY;
            if (lockZ) targetEuler.z = targetAngleZ;

            Quaternion desiredRotation = Quaternion.Euler(targetEuler);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmooth * Time.deltaTime);
        }
    }
}
