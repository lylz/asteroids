using UnityEngine;

public class SpacecraftController : BaseController
{
    private InputSystem _inputSystem;
    private SpacecraftSimulation _spacecraftSimulation;

    private bool _move;
    private bool _rotateLeft;
    private bool _rotateRight;

    public SpacecraftController(
        SpacecraftSimulation spacecraftSimulation,
        InputSystem inputSystem,
        ITransformAdapter transformAdapter,
        Vector2 screenBounds
    )
        : base(transformAdapter, screenBounds)
    {
        _spacecraftSimulation = spacecraftSimulation;
        _inputSystem = inputSystem;
        _transformAdapter = transformAdapter;
        _screenBounds = new Bounds(new Vector3(0, 0, 0), screenBounds * 2);

        _inputSystem.MoveForwardEvent += OnMoveForward;
        _inputSystem.RotateLeftEvent += OnRotateLeft;
        _inputSystem.RotateRightEvent += OnRotateRight;
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

        _transformAdapter.position = _spacecraftSimulation.UpdatePosition(_transformAdapter.position, dt);
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
}
