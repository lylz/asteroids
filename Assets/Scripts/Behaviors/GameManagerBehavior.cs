using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    public GameEvents GameEvents;

    [Header("Score Manager")]
    public ScoreStorage ScoreStorage;
    public PlayerEvents PlayerEvents;

    [Header("Spawn Manager")]
    public EnemyEvents EnemyEvents;
    public SpawnWave[] SpawnWaves;

    private GameController _gameController;
    private SpawnManager _spawnManager;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _spawnManager = new SpawnManager(SpawnWaves, EnemyEvents, screenBounds);
        _gameController = new GameController(_spawnManager, GameEvents);
        _scoreManager = new ScoreManager(ScoreStorage, EnemyEvents, PlayerEvents);

        GameEvents.GameRestarted += OnGameRestarted;
    }

    private void Start()
    {
        _gameController.Start();
    }

    private void OnGameRestarted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        GameEvents.GameRestarted -= OnGameRestarted;
    }
}
