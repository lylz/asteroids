public interface IGameController
{
    public void Start();
}

public class GameController : IGameController
{
    private ISpawnManager _spawnManager;
    private IGameEvents _gameEvents;

    public GameController(ISpawnManager spawnManager, IGameEvents gameEvents)
    {
        _spawnManager = spawnManager;
        _gameEvents = gameEvents;
    }

    public void Start()
    {
        _spawnManager.Start();
    }
}
