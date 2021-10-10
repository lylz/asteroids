using UnityEngine;

public interface ISpawnManager
{
}

public class SpawnManager : ISpawnManager
{
    private Vector2 _screenBounds;
    private IGameEvents _gameEvents;
    private ISpawnEvents _spawnEvents;
    private ISpawnWave[] _spawnWaves;

    private int _currentWaveIndex;

    public SpawnManager(
        IGameEvents gameEvents,
        ISpawnWave[] spawnWaves,
        ISpawnEvents spawnEvents,
        Vector2 screenBounds
    )
    {
        _gameEvents = gameEvents;
        _spawnWaves = spawnWaves;
        _spawnEvents = spawnEvents;
        _screenBounds = screenBounds * 2; // TODO: check it
        _currentWaveIndex = 0;

        _gameEvents.GameStarted += Start;
        Debug.Log("SpawnManager Constructor");
    }

    ~SpawnManager()
    {
        _gameEvents.GameStarted -= Start;
    }

    private void Start()
    {
        Debug.Log("Spawn");
        SpawnCurrentWaveEntries();
    }

    private void SpawnNextWave()
    {
        if (_currentWaveIndex < _spawnWaves.Length - 1)
        {
            _currentWaveIndex++;
        }

        // SpawnWave();
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
                // TODO: use InitialSpawnDelayInSeconds
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

        _spawnEvents.InvokeAsteroidSpawned(asteroid, position, rotation);
    }

    private void SpawnUFO(IUFO ufo)
    {
        _spawnEvents.InvokeUFOSpawned(ufo, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        float x = Random.Range(-_screenBounds.x, _screenBounds.x);
        float y = Random.Range(-_screenBounds.y, _screenBounds.y);

        return new Vector3(x, y, 0);
    }
}
