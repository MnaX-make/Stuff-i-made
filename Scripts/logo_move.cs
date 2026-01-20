// this script makes a logo show up in the cam like Gorilla Tag start menu
using UnityEngine;

public class logo_move : MonoBehaviour
{
    public Camera targetCamera;

    public float distanceFromCamera = 5f;
    public float positionSmooth = 2f;
    public float rotationSmooth = 2f;

    void LateUpdate()
    {
        if (targetCamera == null) return;
        
        Vector3 targetPos =
            targetCamera.transform.position +
            targetCamera.transform.forward * distanceFromCamera;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            positionSmooth * Time.deltaTime
        );

        Quaternion targetRot = targetCamera.transform.rotation;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRot,
            rotationSmooth * Time.deltaTime
        );
    }
}

