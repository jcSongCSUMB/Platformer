using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 

    private float initialY; 
    private float initialZ; 

    void Start()
    {
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, initialY, initialZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
    }
}

