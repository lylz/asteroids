using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Player Event")]
public class PlayerEvents : ScriptableObject, IPlayerEvents
{
    public event UnityAction PlayerDied = delegate { };

    public void InvokePlayerDied()
    {
        PlayerDied.Invoke();
    }
}
