using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Input/Input System")]
public class InputControlsSystem : ScriptableObject,
    InputControls.IGameplayActions,
    InputControls.IMenuActions,
    InputControls.IGlobalActions
{
    public event UnityAction MoveForwardEvent = delegate {};
    public event UnityAction RotateRightEvent = delegate {};
    public event UnityAction RotateLeftEvent = delegate {};
    public event UnityAction FirePrimaryEvent = delegate {};
    public event UnityAction FireSecondaryEvent = delegate {};
    public event UnityAction MenuStartEvent = delegate {};
    public event UnityAction GlobalExitEvent = delegate {};

    private InputControls _inputControls;

    private void OnEnable()
    {
        if (_inputControls == null)
        {
            _inputControls = new InputControls();
            _inputControls.Gameplay.SetCallbacks(this);
            _inputControls.Menu.SetCallbacks(this);
            _inputControls.Global.SetCallbacks(this);

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

    public void OnExit(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            GlobalExitEvent.Invoke();
        }
    }

    public void EnableInput()
    {
        _inputControls.Gameplay.Enable();
        _inputControls.Global.Enable();
    }

    public void EnableGameplayInput()
    {
        _inputControls.Gameplay.Enable();
        _inputControls.Global.Enable();
        _inputControls.Menu.Disable();
    }

    public void EnableMenuInput()
    {
        _inputControls.Menu.Enable();
        _inputControls.Gameplay.Disable();
    }

    public void DisableInput()
    {
        _inputControls.Gameplay.Disable();
        _inputControls.Menu.Disable();
        _inputControls.Global.Disable();
    }
}
