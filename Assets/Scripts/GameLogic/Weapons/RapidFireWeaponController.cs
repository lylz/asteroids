public class RapidFireWeaponController : IWeaponController
{
    private IWeaponEvents _weaponEvents;
    private IRapidFireWeaponConfig _weaponConfig;

    public RapidFireWeaponController(
        IRapidFireWeaponConfig weaponConfig,
        IWeaponEvents weaponEvents
    )
    {
        _weaponConfig = weaponConfig;
        _weaponEvents = weaponEvents;
    }

    public void Update(float dt) { }

    public void Shoot()
    {
        _weaponEvents.InvokeWeaponFired(_weaponConfig);
    }

    public bool ShootingInProgress()
    {
        return false; // allowing to shoot as fast as player can
    }
}
