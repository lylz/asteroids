public interface ISpawnWave
{
    public ISpawnWaveEntry[] SpawnWaveEntries { get; }
}

public interface ISpawnWaveEntry
{
    public IEnemy Enemy { get; }
    public uint Count { get; }
}
