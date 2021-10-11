using UnityEngine;

public class SpawnManagerBehavior : MonoBehaviour
{
    public EnemyEvents EnemyEvents;

    private void Start()
    {
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

    private void OnDisable()
    {
        EnemyEvents.EnemySpawned -= OnEnemySpawned;
    }
}
