using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapons/Laser Weapon Config")]
public class LaserWeaponConfig : ScriptableObject, ILaserWeaponConfig
{
    public float laserActiveTimeInSeconds;
    public float LaserActiveTimeInSeconds { get => laserActiveTimeInSeconds; }

    public uint maxCharges;
    public uint MaxCharges { get => maxCharges; }

    public float fireCooldownInSeconds;
    public float FireCooldownInSeconds { get => fireCooldownInSeconds; }

    public float rechargeCooldownInSeconds;
    public float RechargeCooldownInSeconds { get => rechargeCooldownInSeconds; }
}
