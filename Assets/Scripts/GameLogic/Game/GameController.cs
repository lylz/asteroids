using System.Collections.Generic;

public interface IGameController
{
    public List<IEnemy> Enemies { get; }
}

public class GameController : IGameController
{
    private List<IEnemy> _enemies = new List<IEnemy>();
    public List<IEnemy> Enemies { get => _enemies; }

    private IGameEvents _gameEvents;

    public GameController(IGameEvents gameEvents)
    {
        _gameEvents = gameEvents;
    }

    public void Start()
    {
        _gameEvents.InvokeGameStarted();
    }
}
