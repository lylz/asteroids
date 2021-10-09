using UnityEngine;

public interface ISpacecraftPositionTracker
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 InstantSpeed { get; set; }
}
