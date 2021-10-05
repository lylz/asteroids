using UnityEngine;

public class Spacecraft : BaseControllableBehavior<SpacecraftController>
{
    public SpacecraftSimulationProperties SpacecraftSimulationProperties;
    public SpacecraftPositionTracker SpacecraftPosition; // TODO: check it

    // TODO: weapons should be instantiated if I want to use IWeapon.Shoot(). it cannot be just a prefab
    // TODO: maybe implement some equip mechanism, so that I can pass prefabs here
    // and on start they will be instantiated?
    public WeaponBehavior PrimaryWeaponPrefab;
    public WeaponBehavior SecondaryWeaponPrefab;

    [SerializeField]
    private InputControlsSystem _inputSystem;

    private SpacecraftSimulation _spacecraftSimulation;
    private SpacecraftController _spacecraftController;
    private WeaponSlotBehavior[] _weaponSlots;

    public override SpacecraftController Controller => _spacecraftController;

    protected override void Start()
    {
        base.Start();

        _weaponSlots = GetComponentsInChildren<WeaponSlotBehavior>();

        if (_weaponSlots.Length != 2)
        {
            // TODO: throw exception
            Debug.LogError("Insufficient amount of slots. Should be 2!");
            return;
        }

        _weaponSlots[0].SetWeapon(PrimaryWeaponPrefab);
        _weaponSlots[1].SetWeapon(SecondaryWeaponPrefab);

        _spacecraftSimulation = new SpacecraftSimulation(SpacecraftSimulationProperties);
        _spacecraftController = new SpacecraftController(
            _weaponSlots[0].Weapon,
            _weaponSlots[1].Weapon,
            _spacecraftSimulation,
            _inputSystem,
            _screenBounds,
            SpacecraftPosition,
            this
        );

        // TODO: add OnFireHandler
    }
}
