using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BaseBehavior
{
    [SerializeField]
    private AsteroidConfig _asteroidConfig;

    public AsteroidController AsteroidController;

    protected override void Awake()
    {
        base.Awake();

        AsteroidController = new AsteroidController(_asteroidConfig, this, _screenBounds);
        AsteroidController.OnDestroyedCallback += OnAsteroidDestroyed;
    }

    private void FixedUpdate()
    {
        AsteroidController.FixedUpdate(Time.fixedDeltaTime);        
    }

    private void LateUpdate()
    {
        AsteroidController.LateUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AsteroidController.Hit(collision);
    }

    private void OnAsteroidDestroyed(AsteroidConfig config)
    {
        if (config.spawnCount > 0 && config.spawnAsteroidPrefab)
        {
            for (int i = 0; i < config.spawnCount; i++)
            {
                Instantiate(config.spawnAsteroidPrefab, transform.position - new Vector3(2 + i, 2 + i, 0), transform.rotation);
            }
        }

        // TODO: I guess I don't need to unsubscribe from the delegate coz the emmiter will be destroyed together with the gameObject
        AsteroidController.OnDestroyedCallback -= OnAsteroidDestroyed;
        Destroy(gameObject);
    }

    public AsteroidConfig GetAsteroidConfig()
    {
        return _asteroidConfig;
    }
}
