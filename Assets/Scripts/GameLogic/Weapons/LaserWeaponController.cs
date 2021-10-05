using System.Collections.Generic;

public class LaserWeaponController : IWeaponController
{
    private IWeaponEvents _weaponEvents;
    private ILaserWeaponConfig _weaponConfig;

    private uint _currentCharges;
    private bool _canShoot;

    private List<Timer> _cooldownTimers;

    public LaserWeaponController(
        ILaserWeaponConfig weaponConfig,
        IWeaponEvents weaponEvents
    )
    {
        _weaponConfig = weaponConfig;
        _weaponEvents = weaponEvents;
        _currentCharges = _weaponConfig.MaxCharges;

        _cooldownTimers = new List<Timer>();
    }

    public void Shoot()
    {
        if (_canShoot && _currentCharges > 0)
        {
            _currentCharges--;
            _canShoot = false;
            StartFireCooldown();
            StartRechargeCooldown();
            _weaponEvents.InvokeWeaponFired(_weaponConfig);
        }
    }

    public bool ShootingInProgress()
    {
        return false; // TODO: implement the logic
    }

    public void Update(float dt)
    {
        foreach (var timer in _cooldownTimers)
        {
            timer.Tick(dt);
        }
    }

    private void StartFireCooldown()
    {
        Timer fireCooldownTimer = new Timer(_weaponConfig.FireCooldownInSeconds);
        fireCooldownTimer.TimerFinished += OnFireCooldownFinished;

        _cooldownTimers.Add(fireCooldownTimer);
    }

    private void OnFireCooldownFinished(Timer timer)
    {
        _canShoot = true;
        _cooldownTimers.Remove(timer);
    }

    private void StartRechargeCooldown()
    {
        Timer rechargeCooldownTimer = new Timer(_weaponConfig.RechargeCooldownInSeconds);
        rechargeCooldownTimer.TimerFinished += OnRechargeCooldownFinished;

        _cooldownTimers.Add(rechargeCooldownTimer);
    }

    private void OnRechargeCooldownFinished(Timer timer)
    {
        if (_currentCharges < _weaponConfig.MaxCharges)
        {
            _currentCharges++;
        }

        _cooldownTimers.Remove(timer);
    }
}
