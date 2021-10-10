using UnityEngine;

public class Spacecraft : ControllableBehavior
{
    public SpacecraftSimulationProperties SpacecraftSimulationProperties;
    public SpacecraftPositionTracker SpacecraftPosition; // TODO: check it

    public WeaponBehavior PrimaryWeaponPrefab;
    public WeaponBehavior SecondaryWeaponPrefab;

    public PlayerEvents PlayerEvents;

    [SerializeField]
    private InputControlsSystem _inputSystem;

    private SpacecraftSimulation _spacecraftSimulation;
    private SpacecraftController _spacecraftController;
    private WeaponSlotBehavior[] _weaponSlots;

    public override IGameObjectController Controller => _spacecraftController;

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
            PlayerEvents,
            _inputSystem,
            _screenBounds,
            SpacecraftPosition,
            this
        );

        PlayerEvents.PlayerDied += OnPlayerDied;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spacecraftController.Hit(collision);
    }

    private void OnPlayerDied()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        PlayerEvents.PlayerDied -= OnPlayerDied;
    }
}
