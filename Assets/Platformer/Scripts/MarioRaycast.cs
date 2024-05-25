using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioRaycast : MonoBehaviour
{
    private GameManager gameManager;
    public float raycastDistance = 2.0f;
    public float cooldownTime = 0.5f;
    public float destructionDelay = 0.05f; // Delay before the brick is destroyed
    public float animationHeight = 0.5f; // Height to move the question box up
    public float animationSpeed = 0.1f; // Speed of the animation

    private bool isOnCooldown = false;
    private AudioSource brickDestroyAudioSource;
    private AudioSource questionBoxAudioSource;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        if (isOnCooldown)
        {
            return;
        }
        
        if (IsJumping())
        {
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo, raycastDistance))
            {
                if (hitInfo.collider.gameObject.name == "Test Brick(Clone)")
                {
                    brickDestroyAudioSource = hitInfo.collider.gameObject.GetComponent<AudioSource>();
                    brickDestroyAudioSource.Play();
                    StartCoroutine(DestroyBrickAfterDelay(hitInfo.collider.gameObject));
                    gameManager.AddScore(100);
                    StartCoroutine(Cooldown());
                }
                else if (hitInfo.collider.gameObject.name == "Test QuestionBox(Clone)")
                {
                    questionBoxAudioSource = hitInfo.collider.gameObject.GetComponent<AudioSource>();
                    questionBoxAudioSource.Play();
                    gameManager.AddScore(100);
                    StartCoroutine(AnimateQuestionBox(hitInfo.collider.gameObject));
                    StartCoroutine(Cooldown());
                }
            }
        }
    }

    private bool IsJumping()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        bool isJumping = rb.velocity.y > 0;
        return isJumping;
    }

    private IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    private IEnumerator DestroyBrickAfterDelay(GameObject brick)
    {
        yield return new WaitForSeconds(destructionDelay);
        Destroy(brick);
    }

    private IEnumerator AnimateQuestionBox(GameObject questionBox)
    {
        Vector3 originalPosition = questionBox.transform.position;
        Vector3 targetPosition = originalPosition + Vector3.up * animationHeight;
        
        // Move up
        float elapsedTime = 0f;
        while (elapsedTime < animationSpeed)
        {
            questionBox.transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / animationSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Ensure it's exactly at the target position
        questionBox.transform.position = targetPosition;

        // Move back down
        elapsedTime = 0f;
        while (elapsedTime < animationSpeed)
        {
            questionBox.transform.position = Vector3.Lerp(targetPosition, originalPosition, (elapsedTime / animationSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure it's exactly at the original position
        questionBox.transform.position = originalPosition;
    }
}


