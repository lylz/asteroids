using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : BaseBehavior
{
    public SpacecraftSimulationProperties SpacecraftSimulationProperties;

    [SerializeField]
    private InputSystem _inputSystem;

    private SpacecraftSimulation _spacecraftSimulation;
    private SpacecraftController _spacecraftController;

    protected override void Awake()
    {
        base.Awake();

        _spacecraftSimulation = new SpacecraftSimulation(SpacecraftSimulationProperties);
        _spacecraftController = new SpacecraftController(_spacecraftSimulation, _inputSystem, this, _screenBounds);
    }

    private void FixedUpdate()
    {
        _spacecraftController.FixedUpdate(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        _spacecraftController.LateUpdate();
    }
}
