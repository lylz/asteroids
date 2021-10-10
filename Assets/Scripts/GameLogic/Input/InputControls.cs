// GENERATED AUTOMATICALLY FROM 'Assets/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c98f17e4-cdd6-4f0b-8930-ac072ecc01b2"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""4cbaac80-5c9f-4743-8998-07f6f3d8e353"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""0e2fe51d-bfa4-4aa2-b682-3dc94b523643"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""9c151dcf-d331-4467-bd4a-74cec032f61d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirePrimary"",
                    ""type"": ""Button"",
                    ""id"": ""ada86817-1eae-4d05-bdba-451f3ed9d702"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""2e897ac0-d71d-4bf3-a832-fd64a7a0a246"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61270d5d-ef91-4cb6-8c75-cb8a45932598"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ef7b3dd-82ae-494e-a269-6e157f75b485"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c984e5af-74f9-40a9-b833-fa3efda8d06f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b70d0bc-a753-4cb2-aad4-50237ebf4eba"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2fef4c4-32da-451e-9b68-40bc5b9c8f66"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""dacb3ac6-2f26-4eaf-ad8b-a7c9dc59e554"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""d1f50e94-f1c9-4c1c-a606-fd8a3b511fa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ac84ad1-4fdd-4729-84e1-d6cf631d9ce1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveForward = m_Gameplay.FindAction("MoveForward", throwIfNotFound: true);
        m_Gameplay_RotateRight = m_Gameplay.FindAction("RotateRight", throwIfNotFound: true);
        m_Gameplay_RotateLeft = m_Gameplay.FindAction("RotateLeft", throwIfNotFound: true);
        m_Gameplay_FirePrimary = m_Gameplay.FindAction("FirePrimary", throwIfNotFound: true);
        m_Gameplay_FireSecondary = m_Gameplay.FindAction("FireSecondary", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Start = m_Menu.FindAction("Start", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MoveForward;
    private readonly InputAction m_Gameplay_RotateRight;
    private readonly InputAction m_Gameplay_RotateLeft;
    private readonly InputAction m_Gameplay_FirePrimary;
    private readonly InputAction m_Gameplay_FireSecondary;
    public struct GameplayActions
    {
        private @InputControls m_Wrapper;
        public GameplayActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Gameplay_MoveForward;
        public InputAction @RotateRight => m_Wrapper.m_Gameplay_RotateRight;
        public InputAction @RotateLeft => m_Wrapper.m_Gameplay_RotateLeft;
        public InputAction @FirePrimary => m_Wrapper.m_Gameplay_FirePrimary;
        public InputAction @FireSecondary => m_Wrapper.m_Gameplay_FireSecondary;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @RotateRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateRight;
                @RotateLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateLeft;
                @FirePrimary.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFirePrimary;
                @FireSecondary.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireSecondary;
                @FireSecondary.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireSecondary;
                @FireSecondary.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireSecondary;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @FirePrimary.started += instance.OnFirePrimary;
                @FirePrimary.performed += instance.OnFirePrimary;
                @FirePrimary.canceled += instance.OnFirePrimary;
                @FireSecondary.started += instance.OnFireSecondary;
                @FireSecondary.performed += instance.OnFireSecondary;
                @FireSecondary.canceled += instance.OnFireSecondary;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Start;
    public struct MenuActions
    {
        private @InputControls m_Wrapper;
        public MenuActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Start => m_Wrapper.m_Menu_Start;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Start.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IGameplayActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnFirePrimary(InputAction.CallbackContext context);
        void OnFireSecondary(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnStart(InputAction.CallbackContext context);
    }
}
