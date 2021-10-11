public interface IScoreStorage
{
    public int CurrentScore { get; }
    public int HighestScore { get; }

    public void SetCurrentScore(int score);
    public void SetHighestScore(int score);
}
