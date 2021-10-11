using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    public InputControlsSystem InputSystem;
    public ScreenBounds ScreenBounds;

    [Header("Score Manager")]
    public ScoreStorage ScoreStorage;

    [Header("Spawn Manager")]
    public SpawnWave[] SpawnWaves;

    [Header("Events")]
    public GameEvents GameEvents;
    public PlayerEvents PlayerEvents;
    public EnemyEvents EnemyEvents;

    private GameController _gameController;
    private SpawnManager _spawnManager;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ScreenBounds.bounds = screenBounds * 2;

        _spawnManager = new SpawnManager(PlayerEvents, SpawnWaves, EnemyEvents, ScreenBounds);
        _gameController = new GameController(InputSystem, _spawnManager, GameEvents);
        _scoreManager = new ScoreManager(ScoreStorage, GameEvents, EnemyEvents, PlayerEvents);

        GameEvents.GameRestarted += OnGameRestarted;
        GameEvents.GameExit += OnGameExit;
    }

    private void Start()
    {
        InputSystem.EnableGameplayInput();
        _gameController.Start();
    }

    private void Update()
    {
        _gameController.Update(Time.deltaTime);
    }

    private void OnGameExit()
    {
        Application.Quit();
    }

    private void OnGameRestarted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        GameEvents.GameRestarted -= OnGameRestarted;
        GameEvents.GameExit -= OnGameExit;
    }
}
