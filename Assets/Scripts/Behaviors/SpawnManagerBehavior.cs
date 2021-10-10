using UnityEngine;

public class SpawnManagerBehavior : MonoBehaviour
{
    public GameEvents GameEvents;
    public SpawnEvents SpawnEvents;
    public SpawnWave[] SpawnWaves;

    private ISpawnManager _spawnManager;

    private void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _spawnManager = new SpawnManager(GameEvents, SpawnWaves, SpawnEvents, screenBounds);

        SpawnEvents.AsteroidSpawned += OnAsteroidSpawned;
        SpawnEvents.UFOSpawned += OnUFOSpawned;
    }

    private void OnAsteroidSpawned(IAsteroid asteroid, Vector3 position, Quaternion rotation)
    {
        if (asteroid is Asteroid)
        {
            Instantiate(asteroid as Asteroid, position, rotation);
        }
    }

    private void OnUFOSpawned(IUFO ufo, Vector3 position, Quaternion rotation)
    {
        if (ufo is UFO)
        {
            Instantiate(ufo as UFO, position, rotation);
        }
    }
}
