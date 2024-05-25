using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 10f; 
    public float jumpImpulse = 20f; // The initial force applied when the character jumps

    public bool isGrounded;
    private AudioSource jumpAudioSource;

    private void Start()
    {
        jumpAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rgBody = GetComponent<Rigidbody>();
        
        // Apply horizontal acceleration to the Rigidbody's velocity
        rgBody.velocity += Vector3.right * horizontalMovement * Time.deltaTime * acceleration;
        
        // Check if the character is grounded using a Raycast
        // The character can only jump if it is grounded
        // Cast a ray from the character's position downward to check for ground collision
        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y + 0.03f;

        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * halfHeight;

        // Perform the raycast to check if the character is grounded
        isGrounded = Physics.Raycast(startPoint, Vector3.down, halfHeight);
        
        Color lineColor = (isGrounded) ? Color.red : Color.blue;
        Debug.DrawLine(startPoint, endPoint, lineColor, 1f, false);

        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            
            jumpAudioSource.Play();
            rgBody.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }
        else if (!isGrounded && Input.GetKey(KeyCode.Space))
        {
            if (rgBody.velocity.y > 0)
                rgBody.AddForce(Vector3.up * 2f, ForceMode.Force);
        }

        // Clamp the horizontal velocity to ensure it does not exceed the maximum speed
        if (Mathf.Abs(rgBody.velocity.x) > maxSpeed)
        {
            Vector3 newVelocity = rgBody.velocity;
            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
            rgBody.velocity = newVelocity;
        }

        // Rotate the character to face the direction of movement
        float yaw = (rgBody.velocity.x > 0) ? 90 : -90;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        float speed = Mathf.Abs(rgBody.velocity.x);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("Speed", speed);
        anim.SetBool("inAir", !isGrounded);
        
    }
}
