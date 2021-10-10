using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Input/Input System")]
public class InputControlsSystem : ScriptableObject, InputControls.IGameplayActions, InputControls.IMenuActions
{
    public event UnityAction MoveForwardEvent = delegate {};
    public event UnityAction RotateRightEvent = delegate {};
    public event UnityAction RotateLeftEvent = delegate {};
    public event UnityAction FirePrimaryEvent = delegate {};
    public event UnityAction FireSecondaryEvent = delegate {};
    // TODO: move menu events in different input class?
    // TODO: disable player input
    // TODO: disable menu input
    public event UnityAction MenuStartEvent = delegate {};

    private InputControls _inputControls;

    private void OnEnable()
    {
        if (_inputControls == null)
        {
            _inputControls = new InputControls();
            _inputControls.Gameplay.SetCallbacks(this);
            _inputControls.Menu.SetCallbacks(this);

            EnableInput();
        }
    }

    private void OnDisable()
    {
        DisableInput();
    }

    public void OnMoveForward(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            MoveForwardEvent.Invoke();
        }
    }

    public void OnRotateRight(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            RotateRightEvent.Invoke();
        }
    }

    public void OnRotateLeft(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            RotateLeftEvent.Invoke();
        }
    }

    public void OnFirePrimary(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FirePrimaryEvent.Invoke();
        }
    }

    public void OnFireSecondary(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FireSecondaryEvent.Invoke();
        }
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MenuStartEvent.Invoke();
        }
    }

    public void EnableInput()
    {
        _inputControls.Gameplay.Enable();
        _inputControls.Menu.Enable();
    }

    public void DisableInput()
    {
        _inputControls.Gameplay.Disable();
        _inputControls.Menu.Disable();
    }
}
