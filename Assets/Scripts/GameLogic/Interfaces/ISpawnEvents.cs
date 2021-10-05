using UnityEngine;
using UnityEngine.Events;

public interface ISpawnEvents
{
    public event UnityAction<IAsteroidConfig, Vector3, Quaternion> AsteroidSpawned;
    public event UnityAction<Vector3, Quaternion> UFOSpawned;

    public void InvokeAsteroidSpawned(IAsteroidConfig config, Vector3 position, Quaternion rotation);
    public void InvokeUFOSpawned(Vector3 position, Quaternion rotation);
}
