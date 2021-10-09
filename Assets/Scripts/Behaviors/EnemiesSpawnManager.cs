using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    public float AsteroidsSpawnIntervalInSeconds;
    public float UFOSpawnIntervalInSeconds;

    public SpawnEvents SpawnEvents;

    [Header("Asteroids")]
    [SerializeField]
    private Asteroid _asteroidPrefab;
    [SerializeField]
    private uint _asteroidsToSpawn;

    [Header("UFO")]
    [SerializeField]
    private UFO _ufoPrefab;
    [SerializeField]
    private uint _ufoToSpawn;

    private float _asteroidsSpawnInterval;
    private float _ufoSpawnInterval;

    private ISpawnManager _spawnManager;

    private void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _spawnManager = new SpawnManager(_asteroidsToSpawn, _ufoToSpawn, screenBounds, SpawnEvents);

        _asteroidsSpawnInterval = Mathf.Abs(AsteroidsSpawnIntervalInSeconds);
        _ufoSpawnInterval = Mathf.Abs(UFOSpawnIntervalInSeconds);

        SpawnEvents.AsteroidSpawned += OnAsteroidSpawned;
        SpawnEvents.UFOSpawned += OnUFOSpawned;

        StartSpawnRoutines();
    }

    private void StartSpawnRoutines()
    {
        IEnumerator[] routines = _spawnManager.GetSpawnCoroutines();

        foreach (var routine in routines)
        {
            StartCoroutine(routine);
        }
    }

    private void OnAsteroidSpawned(IAsteroidConfig config, Vector3 position, Quaternion rotation)
    {
        Asteroid asteroid = Instantiate(_asteroidPrefab, position, rotation);

        if (config != null && config is AsteroidConfig)
        {
            asteroid.AsteroidConfig = config as AsteroidConfig;
        }
    }

    private void OnUFOSpawned(Vector3 position, Quaternion rotation)
    {
        UFO ufo = Instantiate(_ufoPrefab, position, rotation);
    }
}
