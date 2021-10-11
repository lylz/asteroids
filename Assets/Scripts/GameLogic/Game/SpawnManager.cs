using UnityEngine;

public interface ISpawnManager
{
    public void Start();
    public void Update(float dt);
}

public class SpawnManager : ISpawnManager
{
    private int _enemiesCount;

    private Vector2 _screenBounds;
    private IEnemyEvents _enemyEvents;
    private ISpawnWave[] _spawnWaves;

    private int _currentWaveIndex;

    public SpawnManager(
        ISpawnWave[] spawnWaves,
        IEnemyEvents enemyEvents,
        Vector2 screenBounds
    )
    {
        _spawnWaves = spawnWaves;
        _enemyEvents = enemyEvents;
        _screenBounds = screenBounds * 2; // TODO: check it
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
        _currentWaveIndex = 0;
        SpawnCurrentWaveEntries();
    }

    public void Update(float dt)
    {

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
            return; // TODO: handle
        }

        foreach (ISpawnWaveEntry spawnWaveEntry in currentWave.SpawnWaveEntries)
        {
            for (int i = 0; i < spawnWaveEntry.Count; i++)
            {
                if (spawnWaveEntry.Enemy is IAsteroid)
                {
                    SpawnAsteroid(spawnWaveEntry.Enemy as IAsteroid);
                }
                else if (spawnWaveEntry.Enemy is IUFO)
                {
                    SpawnUFO(spawnWaveEntry.Enemy as IUFO);
                }
                else
                {
                    // TODO: throw error
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

        if (_currentWaveIndex > _spawnWaves.Length - 1)
        {
            _currentWaveIndex = _spawnWaves.Length - 1;
        }

        return _spawnWaves[_currentWaveIndex];
    }

    private void SpawnAsteroid(IAsteroid asteroid)
    {
        Vector3 position = GetSpawnPosition();
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(0, 180), Vector3.forward);

        _enemyEvents.InvokeEnemySpawned(asteroid, position, rotation);
    }

    private void SpawnUFO(IUFO ufo)
    {
        _enemyEvents.InvokeEnemySpawned(ufo, GetSpawnPosition(), Quaternion.identity);
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
        float x = Random.Range(-_screenBounds.x, _screenBounds.x);
        float y = Random.Range(-_screenBounds.y, _screenBounds.y);

        return new Vector3(x, y, 0);
    }
}
