using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="Game/Game Events/UFO Event")]
public class UFOEvents : ScriptableObject, IUFOEvents 
{
    public event UnityAction<IUFO> UFODestroyed = delegate { };

    public void InvokeUFODestroyed(IUFO ufo)
    {
        UFODestroyed.Invoke(ufo);
    }
}
