using UnityEngine;

[System.Serializable]
public struct SpacecraftSimulationProperties
{
    public float rotationAngle;
    public float mass;
    public float drag;
}

public class SpacecraftSimulation
{
    public SpacecraftSimulationProperties Properties;

    private Vector3 _velocity;
    private Vector3 _acceleration;

    public SpacecraftSimulation(SpacecraftSimulationProperties properties)
    {
        Properties = properties;
    }

    public Vector3 UpdatePosition(Vector3 position, float dt)
    {
        _velocity *= Mathf.Clamp01(1f - Properties.drag * dt);

        return position + _velocity * dt;
    }

    public void AddForce(Vector2 force)
    {
        float mass = Properties.mass != 0 ? Properties.mass : 0.1f;

        _acceleration = force / mass;
        _velocity += _acceleration;
    }
    
    public Quaternion RotateLeft(Quaternion rotation)
    {
        return Rotate(rotation, Properties.rotationAngle);
    }

    public Quaternion RotateRight(Quaternion rotation)
    {
        return Rotate(rotation, -Properties.rotationAngle);
    }

    private Quaternion Rotate(Quaternion rotation, float angle)
    {
        return rotation * Quaternion.Euler(Vector3.forward * angle);
    }
}
