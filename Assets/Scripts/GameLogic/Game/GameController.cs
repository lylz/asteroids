using System.Collections.Generic;
using UnityEngine;

public interface IGameController
{
    public void Start();
    public void OnDestroy();
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

    public void OnDestroy()
    {
        _spawnManager.OnDestroy();
    }
}
