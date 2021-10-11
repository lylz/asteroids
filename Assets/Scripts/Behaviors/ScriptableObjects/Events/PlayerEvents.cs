using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Player Events")]
public class PlayerEvents : ScriptableObject, IPlayerEvents
{
    public event UnityAction<Vector3> PlayerSpawned = delegate { };
    public event UnityAction PlayerDied = delegate { };
    
    public void InvokePlayerSpawned(Vector3 position)
    {
        PlayerSpawned.Invoke(position);
    }

    public void InvokePlayerDied()
    {
        PlayerDied.Invoke();
    }
}
