using System.Collections;
using UnityEngine;

public interface ISpawnManager
{
    public IEnumerator[] GetSpawnCoroutines();
}

public class SpawnManager : ISpawnManager
{
    private Vector2 _screenBounds;
    private ISpawnEvents _spawnEvents;

    private uint _asteroidsToSpawn;
    private uint _ufoToSpawn;

    public SpawnManager(
        uint asteroidsToSpawn,
        uint ufoToSpawn,
        Vector2 screenBounds,
        ISpawnEvents spawnEvents
    )
    {
        _asteroidsToSpawn = asteroidsToSpawn;
        _ufoToSpawn = ufoToSpawn;
        _screenBounds = screenBounds; // TODO: need to multiply coordinates by 2
        _spawnEvents = spawnEvents;
    }

    // TODO: use Timer instead
    public IEnumerator[] GetSpawnCoroutines()
    {
        return new IEnumerator[] { SpawnAsteroidsRoutine(), SpawnUFOsRoutine() };
    }

    private IEnumerator SpawnAsteroidsRoutine()
    {
        for (;;)
        {
            if (GameController.GetInstance().Asteroids.Count == 0)
            {
                SpawnAsteroids();
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator SpawnUFOsRoutine()
    {
        for (;;)
        {
            if (GameController.GetInstance().UFOs.Count == 0)
            {
                SpawnUFOs();
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    private void SpawnAsteroids()
    {
        for (int i = 0; i < _asteroidsToSpawn; i++)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        Vector3 position = GetSpawnPosition();
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(0, 180), new Vector3(0, 0, 1));

        // TODO: get the IAsteroidConfig from outside
        _spawnEvents.InvokeAsteroidSpawned(null, position, rotation);
    }

    private void SpawnUFOs()
    {
        for (int i = 0; i < _ufoToSpawn; i++)
        {
            SpawnUFO();
        }
    }

    private void SpawnUFO()
    {
        _spawnEvents.InvokeUFOSpawned(GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        float x = Random.Range(-_screenBounds.x, _screenBounds.x);
        float y = Random.Range(-_screenBounds.y, _screenBounds.y);

        return new Vector3(x, y, 0);
    }
}
