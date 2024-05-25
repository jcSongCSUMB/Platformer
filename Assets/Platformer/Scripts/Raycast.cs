using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameManager gameManager;
    public float raycastDistance = 1.1f; // Adjust this distance based on your block size and Mario's jump height
    
    void Start()
    {
        // Find the GameManager object and get the GameManager component
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Debug.Log("Mario is jumping.");
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hitInfo;

        // Perform the raycast
        if (Physics.Raycast(ray, out hitInfo, raycastDistance))
        {
            Debug.Log($"Raycast hit: {hitInfo.collider.gameObject.name} at distance {hitInfo.distance}.");

            if (hitInfo.collider.gameObject.name == "Test Brick(Clone)")
            {
                Destroy(hitInfo.collider.gameObject);
                gameManager.AddScore(150);
                Debug.Log("Destroyed a Test Brick and added 150 points.");
            }
            else if (hitInfo.collider.gameObject.name == "Test QuestionBox(Clone)")
            {
                gameManager.AddScore(1000);
                Debug.Log("Hit a Test QuestionBox and added 1000 points.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }
    
}

