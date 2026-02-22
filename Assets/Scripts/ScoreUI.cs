using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int currentScore;

    public void AddScore(int value)
    {
        currentScore += value;
        scoreText.text = "Score: " + currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
        scoreText.text = "Score: 0";
    }
}