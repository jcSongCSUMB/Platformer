using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log($"{hitInfo.collider.gameObject.name} is clicked.");

                if (hitInfo.collider.gameObject.name == "Test Brick(Clone)")
                {
                    Destroy(hitInfo.collider.gameObject);
                    gameManager.AddScore(150);
                }
                else if (hitInfo.collider.gameObject.name == "Test QuestionBox(Clone)")
                {
                    gameManager.AddScore(1000);
                }
            }
        }
    }
}

