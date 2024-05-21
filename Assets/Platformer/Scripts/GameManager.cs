using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Update()
    {
        // Update the countdown timer
        int intTime = 360 - (int)Time.realtimeSinceStartup;
        string timeStr = $"Time: {intTime}";
        timeText.text = timeStr;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Update the score text with "MARIO" and the score in 6-digit format
        scoreText.text = $"MARIO\n{score.ToString("D6")}";
    }
}

