using UnityEngine;

public class SpacecraftController : GameObjectController
{
    private InputControlsSystem _inputSystem;
    private SpacecraftSimulation _spacecraftSimulation;
    private ITransformAdapter _transformAdapter;
    private ISpacecraftPositionTracker _positionTracker;

    private IWeapon _primaryWeapon;
    private IWeapon _secondaryWeapon;

    private bool _move;
    private bool _rotateLeft;
    private bool _rotateRight;

    public SpacecraftController(
        IWeapon primaryWeapon,
        IWeapon secondaryWeapon,
        SpacecraftSimulation spacecraftSimulation,
        InputControlsSystem inputSystem,
        Vector2 screenBounds,
        ISpacecraftPositionTracker spacecraftPosition,
        ITransformAdapter transformAdapter
    ) // TODO: check it
        : base(
            new IPostUpdateProcessor[] { new PortalPostUpdateProcessor(screenBounds, transformAdapter), new SpacecraftPositionPostUpdateProcessor(spacecraftPosition, transformAdapter) }
        )
    {
        _primaryWeapon = primaryWeapon;
        _secondaryWeapon = secondaryWeapon;
        _spacecraftSimulation = spacecraftSimulation;
        _inputSystem = inputSystem;
        _transformAdapter = transformAdapter;
        _positionTracker = spacecraftPosition;

        _inputSystem.MoveForwardEvent += OnMoveForward;
        _inputSystem.RotateLeftEvent += OnRotateLeft;
        _inputSystem.RotateRightEvent += OnRotateRight;
        _inputSystem.FirePrimaryEvent += OnFirePrimary;
        _inputSystem.FireSecondaryEvent += OnFireSecondary;
    }

    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);

        if (_rotateLeft)
        {
            _transformAdapter.rotation = _spacecraftSimulation.Rotate(_transformAdapter.rotation, 10.0f);
        }
        
        if (_rotateRight)
        {
            _transformAdapter.rotation = _spacecraftSimulation.Rotate(_transformAdapter.rotation, -10.0f);
        }

        if (_move)
        {
            _spacecraftSimulation.AddForce(_transformAdapter.lookDirection * 0.5f);
        }

        Vector3 newPosition = _spacecraftSimulation.UpdatePosition(_transformAdapter.position, dt);
        _positionTracker.InstantSpeed = newPosition - _transformAdapter.position;
        _transformAdapter.position = newPosition;
    }

    private void OnMoveForward()
    {
        _move = !_move;
    }

    private void OnRotateLeft()
    {
        _rotateLeft = !_rotateLeft;
    }

    private void OnRotateRight()
    {
        _rotateRight = !_rotateRight;
    }

    private void OnFirePrimary()
    {
        if (!_secondaryWeapon.WeaponController.ShootingInProgress())
        {
            _primaryWeapon.WeaponController.Shoot();
        }
    }

    private void OnFireSecondary()
    {
        if (!_primaryWeapon.WeaponController.ShootingInProgress())
        {
            _secondaryWeapon.WeaponController.Shoot();
        }
    }
}
