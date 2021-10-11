using UnityEngine;
using UnityEngine.Events;

public interface IPlayerEvents
{
    public event UnityAction<Vector3> PlayerSpawned;
    public event UnityAction PlayerDied;

    public void InvokePlayerSpawned(Vector3 position);
    public void InvokePlayerDied();
}
