using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameEvents GameEvents;

    private GameController _gameController;
    public GameController GameController { get => _gameController; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Only one instance of the GameManager should be present in the scene!");
            return;
        }

        _gameController = new GameController(GameEvents);
        Instance = this;
    }

    private void Start()
    {
        _gameController.Start();
    }
}
