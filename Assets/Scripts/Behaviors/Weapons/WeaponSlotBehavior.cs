using UnityEngine;

public class WeaponSlotBehavior : MonoBehaviour
{
    private WeaponBehavior _weapon;

    public WeaponBehavior Weapon { get => _weapon; }

    public WeaponBehavior SetWeapon(WeaponBehavior weaponPrefab)
    {
        _weapon = Instantiate(weaponPrefab, transform);

        return _weapon;
    }
}
