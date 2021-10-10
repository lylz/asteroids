using UnityEngine.Events;

public interface IGameEvents
{
    public event UnityAction GameStarted;
    public void InvokeGameStarted();
}
