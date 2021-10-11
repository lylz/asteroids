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
        Instantiate(enemy as Enemy, position, rotation);
    }

    private void OnDisable()
    {
        PlayerEvents.PlayerSpawned -= OnPlayerSpawned;
        EnemyEvents.EnemySpawned -= OnEnemySpawned;
    }
}
