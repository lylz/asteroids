using UnityEngine;

[CreateAssetMenu(menuName = "Game/Screen Bounds")]
public class ScreenBounds : ScriptableObject, IScreenBounds
{
    public Vector2 bounds;

    public Vector2 Bounds { get => bounds; }
}
