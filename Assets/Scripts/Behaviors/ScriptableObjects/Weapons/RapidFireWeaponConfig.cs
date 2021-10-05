using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapons/Rapid Fire Weapon")]
public class RapidFireWeaponConfig : ScriptableObject, IRapidFireWeaponConfig
{
    public float fireRate;
    public float FireRate { get => fireRate; }

    public float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; }

    public float projectileLifetime;
    public float ProjectileLifetime { get => projectileLifetime; }
}
