using UnityEngine;

[CreateAssetMenu(menuName = "Game/Score Storage")]
public class ScoreStorage : ScriptableObject, IScoreStorage
{
    public int currentScore = 0;
    public int highestScore = 0;

    public int CurrentScore { get => currentScore; }
    public int HighestScore { get => highestScore; }

    public void SetCurrentScore(int score)
    {
        currentScore = score;
    }

    public void SetHighestScore(int score)
    {
        highestScore = score;
    }
}
