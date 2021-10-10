using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapons/Laser Info Tracker")]
public class LaserInfoTracker : ScriptableObject, ILaserInfoTracker
{
    public uint Charges { get; set; }
    public float CooldownTime { get; set; }
    public float RechargeTime { get; set; }
}
