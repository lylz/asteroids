public interface ILaserWeaponConfig : IWeaponConfig
{
    public float LaserLength { get; }
    public float LaserActiveTimeInSeconds { get; }
    public uint MaxCharges { get; }
    public float FireCooldownInSeconds { get; }
    public float RechargeCooldownInSeconds { get; }
}
