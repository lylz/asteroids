using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Spacecraft : ControllableBehavior
{
    [Header("Simulation")]
    public SpacecraftSimulationProperties SpacecraftSimulationProperties;
    public SpacecraftPositionTracker SpacecraftPosition;

    [Header("Weapons")]
    public WeaponBehavior PrimaryWeaponPrefab;
    public WeaponBehavior SecondaryWeaponPrefab;

    [SerializeField]
    public WeaponSlotBehavior _primaryWeaponSlot;
    [SerializeField]
    public WeaponSlotBehavior _secondaryWeaponSlot;

    [Header("Dependencies")]
    public ScreenBounds ScreenBounds;
    public PlayerEvents PlayerEvents;

    [SerializeField]
    private InputControlsSystem _inputSystem;

    private SpacecraftSimulation _spacecraftSimulation;
    private SpacecraftController _spacecraftController;

    public override IGameObjectController Controller => _spacecraftController;

    protected override void Start()
    {
        base.Start();

        _primaryWeaponSlot.SetWeapon(PrimaryWeaponPrefab);
        _secondaryWeaponSlot.SetWeapon(SecondaryWeaponPrefab);

        _spacecraftSimulation = new SpacecraftSimulation(SpacecraftSimulationProperties);
        _spacecraftController = new SpacecraftController(
            _primaryWeaponSlot.Weapon,
            _secondaryWeaponSlot.Weapon,
            _spacecraftSimulation,
            PlayerEvents,
            _inputSystem,
            ScreenBounds,
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
