using UnityEngine;
using UnityEngine.Events;

public interface IUFOEvents
{
    public event UnityAction<IUFO> UFODestroyed;

    public void InvokeUFODestroyed(IUFO ufo);
}
