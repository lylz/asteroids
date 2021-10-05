using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Input/Input System")]
public class InputControlsSystem : ScriptableObject, InputControls.IGameplayActions
{
    public event UnityAction MoveForwardEvent = delegate {};
    public event UnityAction RotateRightEvent = delegate {};
    public event UnityAction RotateLeftEvent = delegate {};
    public event UnityAction FirePrimaryEvent = delegate {};
    public event UnityAction FireSecondaryEvent = delegate {};

    private InputControls _inputControls;

    private void OnEnable()
    {
        if (_inputControls == null)
        {
            _inputControls = new InputControls();
            _inputControls.Gameplay.SetCallbacks(this);

            EnableInput();
        }
    }

    private void OnDisable()
    {
        DisableInput();
    }

    public void OnMoveForward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveForwardEvent.Invoke();
        }
    }

    public void OnRotateRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RotateRightEvent.Invoke();
        }
    }

    public void OnRotateLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
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

    public void EnableInput()
    {
        _inputControls.Gameplay.Enable();
    }

    public void DisableInput()
    {
        _inputControls.Gameplay.Disable();
    }
}
