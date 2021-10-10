using UnityEngine;

[CreateAssetMenu(menuName = "Game/Enemies/Asteroid")]
public class AsteroidConfig : ScriptableObject, IAsteroidConfig
{
    public float scale;
    public float Scale { get => scale; }

    public float speed;
    public float Speed { get => speed; }

    public float rotationAngle;
    public float RotationAngle { get => rotationAngle; }

    public uint spawnCount;
    public uint SpawnCount { get => spawnCount; }

    public Asteroid spawnAsteroidPrefab;
    public IAsteroid SpawnAsteroidPrefab { get => spawnAsteroidPrefab; }
}
