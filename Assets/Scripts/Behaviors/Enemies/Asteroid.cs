using UnityEngine;

public class Asteroid : BaseControllableBehavior<AsteroidController>, IAsteroid
{
    public AsteroidEvents AsteroidEvents;
    public AsteroidConfig AsteroidConfig;

    private AsteroidController _asteroidController;

    public override AsteroidController Controller => _asteroidController;

    protected override void Start()
    {
        base.Start();

        _asteroidController = new AsteroidController(AsteroidEvents, this, _screenBounds, this);
        AsteroidEvents.AsteroidDestroyed += OnAsteroidDestroyed;

        Scale();
    }

    private void Scale()
    {
        float scale = AsteroidConfig.Scale;

        transform.localScale = new Vector2(scale, scale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _asteroidController.Hit(collision);
    }

    // TODO: move the logic of spawning inside of a controller
    private void OnAsteroidDestroyed(IAsteroid asteroid)
    {
        if (GetInstanceID() != asteroid.GetId())
        {
            return;
        }

        AsteroidConfig config = asteroid.GetAsteroidConfig() as AsteroidConfig; // TODO: check

        if (config.SpawnCount > 0 && config.SpawnAsteroidConfig != null)
        {
            for (int i = 0; i < config.SpawnCount; i++)
            {
                Asteroid newAsteroid = Instantiate(this, transform.position - new Vector3(1 + i, 1 + i, 0), transform.rotation);
                newAsteroid.AsteroidConfig = config.SpawnAsteroidConfig as AsteroidConfig; // TODO: check it!
            }
        }

        Destroy(gameObject);
    }
    public int GetId()
    {
        return GetInstanceID();
    }

    public IAsteroidConfig GetAsteroidConfig()
    {
        return AsteroidConfig;
    }
}
