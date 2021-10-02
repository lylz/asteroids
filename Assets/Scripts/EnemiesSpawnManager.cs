using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    public float SpawnIntervalInSeconds;

    [Header("Asteroids")]
    [SerializeField]
    private Asteroid _asteroidPrefab;
    [SerializeField]
    private uint _asteroidsToSpawn;

    private float _spawnInterval;
    private Vector2 _screenBounds;

    private int _asteroidsCounter;

    private void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _spawnInterval = Mathf.Abs(SpawnIntervalInSeconds);
        StartCoroutine("SpawnAsteroidsRoutine");
    }

    private IEnumerator SpawnAsteroidsRoutine()
    {
        for (;;)
        {
            if (_asteroidsCounter == 0)
            {
                SpawnAsteroids();            
            }

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnAsteroids()
    {
        if (_asteroidPrefab != null)
        {
            for (int i = 0; i < _asteroidsToSpawn; i++)
            {
                float x = Random.Range(-_screenBounds.x, _screenBounds.x);
                float y = Random.Range(-_screenBounds.y, _screenBounds.y);
                float rotationAngle = Random.Range(0, 180);
                Vector3 position = new Vector3(x, y, 0);
                Quaternion rotation = Quaternion.AngleAxis(rotationAngle, new Vector3(0, 0, 1));

                Asteroid asteroid = Instantiate(_asteroidPrefab, position, rotation);
                _asteroidsCounter++;
                asteroid.AsteroidController.OnDestroyedCallback += OnAsteroidDestroyed;
            }
        }
    }

    private void OnAsteroidDestroyed(AsteroidConfig config)
    {
        _asteroidsCounter--;

        // TODO: check it. it might never happend?
        if (_asteroidsCounter < 0)
        {
            _asteroidsCounter = 0;
        }
    }
}
