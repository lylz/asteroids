using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Game Events")]
public class GameEvents : ScriptableObject, IGameEvents
{
    public event UnityAction GameRestarted = delegate { };
    public event UnityAction GameExit = delegate { };

    public void InvokeGameRestarted()
    {
        GameRestarted.Invoke();
    }

    public void InvokeGameExit()
    {
        GameExit.Invoke();
    }
}
