using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Game Events/Asteroid Events")]
public class AsteroidEvents : ScriptableObject, IAsteroidEvents
{
    public event UnityAction<IAsteroid> AsteroidDestroyed = delegate { };

    public void InvokeAsteroidDestroyed(IAsteroid asteroid)
    {
        AsteroidDestroyed.Invoke(asteroid);
    }
}
