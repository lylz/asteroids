using UnityEngine.Events;

public interface IPlayerEvents
{
    public event UnityAction PlayerDied;
    public void InvokePlayerDied();
}
