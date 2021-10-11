using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    public GameEvents GameEvents;

    [Header("Spawn Manager")]
    public EnemyEvents EnemyEvents;
    public SpawnWave[] SpawnWaves;

    private GameController _gameController;
    private SpawnManager _spawnManager;

    private void Awake()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _spawnManager = new SpawnManager(SpawnWaves, EnemyEvents, screenBounds);
        _gameController = new GameController(_spawnManager, GameEvents);
    }

    private void Start()
    {
        _gameController.Start();
    }

    private void OnDestroy()
    {
        _gameController.OnDestroy();
    }
}
