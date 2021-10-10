using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Enemy Events")]
public class EnemyEvents : ScriptableObject, IEnemyEvents
{
    public event UnityAction<IEnemy, Vector3, Quaternion> EnemySpawned = delegate { };
    public event UnityAction<IEnemy> EnemyDestroyed = delegate { };

    public void InvokeEnemySpawned(IEnemy enemy, Vector3 position, Quaternion rotation)
    {
        EnemySpawned.Invoke(enemy, position, rotation);
    }

    public void InvokeEnemyDestroyed(IEnemy enemy)
    {
        EnemyDestroyed.Invoke(enemy);
    }
}
