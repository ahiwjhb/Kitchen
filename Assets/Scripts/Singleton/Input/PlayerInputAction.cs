//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Singleton/Input/PlayerInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""GamePlayInput"",
            ""id"": ""e3fe32e4-02b0-4fe8-a31a-c3b7a23e235f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4058cce6-ffb3-4812-bdf0-fd59f2f18cab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d39fdff3-9968-4f79-898e-ff5d1c268378"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryInteract"",
                    ""type"": ""Button"",
                    ""id"": ""eaec772a-b73e-4e40-b3c4-552882b653be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""af7b7a44-5dce-406b-ae29-21954bcf93a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7b6b4f7d-9610-4ecf-8092-b0c08430b0c3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a9306d8-2d6e-4cad-8d27-2e0bc13c3e02"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0e27ad50-2147-4272-8df3-a8dd0d79317a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4b11cbba-410a-42cd-9c30-96d774f24f41"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""08f5e0e0-e472-4dc3-9ed3-ee4140fed693"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b717e320-292f-4912-9cc2-51230a20cbd2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6458ed56-b368-429c-b21a-e118df48c533"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""692e77e3-52f2-4a74-ab3a-206bed705f73"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlayInput
        m_GamePlayInput = asset.FindActionMap("GamePlayInput", throwIfNotFound: true);
        m_GamePlayInput_Move = m_GamePlayInput.FindAction("Move", throwIfNotFound: true);
        m_GamePlayInput_Interact = m_GamePlayInput.FindAction("Interact", throwIfNotFound: true);
        m_GamePlayInput_SecondaryInteract = m_GamePlayInput.FindAction("SecondaryInteract", throwIfNotFound: true);
        m_GamePlayInput_Pause = m_GamePlayInput.FindAction("Pause", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GamePlayInput
    private readonly InputActionMap m_GamePlayInput;
    private List<IGamePlayInputActions> m_GamePlayInputActionsCallbackInterfaces = new List<IGamePlayInputActions>();
    private readonly InputAction m_GamePlayInput_Move;
    private readonly InputAction m_GamePlayInput_Interact;
    private readonly InputAction m_GamePlayInput_SecondaryInteract;
    private readonly InputAction m_GamePlayInput_Pause;
    public struct GamePlayInputActions
    {
        private @PlayerInputAction m_Wrapper;
        public GamePlayInputActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlayInput_Move;
        public InputAction @Interact => m_Wrapper.m_GamePlayInput_Interact;
        public InputAction @SecondaryInteract => m_Wrapper.m_GamePlayInput_SecondaryInteract;
        public InputAction @Pause => m_Wrapper.m_GamePlayInput_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GamePlayInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayInputActions set) { return set.Get(); }
        public void AddCallbacks(IGamePlayInputActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePlayInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePlayInputActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @SecondaryInteract.started += instance.OnSecondaryInteract;
            @SecondaryInteract.performed += instance.OnSecondaryInteract;
            @SecondaryInteract.canceled += instance.OnSecondaryInteract;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IGamePlayInputActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @SecondaryInteract.started -= instance.OnSecondaryInteract;
            @SecondaryInteract.performed -= instance.OnSecondaryInteract;
            @SecondaryInteract.canceled -= instance.OnSecondaryInteract;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IGamePlayInputActions instance)
        {
            if (m_Wrapper.m_GamePlayInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePlayInputActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePlayInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePlayInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePlayInputActions @GamePlayInput => new GamePlayInputActions(this);
    public interface IGamePlayInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSecondaryInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}