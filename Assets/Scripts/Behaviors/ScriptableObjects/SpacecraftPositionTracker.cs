using UnityEngine;

[CreateAssetMenu(menuName = "Game/Spacecraft/Spacecraft Position Tracker")]
public class SpacecraftPositionTracker : ScriptableObject, ISpacecraftPositionTracker
{
    public Vector3 Position { get; set; }
}
