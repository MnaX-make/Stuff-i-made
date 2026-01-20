using UnityEngine;

public class logo_move : MonoBehaviour
{
    public Camera targetCamera;

    public float distanceFromCamera = 5f;   // How far in front of the camera
    public float positionSmooth = 2f;       // Lower = slower movement
    public float rotationSmooth = 2f;       // Lower = slower rotation

    void LateUpdate()
    {
        if (targetCamera == null) return;

        // Target position: center of the camera view
        Vector3 targetPos =
            targetCamera.transform.position +
            targetCamera.transform.forward * distanceFromCamera;

        // Smooth position
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            positionSmooth * Time.deltaTime
        );

        // Target rotation: face the same direction as the camera
        Quaternion targetRot = targetCamera.transform.rotation;

        // Smooth rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRot,
            rotationSmooth * Time.deltaTime
        );
    }
}
