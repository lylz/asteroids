using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : BaseController
{
    public delegate void OnDestroyed(AsteroidConfig config);
    public OnDestroyed OnDestroyedCallback;
    private AsteroidConfig _config;
    private Vector3 _velocity;
    private float _rotationAngle;

    public AsteroidController(
        AsteroidConfig config,
        ITransformAdapter transformAdapter,
        Vector2 screenBounds
    )
        : base(transformAdapter, screenBounds)
    {
        _config = config;
        _velocity = GenerateVelocity(config.speed);
        _rotationAngle = config.rotationAngle;
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
        if (OnDestroyedCallback != null)
        {
            OnDestroyedCallback(_config);
        }
    }
}
