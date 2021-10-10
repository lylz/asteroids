using UnityEngine;
using UnityEngine.Events;

public interface IEnemyEvents
{
    public event UnityAction<IEnemy, Vector3, Quaternion> EnemySpawned;
    public event UnityAction<IEnemy> EnemyDestroyed;

    public void InvokeEnemySpawned(IEnemy enemy, Vector3 position, Quaternion rotation);
    public void InvokeEnemyDestroyed(IEnemy enemy);
}
