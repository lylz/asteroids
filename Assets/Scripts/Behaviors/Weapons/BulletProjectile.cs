using UnityEngine;

public interface IBulletProjectile
{
}

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletProjectile : MonoBehaviour, IBulletProjectile, ITransformAdapter
{
    public RapidFireWeaponConfig WeaponConfig;
    public Vector3 Direction;

    private BulletProjectileController _controller;

    public Vector3 position
    {
        get => transform.position;
        set { transform.position = value; }
    }

    public Vector3 lookDirection
    {
        get => transform.up;
    }

    public Quaternion rotation
    {
        get => transform.rotation;
        set { transform.rotation = value; }
    }

    private void Start()
    {
        _controller = new BulletProjectileController(Direction, WeaponConfig, this);
        _controller.BulletDestroyed += OnBulletDestroyed;
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _controller.FixedUpdate(Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _controller.Hit(collision);
    }

    private void OnBulletDestroyed()
    {
        Destroy(gameObject);
    }
}
