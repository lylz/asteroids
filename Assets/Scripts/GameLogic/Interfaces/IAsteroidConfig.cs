public interface IAsteroidConfig
{
    public float Scale { get; }
    public float Speed { get; }
    public float RotationAngle { get; }
    public uint SpawnCount { get; }
    public IAsteroidConfig SpawnAsteroidConfig { get; }
}
