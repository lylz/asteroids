using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour, ITransformAdapter
{
    public SpacecraftSimulationProperties SpacecraftSimulationProperties;

    [SerializeField]
    private InputSystem _inputSystem;

    private SpacecraftSimulation _spacecraftSimulation;
    private SpacecraftController _spacecraftController;

    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Quaternion rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }

    public Vector3 lookDirection
    {
        get { return transform.up; }
    }

    private void Awake()
    {
        _spacecraftSimulation = new SpacecraftSimulation(SpacecraftSimulationProperties);
        _spacecraftController = new SpacecraftController(_spacecraftSimulation, _inputSystem, this);
    }

    private void FixedUpdate()
    {
        _spacecraftController.FixedUpdate(Time.fixedDeltaTime);
    }
}
