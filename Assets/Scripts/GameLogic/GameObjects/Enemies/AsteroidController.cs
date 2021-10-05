using UnityEngine;

public class AsteroidController : GameObjectController
{
    private IAsteroidEvents _asteroidEvents;

    private IAsteroid _asteroid;
    private Vector3 _velocity;
    private float _rotationAngle;
    private ITransformAdapter _transformAdapter;

    public AsteroidController(
        IAsteroidEvents asteroidEvents,
        IAsteroid asteroid,
        Vector2 screenBounds,
        ITransformAdapter transformAdapter
    )
        : base(new IPostUpdateProcessor[] { new PortalPostUpdateProcessor(screenBounds, transformAdapter) })
    {
        _asteroidEvents = asteroidEvents;
        _asteroid = asteroid;
        _velocity = GenerateVelocity(_asteroid.GetAsteroidConfig().Speed);
        _rotationAngle = _asteroid.GetAsteroidConfig().RotationAngle;
        _transformAdapter = transformAdapter;

        GameController.GetInstance().Asteroids.Add(_asteroid);
    }

    private Vector3 GenerateVelocity(float speed)
    {
        float angle = Random.Range(0, 180);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        return rotation * new Vector3(1, 1, 0) * Mathf.Abs(speed);
    }

    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);

        _transformAdapter.position += _velocity * dt;
        _transformAdapter.rotation *= Quaternion.Euler(Vector3.forward * _rotationAngle * dt);
    }

    public void Hit(Collider2D collider)
    {
        // TODO: skip other asteroids
        Die();
    }

    private void Die()
    {
        GameController.GetInstance().Asteroids.Remove(_asteroid);
        _asteroidEvents.InvokeAsteroidDestroyed(_asteroid);
        SpawnAsteroidPieces();
    }

    private void SpawnAsteroidPieces()
    {
        IAsteroidConfig asteroidConfig = _asteroid.GetAsteroidConfig();

        if (asteroidConfig.SpawnCount > 0 && asteroidConfig.SpawnAsteroidConfig != null)
        {
            for (int i = 0; i < asteroidConfig.SpawnCount; i++)
            {
                Vector3 position = _transformAdapter.position;
                Quaternion rotation = Quaternion.identity;

                // TODO: make SpawnManager Singleton
                // TODO: SpawnManager.Instance.SpawnAsteroid(asteroidConfig, position, rotation);
            }
        }
    }
}
