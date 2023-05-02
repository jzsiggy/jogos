using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int highScore = 0;
    public float scoreIncreaseRate = 1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private float timeSinceLastScoreUpdate;

    void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
    }

    void Update()
    {
        timeSinceLastScoreUpdate += Time.deltaTime;

        if (timeSinceLastScoreUpdate >= 0.1f)
        {
            IncreaseScore((int)scoreIncreaseRate);
            timeSinceLastScoreUpdate = 0f;
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreText();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}