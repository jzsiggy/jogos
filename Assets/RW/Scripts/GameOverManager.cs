using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        UpdateHighScoreText();
    }

    private void UpdateHighScoreText()
    {
        int highScore = ScoreManager.highScore;
        highScoreText.text = $"High Score: {highScore}";
    }
}