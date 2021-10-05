using UnityEngine.Events;

public interface IWeaponEvents
{
    public event UnityAction<IWeaponConfig> WeaponFired;
    public void InvokeWeaponFired(IWeaponConfig weaponConfig);
}
