using System.Collections.Generic;
using UnityEngine.Events;

public class LaserWeaponController : IWeaponController
{
    public event UnityAction LaserActivated = delegate {};
    public event UnityAction LaserDeactivated = delegate {};

    private IWeaponEvents _weaponEvents;
    private ILaserWeaponConfig _weaponConfig;
    private ILaserInfoTracker _infoTracker;

    private uint _chargesLeft;
    private bool _canShoot;
    private bool _laserActive;

    private Timer _fireCooldownTimer;
    private Timer _rechargeTimer;
    private Timer _laserLifetimeTimer;

    public LaserWeaponController(
        ILaserWeaponConfig weaponConfig,
        IWeaponEvents weaponEvents,
        ILaserInfoTracker infoTracker
    )
    {
        _weaponConfig = weaponConfig;
        _weaponEvents = weaponEvents;
        _infoTracker = infoTracker;
        _chargesLeft = _weaponConfig.MaxCharges;
        _canShoot = true;
    }

    public void Shoot()
    {
        if (!_laserActive && _canShoot && _chargesLeft > 0)
        {
            _chargesLeft--;
            _canShoot = false;
            StartFireCooldown();
            StartRecharge();
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
        _fireCooldownTimer?.Tick(dt);
        _rechargeTimer?.Tick(dt);
        _laserLifetimeTimer?.Tick(dt);

        UpdateLaserInfo();
    }

    private void UpdateLaserInfo()
    {
        _infoTracker.Charges = _chargesLeft;

        float cooldownTime = 0;

        if (_fireCooldownTimer != null)
        {
            cooldownTime = _fireCooldownTimer.RemainingTime;
        }

        _infoTracker.CooldownTime = cooldownTime;

        float rechargeTime = 0;

        if (_rechargeTimer != null)
        {
            rechargeTime = _rechargeTimer.RemainingTime;
        }

        _infoTracker.RechargeTime = rechargeTime;
    }

    private void StartLaserLifetimeTimer()
    {
        _laserActive = true;
        Timer laserLifetimeTimer = new Timer(_weaponConfig.LaserActiveTimeInSeconds);
        laserLifetimeTimer.TimerFinished += OnLaserLifetimeFinished;

        _laserLifetimeTimer = laserLifetimeTimer;
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

        _fireCooldownTimer = fireCooldownTimer;
    }

    private void OnFireCooldownFinished(Timer timer)
    {
        _canShoot = true;
        _fireCooldownTimer = null;
    }

    private void StartRecharge()
    {
        if (_chargesLeft >= _weaponConfig.MaxCharges || _rechargeTimer?.RemainingTime > 0)
        {
            return;
        }

        Timer rechargeTimer = new Timer(_weaponConfig.RechargeCooldownInSeconds);
        rechargeTimer.TimerFinished += OnRechargeFinished;

        _rechargeTimer = rechargeTimer;
    }

    private void OnRechargeFinished(Timer timer)
    {
        if (_chargesLeft < _weaponConfig.MaxCharges)
        {
            _chargesLeft++;
        }

        StartRecharge();
    }
}
