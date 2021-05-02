// GENERATED AUTOMATICALLY FROM 'Assets/DataAssets/Input/FarmingGameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FarmingGameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FarmingGameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FarmingGameControls"",
    ""maps"": [
        {
            ""name"": ""GameplayActionMap"",
            ""id"": ""76467d94-954c-4d78-a633-071b47c07bb7"",
            ""actions"": [
                {
                    ""name"": ""MovementVector"",
                    ""type"": ""Value"",
                    ""id"": ""876fbc67-5f89-4435-96a6-0c2bcc2a32fa"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b63f85c5-47e5-42be-bdd4-8de3e335a4b1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a4d41eb8-68c7-47a0-a444-df5863510a50"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVector"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eb2d6e62-2557-40a3-b624-de5966c000c6"",
                    ""path"": ""<Keyboard>/W"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7aec2736-41de-4840-b795-b51ee8939e4a"",
                    ""path"": ""<Keyboard>/S"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fa2bb233-a3e3-474e-9c9a-b6065edaead4"",
                    ""path"": ""<Keyboard>/A"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a7011da-020a-4dec-a7b1-76661037ffdd"",
                    ""path"": ""<Keyboard>/D"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayActionMap
        m_GameplayActionMap = asset.FindActionMap("GameplayActionMap", throwIfNotFound: true);
        m_GameplayActionMap_MovementVector = m_GameplayActionMap.FindAction("MovementVector", throwIfNotFound: true);
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

    // GameplayActionMap
    private readonly InputActionMap m_GameplayActionMap;
    private IGameplayActionMapActions m_GameplayActionMapActionsCallbackInterface;
    private readonly InputAction m_GameplayActionMap_MovementVector;
    public struct GameplayActionMapActions
    {
        private @FarmingGameControls m_Wrapper;
        public GameplayActionMapActions(@FarmingGameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementVector => m_Wrapper.m_GameplayActionMap_MovementVector;
        public InputActionMap Get() { return m_Wrapper.m_GameplayActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActionMapActions instance)
        {
            if (m_Wrapper.m_GameplayActionMapActionsCallbackInterface != null)
            {
                @MovementVector.started -= m_Wrapper.m_GameplayActionMapActionsCallbackInterface.OnMovementVector;
                @MovementVector.performed -= m_Wrapper.m_GameplayActionMapActionsCallbackInterface.OnMovementVector;
                @MovementVector.canceled -= m_Wrapper.m_GameplayActionMapActionsCallbackInterface.OnMovementVector;
            }
            m_Wrapper.m_GameplayActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementVector.started += instance.OnMovementVector;
                @MovementVector.performed += instance.OnMovementVector;
                @MovementVector.canceled += instance.OnMovementVector;
            }
        }
    }
    public GameplayActionMapActions @GameplayActionMap => new GameplayActionMapActions(this);
    public interface IGameplayActionMapActions
    {
        void OnMovementVector(InputAction.CallbackContext context);
    }
}
