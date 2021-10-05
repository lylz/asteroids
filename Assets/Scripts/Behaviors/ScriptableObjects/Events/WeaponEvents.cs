using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Weapon Event")]
public class WeaponEvents : ScriptableObject, IWeaponEvents
{
    public event UnityAction<IWeaponConfig> WeaponFired = delegate { };

    public void InvokeWeaponFired(IWeaponConfig weaponConfig)
    {
        WeaponFired.Invoke(weaponConfig);
    }
}
