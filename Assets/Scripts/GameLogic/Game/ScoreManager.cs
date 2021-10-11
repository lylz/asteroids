public interface IScoreManager
{
}

public class ScoreManager : IScoreManager
{
    private IScoreStorage _scoreStorage;
    private IEnemyEvents _enemyEvents;
    private IPlayerEvents _playerEvents;

    public ScoreManager(
        IScoreStorage scoreStorage,
        IEnemyEvents enemyEvents,
        IPlayerEvents playerEvents
    )
    {
        _scoreStorage = scoreStorage;
        _enemyEvents = enemyEvents;
        _playerEvents = playerEvents;

        _enemyEvents.EnemyDestroyed += OnEnemyDestroyed;
        _playerEvents.PlayerDied += OnPlayerDied;

        _scoreStorage.SetCurrentScore(0);
    }

    ~ScoreManager()
    {
        _enemyEvents.EnemyDestroyed -= OnEnemyDestroyed;
        _playerEvents.PlayerDied -= OnPlayerDied;
    }

    private void OnEnemyDestroyed(IEnemy enemy)
    {
        _scoreStorage.SetCurrentScore(_scoreStorage.CurrentScore + enemy.ScorePoints);
    }

    private void OnPlayerDied()
    {
        if (_scoreStorage.CurrentScore > _scoreStorage.HighestScore)
        {
            _scoreStorage.SetHighestScore(_scoreStorage.CurrentScore);
        }
    }
}
