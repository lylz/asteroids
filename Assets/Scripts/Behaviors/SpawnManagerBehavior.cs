using UnityEngine;

public class SpawnManagerBehavior : MonoBehaviour
{
    [Header("Player")]
    public Spacecraft SpacecraftPrefab;

    [Header("Events")]
    public PlayerEvents PlayerEvents;
    public EnemyEvents EnemyEvents;

    private void Start()
    {
        PlayerEvents.PlayerSpawned += OnPlayerSpawned;
        EnemyEvents.EnemySpawned += OnEnemySpawned;
    }

    private void OnPlayerSpawned(Vector3 position)
    {
        Instantiate(SpacecraftPrefab, position, Quaternion.identity);
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

    private void OnDisable()
    {
        PlayerEvents.PlayerSpawned -= OnPlayerSpawned;
        EnemyEvents.EnemySpawned -= OnEnemySpawned;
    }
}
