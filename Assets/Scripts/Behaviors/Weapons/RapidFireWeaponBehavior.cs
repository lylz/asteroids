using UnityEngine;

public class RapidFireWeaponBehavior : WeaponBehavior
{
    public WeaponEvents WeaponEvents;
    public RapidFireWeaponConfig RapidFireWeaponConfig;
    public BulletProjectile BulletPrefab;

    public override IWeaponController WeaponController { get => _weaponController; }

    private IWeaponController _weaponController;

    private void Awake()
    {
        _weaponController = new RapidFireWeaponController(RapidFireWeaponConfig, WeaponEvents);
        WeaponEvents.WeaponFired += OnWeaponFired;
    }

    private void OnWeaponFired(IWeaponConfig weaponConfig)
    {
        if (weaponConfig is IRapidFireWeaponConfig)
        {
            IRapidFireWeaponConfig config = weaponConfig as IRapidFireWeaponConfig;
            // TODO: Player.FireSlot here
            // TODO: Player.lookDirection here
            BulletProjectile bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.Speed = config.ProjectileSpeed;
            bullet.Lifetime = config.ProjectileLifetime;
            bullet.Direction = transform.up;
        }
    }
}
