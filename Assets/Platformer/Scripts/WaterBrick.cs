using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBrick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is Mario
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.TriggerGameOver();
        }
    }
}

