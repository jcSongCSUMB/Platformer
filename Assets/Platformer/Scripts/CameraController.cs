using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * scrollSpeed * Time.deltaTime, 0, 0);
        transform.position = newPosition;
    }
}

