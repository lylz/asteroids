using UnityEngine;

public class SpawnManagerBehavior : MonoBehaviour
{
    public GameEvents GameEvents;
    public EnemyEvents EnemyEvents;
    public SpawnWave[] SpawnWaves;

    private ISpawnManager _spawnManager;

    private void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _spawnManager = new SpawnManager(GameEvents, SpawnWaves, EnemyEvents, screenBounds);

        EnemyEvents.EnemySpawned += OnEnemySpawned;
    }

    private void OnEnemySpawned(IEnemy enemy, Vector3 position, Quaternion rotation)
    {
        if (enemy is Asteroid)
        {
            Instantiate(enemy as Asteroid, position, rotation);
        }
        else if (enemy is UFO)
        {
            Instantiate(enemy as UFO, position, rotation);
        }
        else
        {
            // TODO: throw an error
        }
    }
}
