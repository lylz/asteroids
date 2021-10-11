public interface IScoreManager
{
}

public class ScoreManager : IScoreManager
{
    private IScoreStorage _scoreStorage;
    private IGameEvents _gameEvents;
    private IEnemyEvents _enemyEvents;
    private IPlayerEvents _playerEvents;

    public ScoreManager(
        IScoreStorage scoreStorage,
        IGameEvents gameEvents,
        IEnemyEvents enemyEvents,
        IPlayerEvents playerEvents
    )
    {
        _gameEvents = gameEvents;
        _scoreStorage = scoreStorage;
        _enemyEvents = enemyEvents;
        _playerEvents = playerEvents;

        _gameEvents.GameExit += OnGameExit;
        _enemyEvents.EnemyDestroyed += OnEnemyDestroyed;
        _playerEvents.PlayerDied += OnPlayerDied;

        _scoreStorage.SetCurrentScore(0);
    }

    ~ScoreManager()
    {
        _gameEvents.GameExit -= OnGameExit;
        _enemyEvents.EnemyDestroyed -= OnEnemyDestroyed;
        _playerEvents.PlayerDied -= OnPlayerDied;
    }

    private void OnGameExit()
    {
        SetHighScore();
    }

    private void OnEnemyDestroyed(IEnemy enemy)
    {
        _scoreStorage.SetCurrentScore(_scoreStorage.CurrentScore + enemy.ScorePoints);
    }

    private void OnPlayerDied()
    {
        SetHighScore();
    }

    private void SetHighScore()
    {
        if (_scoreStorage.CurrentScore > _scoreStorage.HighestScore)
        {
            _scoreStorage.SetHighestScore(_scoreStorage.CurrentScore);
        }
    }
}
