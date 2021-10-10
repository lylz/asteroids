using UnityEngine;

public class Asteroid : Enemy, IAsteroid
{
    public SpawnEvents SpawnEvents;
    public AsteroidEvents AsteroidEvents;
    public AsteroidConfig AsteroidConfig;

    private AsteroidController _asteroidController;

    public override IGameObjectController Controller => _asteroidController;

    protected override void Start()
    {
        base.Start();

        _asteroidController = new AsteroidController(SpawnEvents, AsteroidEvents, this, _screenBounds, this);
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

    private void OnAsteroidDestroyed(IAsteroid asteroid)
    {
        if (GetInstanceID() != asteroid.GetId())
        {
            return;
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
