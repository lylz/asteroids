using UnityEngine;

public abstract class WeaponBehavior : MonoBehaviour, IWeapon
{
    public abstract IWeaponController WeaponController { get;}
}
