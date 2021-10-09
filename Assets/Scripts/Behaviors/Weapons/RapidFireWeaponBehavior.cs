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
        // TODO: identify that it is a correct weapon shooting
        if (weaponConfig is IRapidFireWeaponConfig)
        {
            IRapidFireWeaponConfig config = weaponConfig as IRapidFireWeaponConfig;
            BulletProjectile bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.WeaponConfig = RapidFireWeaponConfig; // TODO: check it
            bullet.Direction = transform.up;
        }
    }

    private void OnDestroy()
    {
        WeaponEvents.WeaponFired -= OnWeaponFired;
    }
}
