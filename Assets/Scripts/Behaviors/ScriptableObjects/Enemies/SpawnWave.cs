using UnityEngine;

[System.Serializable]
public class SpawnWaveEntry : ISpawnWaveEntry
{
    public Enemy enemy;
    public IEnemy Enemy { get => enemy; }

    public uint count;
    public uint Count { get => count; }

    public float initialSpawnDelayInSeconds;
    public float InitialSpawnDelayInSeconds { get => initialSpawnDelayInSeconds; }
}

[CreateAssetMenu(menuName = "Game/Enemies/Spawn Wave")]
public class SpawnWave : ScriptableObject, ISpawnWave
{
    public SpawnWaveEntry[] spawnWaveEntries;
    public ISpawnWaveEntry[] SpawnWaveEntries { get => spawnWaveEntries; }
}
