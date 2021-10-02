using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpacecraftSimulationProperties
{
    public float mass;
    public float maxVelocity;
}

public class SpacecraftSimulation
{
    public SpacecraftSimulationProperties Properties;

    private Vector3 _initialVelocity;
    private Vector3 _velocity;
    private Vector3 _acceleration;

    public SpacecraftSimulation(SpacecraftSimulationProperties properties)
    {
        Properties = properties;
    }

    public Vector3 UpdatePosition(Vector3 position, float dt)
    {
        Vector3 velocity = Vector3.ClampMagnitude(_velocity, Properties.maxVelocity);

        return position + velocity * dt;
    }

    public void AddForce(Vector2 force)
    {
        float mass = Properties.mass != 0 ? Properties.mass : 1; // TODO: check it

        _acceleration = force / mass;
        _velocity = _initialVelocity + _acceleration;
        _initialVelocity = _velocity;

        // TODO: add linear drag
    }

    public Quaternion Rotate(Quaternion rotation, float angle)
    {
        return rotation * Quaternion.Euler(new Vector3(0, 0, 1) * angle);
    }
}
