using UnityEngine;
using UnityEngine.Events;

public interface ISpawnEvents
{
    public event UnityAction<IAsteroid, Vector3, Quaternion> AsteroidSpawned;
    public event UnityAction<IUFO, Vector3, Quaternion> UFOSpawned;

    public void InvokeAsteroidSpawned(IAsteroid asteroid, Vector3 position, Quaternion rotation);
    public void InvokeUFOSpawned(IUFO ufo, Vector3 position, Quaternion rotation);
}
