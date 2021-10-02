public class SpacecraftController
{
    private InputSystem _inputSystem;
    private ITransformAdapter _transformAdapter;
    private SpacecraftSimulation _spacecraftSimulation;

    private bool _move;
    private bool _rotateLeft;
    private bool _rotateRight;

    public SpacecraftController(
        SpacecraftSimulation spacecraftSimulation,
        InputSystem inputSystem,
        ITransformAdapter transformAdapter
    )
    {
        _spacecraftSimulation = spacecraftSimulation;
        _inputSystem = inputSystem;
        _transformAdapter = transformAdapter;

        _inputSystem.MoveForwardEvent += OnMoveForward;
        _inputSystem.RotateLeftEvent += OnRotateLeft;
        _inputSystem.RotateRightEvent += OnRotateRight;
    }

    public void FixedUpdate(float dt)
    {
        if (_rotateLeft)
        {
            _transformAdapter.rotation = _spacecraftSimulation.Rotate(_transformAdapter.rotation, 10.0f);
        }
        
        if (_rotateRight)
        {
            _transformAdapter.rotation = _spacecraftSimulation.Rotate(_transformAdapter.rotation, -10.0f);
        }

        // TODO: add force gradually with some step (e.g. each 200ms)
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
