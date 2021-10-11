using UnityEngine;

public interface ISpawnManager
{
    public void Start();
}

public class SpawnManager : ISpawnManager
{
    private int _enemiesCount;

    private Vector3 PlayerSpawnPosition = new Vector3(0, 0, 0);

    private IPlayerEvents _playerEvents;
    private IScreenBounds _screenBounds;
    private IEnemyEvents _enemyEvents;
    private ISpawnWave[] _spawnWaves;

    private int _currentWaveIndex;

    public SpawnManager(
        IPlayerEvents playerEvents,
        ISpawnWave[] spawnWaves,
        IEnemyEvents enemyEvents,
        IScreenBounds screenBounds
    )
    {
        _playerEvents = playerEvents;
        _spawnWaves = spawnWaves;
        _enemyEvents = enemyEvents;
        _screenBounds = screenBounds;
        _currentWaveIndex = 0;
        _enemiesCount = 0;

        _enemyEvents.EnemySpawned += OnEnemySpawned;
        _enemyEvents.EnemyDestroyed += OnEnemyDestroyed;
    }

    ~SpawnManager()
    {
        _enemyEvents.EnemySpawned -= OnEnemySpawned;
        _enemyEvents.EnemyDestroyed -= OnEnemyDestroyed;
    }

    public void Start()
    {
        SpawnPlayer();

        _currentWaveIndex = 0;
        SpawnCurrentWaveEntries();
    }

    private void SpawnPlayer()
    {
        _playerEvents.InvokePlayerSpawned(PlayerSpawnPosition);
    }

    private void CheckNextWave()
    {
        if (_enemiesCount == 0)
        {
            SpawnNextWave();
        }
    }

    private void SpawnNextWave()
    {
        if (_currentWaveIndex < _spawnWaves.Length - 1)
        {
            _currentWaveIndex++;
        }

        SpawnCurrentWaveEntries();
    }

    private void SpawnCurrentWaveEntries()
    {
        ISpawnWave currentWave = GetCurrentWave();

        if (currentWave == null)
        {
            Debug.LogWarning("SpawnManager tried to spawn a new wave, but there were no waves found.");
            return;
        }

        foreach (ISpawnWaveEntry spawnWaveEntry in currentWave.SpawnWaveEntries)
        {
            for (int i = 0; i < spawnWaveEntry.Count; i++)
            {
                if (spawnWaveEntry.Enemy is IAsteroid)
                {
                    SpawnAsteroid(spawnWaveEntry.Enemy as IAsteroid);
                }
                else
                {
                    SpawnEnemy(spawnWaveEntry.Enemy);
                }
            }
        }
    }

    private ISpawnWave GetCurrentWave()
    {
        if (_spawnWaves.Length == 0)
        {
            return null;
        }

        if (_currentWaveIndex >= _spawnWaves.Length)
        {
            _currentWaveIndex = _spawnWaves.Length - 1;
        }

        return _spawnWaves[_currentWaveIndex];
    }

    private void SpawnEnemy(IEnemy enemy)
    {
        _enemyEvents.InvokeEnemySpawned(enemy, GetSpawnPosition(), Quaternion.identity);
    }

    private void SpawnAsteroid(IAsteroid asteroid)
    {
        Vector3 position = GetSpawnPosition();
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(0, 180), Vector3.forward);

        _enemyEvents.InvokeEnemySpawned(asteroid, position, rotation);
    }

    private void OnEnemySpawned(IEnemy enemy, Vector3 position, Quaternion rotation)
    {
        _enemiesCount++;
    }

    private void OnEnemyDestroyed(IEnemy enemy)
    {
        _enemiesCount--;
        CheckNextWave();
    }

    private Vector3 GetSpawnPosition()
    {
        float playerPadding = 10;
        float side = Random.Range(0, 1);
        float leftBoundX;
        float rightBoundX;

        // either spawn to the left or to the right of the player
        if (side == 0)
        {
            leftBoundX = -_screenBounds.Bounds.x;
            rightBoundX = PlayerSpawnPosition.x - playerPadding;
        }
        else
        {
            leftBoundX = PlayerSpawnPosition.x + playerPadding;
            rightBoundX = _screenBounds.Bounds.x;
        }

        float x = Random.Range(leftBoundX, rightBoundX);
        float y = Random.Range(-_screenBounds.Bounds.y, _screenBounds.Bounds.y);

        return new Vector3(x, y, 0);
    }
}
