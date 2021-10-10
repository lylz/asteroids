using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Spawn Event")]
public class SpawnEvents : ScriptableObject, ISpawnEvents
{
    public event UnityAction<IAsteroid, Vector3, Quaternion> AsteroidSpawned = delegate {};
    public event UnityAction<IUFO, Vector3, Quaternion> UFOSpawned = delegate {};

    public void InvokeAsteroidSpawned(IAsteroid asteroid, Vector3 position, Quaternion rotation)
    {
        AsteroidSpawned.Invoke(asteroid, position, rotation);
    }

    public void InvokeUFOSpawned(IUFO ufo, Vector3 position, Quaternion rotation)
    {
        UFOSpawned.Invoke(ufo, position, rotation);
    }
}
