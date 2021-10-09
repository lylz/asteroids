using System.Collections.Generic;
using UnityEngine.Events;

public class LaserWeaponController : IWeaponController
{
    public event UnityAction LaserActivated = delegate {};
    public event UnityAction LaserDeactivated = delegate {};

    private IWeaponEvents _weaponEvents;
    private ILaserWeaponConfig _weaponConfig;

    private uint _currentCharges;
    private bool _canShoot;
    private bool _laserActive;

    private List<Timer> _cooldownTimers;

    public LaserWeaponController(
        ILaserWeaponConfig weaponConfig,
        IWeaponEvents weaponEvents
    )
    {
        _weaponConfig = weaponConfig;
        _weaponEvents = weaponEvents;
        _currentCharges = _weaponConfig.MaxCharges;
        _canShoot = true;

        _cooldownTimers = new List<Timer>();
    }

    public void Shoot()
    {
        if (!_laserActive && _canShoot && _currentCharges > 0)
        {
            _currentCharges--;
            _canShoot = false;
            StartFireCooldown();
            StartRechargeCooldown();
            StartLaserLifetimeTimer();
            _weaponEvents.InvokeWeaponFired(_weaponConfig);
        }
    }

    public bool ShootingInProgress()
    {
        return _laserActive;
    }

    public void Update(float dt)
    {
        _cooldownTimers.RemoveAll(t => t.IsFinished);

        foreach (var timer in _cooldownTimers)
        {
            timer.Tick(dt);
        }
    }

    private void StartLaserLifetimeTimer()
    {
        _laserActive = true;
        Timer laserLifetimeTimer = new Timer(_weaponConfig.LaserActiveTimeInSeconds);
        laserLifetimeTimer.TimerFinished += OnLaserLifetimeFinished;

        _cooldownTimers.Add(laserLifetimeTimer);
        LaserActivated.Invoke();
    }

    private void OnLaserLifetimeFinished(Timer timer)
    {
        _laserActive = false;
        LaserDeactivated.Invoke();
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
    }
}
