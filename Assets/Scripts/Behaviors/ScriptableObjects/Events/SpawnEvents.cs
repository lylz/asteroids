using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Spawn Event")]
public class SpawnEvents : ScriptableObject, ISpawnEvents
{
    public event UnityAction<IAsteroidConfig, Vector3, Quaternion> AsteroidSpawned = delegate {};
    public event UnityAction<Vector3, Quaternion> UFOSpawned = delegate {};

    public void InvokeAsteroidSpawned(IAsteroidConfig config, Vector3 position, Quaternion rotation)
    {
        AsteroidSpawned.Invoke(config, position, rotation);
    }

    public void InvokeUFOSpawned(Vector3 position, Quaternion rotation)
    {
        UFOSpawned.Invoke(position, rotation);
    }
}
