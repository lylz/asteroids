public interface IGameController
{
    public void Start();
    public void Update(float dt);
}

public class GameController : IGameController
{
    private ISpawnManager _spawnManager;
    private IGameEvents _gameEvents;
    private InputControlsSystem _inputSystem;

    private bool _exitHold;
    private Timer _exitTimer;

    public GameController(
        InputControlsSystem inputSystem,
        ISpawnManager spawnManager,
        IGameEvents gameEvents
    )
    {
        _inputSystem = inputSystem;
        _spawnManager = spawnManager;
        _gameEvents = gameEvents;

        _inputSystem.GlobalExitEvent += OnExit;
    }

    public void Start()
    {
        _spawnManager.Start();
    }

    public void Update(float dt)
    {
        _exitTimer?.Tick(dt);

        if (_exitTimer?.IsFinished == true)
        {
            Exit();
        }
    }

    private void Exit()
    {
        _gameEvents.InvokeGameExit();
    }

    private void OnExit()
    {
        if (!_exitHold)
        {
            StartExitTimer();
        }
        else
        {
            StopExitTimer();
        }

        _exitHold = !_exitHold;
    }

    private void StartExitTimer()
    {
        _exitTimer = new Timer(3.0f);
    }

    private void StopExitTimer()
    {
        _exitTimer = null;
    }
}
