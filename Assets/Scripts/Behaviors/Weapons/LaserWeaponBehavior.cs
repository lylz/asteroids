using UnityEngine;

public class LaserWeaponBehavior : WeaponBehavior
{
    public Laser LaserPrefab;
    public WeaponEvents WeaponEvents;
    public LaserWeaponConfig LaserWeaponConfig;
    public LaserInfoTracker LaserInfoTracker;

    public override IWeaponController WeaponController { get => _weaponController; }

    private LaserWeaponController _weaponController;
    private Laser _activeLaser;

    private void Awake()
    {
        _weaponController = new LaserWeaponController(LaserWeaponConfig, WeaponEvents, LaserInfoTracker);
        _weaponController.LaserActivated += OnLaserActivated;
        _weaponController.LaserDeactivated += OnLaserDeactivated;
    }

    private void Update()
    {
        _weaponController.Update(Time.deltaTime);
    }

    private void OnLaserActivated()
    {
        if (_activeLaser != null)
        {
            OnLaserDeactivated();
        }

        _activeLaser = Instantiate(LaserPrefab, transform.position, transform.rotation, transform);
    }

    private void OnLaserDeactivated()
    {
        if (_activeLaser != null)
        {
            Destroy(_activeLaser.gameObject);
            _activeLaser = null;
        }
    }

    private void OnDestroy()
    {
        _weaponController.LaserActivated -= OnLaserActivated;
        _weaponController.LaserDeactivated -= OnLaserDeactivated;
    }
}
