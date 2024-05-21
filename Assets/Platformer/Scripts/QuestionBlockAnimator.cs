using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockAnimator : MonoBehaviour
{
    public Material questionBlockMaterial;
    public float animationSpeed = 1f;
    public int currentTileIndex = 0;
    public float timer = 0f;

    void Start()
    {
        UpdateTileOffset();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= animationSpeed)
        {
            timer = 0f;
            currentTileIndex = (currentTileIndex + 1) % 5;
            UpdateTileOffset();
        }
    }

    void UpdateTileOffset()
    {
        float offsetY = 0.8f - currentTileIndex * 0.2f;
        questionBlockMaterial.mainTextureOffset = new Vector2(0f, offsetY);
    }
}
