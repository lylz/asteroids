using UnityEngine;
using UnityEngine.Events;

public interface IBulletProjectileController
{
}

public class BulletProjectileController : IBulletProjectileController
{
    public event UnityAction BulletDestroyed = delegate { };

    private Vector3 _direction;
    private IRapidFireWeaponConfig _weaponConfig;
    private Timer _lifetimeTimer;
    private ITransformAdapter _transformAdapter;

    public BulletProjectileController(
        Vector3 direction,
        IRapidFireWeaponConfig weaponConfig,
        ITransformAdapter transformAdapter
    )
    {
        _direction = direction;
        _weaponConfig = weaponConfig;
        _transformAdapter = transformAdapter;

        _lifetimeTimer = new Timer(_weaponConfig.ProjectileLifetime);
        _lifetimeTimer.TimerFinished += OnLifetimeTimerFinished;
    }

    public void Update(float dt)
    {
        _lifetimeTimer.Tick(dt);
    }

    public void FixedUpdate(float dt)
    {
        _transformAdapter.position += _direction * _weaponConfig.ProjectileSpeed * dt;
    }

    public void Hit(Collider2D collision)
    {
        Destroy();
    }

    private void OnLifetimeTimerFinished(Timer timer)
    {
        Destroy();
    }

    private void Destroy()
    {
        BulletDestroyed.Invoke();
    }
}
