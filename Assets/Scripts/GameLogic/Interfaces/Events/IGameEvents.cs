using UnityEngine.Events;

public interface IGameEvents
{
    public event UnityAction GameRestarted;
    public void InvokeGameRestarted();
}
