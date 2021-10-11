using UnityEngine.Events;

public interface IGameEvents
{
    public event UnityAction GameRestarted;
    public event UnityAction GameExit;

    public void InvokeGameRestarted();
    public void InvokeGameExit();
}
