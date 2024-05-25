using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI statusText;

    public AudioSource gameOverAudioSource;
    public AudioSource stageClearAudioSource;

    private int score = 0;
    private bool isGameOver = false;
    private bool isStageClear = false;

    void Update()
    {
        if (!isGameOver && !isStageClear)
        {
            int intTime = 100 - (int)Time.realtimeSinceStartup;

            if (intTime <= 0)
            {
                intTime = 0;
                TriggerGameOver();
            }

            string timeStr = $"Time: {intTime}";
            timeText.text = timeStr;
        }
    }

    public void AddScore(int points)
    {
        if (!isGameOver && !isStageClear)
        {
            score += points;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"MARIO\n{score.ToString("D6")}";
    }

    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            statusText.text = "Game Over";
            gameOverAudioSource.Play();
            StartCoroutine(ClearStatusTextAfterDelay(5));
            Debug.Log("Game Over");
        }
    }

    public void TriggerStageClear()
    {
        if (!isStageClear)
        {
            isStageClear = true;
            statusText.text = "Stage Clear";
            stageClearAudioSource.Play();
            Debug.Log("Stage Clear");
        }
    }

    private IEnumerator ClearStatusTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        statusText.text = "";
    }
}
