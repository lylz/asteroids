using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public ScoreStorage ScoreStorage;

    [Header("UI Components")]
    public Text CurrentScoreText;
    public Text HighestScoreText;

    private void Update()
    {
        UpdateCurrentScore();
        UpdateHighestScore();
    }

    private void UpdateCurrentScore()
    {
        CurrentScoreText.text = ScoreStorage.CurrentScore.ToString("0");
    }

    private void UpdateHighestScore()
    {
        HighestScoreText.text = ScoreStorage.HighestScore.ToString("0");
    }
}
