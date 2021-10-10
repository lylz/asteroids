using UnityEngine;
using UnityEngine.Events;

public interface IAsteroidEvents
{
    public event UnityAction<IAsteroid> AsteroidDestroyed;

    public void InvokeAsteroidDestroyed(IAsteroid asteroid);
}
