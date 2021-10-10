using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    public GameEvents GameEvents;

    private GameController _gameController;
    public GameController GameController { get => _gameController; }

    private void Awake()
    {
        _gameController = new GameController(GameEvents);
    }

    private void Start()
    {
        _gameController.Start();
    }
}
