using UnityEngine;

public class AsteroidController : GameObjectController
{
    private IEnemyEvents _enemyEvents;

    private IAsteroid _asteroid;
    private Vector3 _velocity;
    private float _rotationAngle;
    private ITransformAdapter _transformAdapter;

    public AsteroidController(
        IEnemyEvents enemyEvents,
        IAsteroid asteroid,
        Vector2 screenBounds,
        ITransformAdapter transformAdapter
    )
        : base(new IPostUpdateProcessor[] { new PortalPostUpdateProcessor(screenBounds, transformAdapter) })
    {
        _enemyEvents = enemyEvents;
        _asteroid = asteroid;
        _transformAdapter = transformAdapter;
        _velocity = GenerateVelocity(_asteroid.GetAsteroidConfig().Speed);
        _rotationAngle = _asteroid.GetAsteroidConfig().RotationAngle;
    }

    private Vector3 GenerateVelocity(float speed)
    {
        Vector3 direction = _transformAdapter.rotation * new Vector3(1, 1, 0);

        return direction * Mathf.Abs(speed);
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
        _enemyEvents.InvokeEnemyDestroyed(_asteroid);
        SpawnAsteroidPieces();
    }

    private void SpawnAsteroidPieces()
    {
        IAsteroidConfig asteroidConfig = _asteroid.GetAsteroidConfig();

        if (asteroidConfig.SpawnCount > 0 && asteroidConfig.SpawnAsteroidPrefab != null)
        {
            // asteroid pieces gets spawned on the equal distance from each other
            // around the asteroid death point
            float directionAngle = 360 / asteroidConfig.SpawnCount; // get an angle for each asteroid piece

            for (int i = 0; i < asteroidConfig.SpawnCount; i++)
            {
                SpawnAsteroidPiece(asteroidConfig.SpawnAsteroidPrefab, directionAngle * i);
            }
        }
    }

    private void SpawnAsteroidPiece(IAsteroid asteroid, float directionAngle)
    {
        float currentAngle = _transformAdapter.rotation.eulerAngles.z;
        Quaternion rotation = Quaternion.AngleAxis(currentAngle + directionAngle, Vector3.forward);
        Vector3 direction = rotation * new Vector3(1, 1, 0);
        Vector3 position = _transformAdapter.position + direction.normalized / 2; // dividing by 2 to get pieces closer to the center

        _enemyEvents.InvokeEnemySpawned(asteroid, position, rotation);
    }
}
