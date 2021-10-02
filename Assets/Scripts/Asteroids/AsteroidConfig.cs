using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Asteroid Config", menuName = "Enemies/Asteroid")]
public class AsteroidConfig : ScriptableObject
{
    public float scale;
    public float speed;
    public float rotationAngle;
    public uint spawnCount;
    public Asteroid spawnAsteroidPrefab;
}
