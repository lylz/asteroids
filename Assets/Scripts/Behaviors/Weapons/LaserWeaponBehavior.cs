using UnityEngine;

public class LaserWeaponBehavior : WeaponBehavior
{
    public Laser LaserPrefab;
    public IWeaponEvents WeaponEvents;
    public ILaserWeaponConfig LaserWeaponConfig;

    public override IWeaponController WeaponController { get => _weaponController; }

    private IWeaponController _weaponController;

    private void Awake()
    {
        _weaponController = new LaserWeaponController(LaserWeaponConfig, WeaponEvents);
        WeaponEvents.WeaponFired += OnWeaponFired;
    }

    private void Update()
    {
        _weaponController.Update(Time.deltaTime);
    }

    private void OnWeaponFired(IWeaponConfig weaponConfig)
    {
        // Laser laser = Instantiate(LaserPrefab, FireSlot.position, Quaternion.identity);
        // laser.Length = weaponConfig.LaserLength;
        // laser.Lifetime = weaponConfig.LaserActiveTimeInSeconds;
    }
}
