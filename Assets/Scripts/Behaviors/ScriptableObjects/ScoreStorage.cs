using UnityEngine;

[CreateAssetMenu(menuName = "Game/Score Storage")]
public class ScoreStorage : ScriptableObject, IScoreStorage
{
    private int _currentScore = 0;
    private int _highestScore = 0;

    public int CurrentScore { get => _currentScore; }
    public int HighestScore { get => _highestScore; }

    public void SetCurrentScore(int score)
    {
        _currentScore = score;
    }

    public void SetHighestScore(int score)
    {
        _highestScore = score;
    }
}
