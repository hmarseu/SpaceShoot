//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/GameInput.inputactions
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

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""TestMoteur"",
            ""id"": ""f32ae42e-95cb-4a05-9a0b-25cf01cd8b0c"",
            ""actions"": [
                {
                    ""name"": ""FireMissile1"",
                    ""type"": ""Value"",
                    ""id"": ""22df9d92-0e71-46bb-8721-3d76c8cd2299"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlaceTurret"",
                    ""type"": ""Value"",
                    ""id"": ""875a617a-9740-470b-91b6-b4535d1052f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FollowMouse"",
                    ""type"": ""Value"",
                    ""id"": ""ee1402ed-8187-4fec-8491-8d9533673f80"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FireMissile2"",
                    ""type"": ""Button"",
                    ""id"": ""eadec61c-e245-4d97-80fb-2cb94cdf2d35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FireMissile3"",
                    ""type"": ""Button"",
                    ""id"": ""8ad1385f-4fb4-4bf2-ada8-2275e2dc9c7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01acfa3c-0b54-45c8-9423-2c46bc2f4f47"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireMissile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0567fb07-2128-471e-ad4f-aea2c9cf95ed"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceTurret"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5f34cec-a0eb-4fd8-bfae-ee9ae48cf213"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FollowMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1acb6dc-d3cf-47db-ae9b-4a9561d31d94"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireMissile2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc210ca-a6be-4986-8c5a-34363d55badf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireMissile3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TestMoteur
        m_TestMoteur = asset.FindActionMap("TestMoteur", throwIfNotFound: true);
        m_TestMoteur_FireMissile1 = m_TestMoteur.FindAction("FireMissile1", throwIfNotFound: true);
        m_TestMoteur_PlaceTurret = m_TestMoteur.FindAction("PlaceTurret", throwIfNotFound: true);
        m_TestMoteur_FollowMouse = m_TestMoteur.FindAction("FollowMouse", throwIfNotFound: true);
        m_TestMoteur_FireMissile2 = m_TestMoteur.FindAction("FireMissile2", throwIfNotFound: true);
        m_TestMoteur_FireMissile3 = m_TestMoteur.FindAction("FireMissile3", throwIfNotFound: true);
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

    // TestMoteur
    private readonly InputActionMap m_TestMoteur;
    private List<ITestMoteurActions> m_TestMoteurActionsCallbackInterfaces = new List<ITestMoteurActions>();
    private readonly InputAction m_TestMoteur_FireMissile1;
    private readonly InputAction m_TestMoteur_PlaceTurret;
    private readonly InputAction m_TestMoteur_FollowMouse;
    private readonly InputAction m_TestMoteur_FireMissile2;
    private readonly InputAction m_TestMoteur_FireMissile3;
    public struct TestMoteurActions
    {
        private @GameInput m_Wrapper;
        public TestMoteurActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @FireMissile1 => m_Wrapper.m_TestMoteur_FireMissile1;
        public InputAction @PlaceTurret => m_Wrapper.m_TestMoteur_PlaceTurret;
        public InputAction @FollowMouse => m_Wrapper.m_TestMoteur_FollowMouse;
        public InputAction @FireMissile2 => m_Wrapper.m_TestMoteur_FireMissile2;
        public InputAction @FireMissile3 => m_Wrapper.m_TestMoteur_FireMissile3;
        public InputActionMap Get() { return m_Wrapper.m_TestMoteur; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestMoteurActions set) { return set.Get(); }
        public void AddCallbacks(ITestMoteurActions instance)
        {
            if (instance == null || m_Wrapper.m_TestMoteurActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TestMoteurActionsCallbackInterfaces.Add(instance);
            @FireMissile1.started += instance.OnFireMissile1;
            @FireMissile1.performed += instance.OnFireMissile1;
            @FireMissile1.canceled += instance.OnFireMissile1;
            @PlaceTurret.started += instance.OnPlaceTurret;
            @PlaceTurret.performed += instance.OnPlaceTurret;
            @PlaceTurret.canceled += instance.OnPlaceTurret;
            @FollowMouse.started += instance.OnFollowMouse;
            @FollowMouse.performed += instance.OnFollowMouse;
            @FollowMouse.canceled += instance.OnFollowMouse;
            @FireMissile2.started += instance.OnFireMissile2;
            @FireMissile2.performed += instance.OnFireMissile2;
            @FireMissile2.canceled += instance.OnFireMissile2;
            @FireMissile3.started += instance.OnFireMissile3;
            @FireMissile3.performed += instance.OnFireMissile3;
            @FireMissile3.canceled += instance.OnFireMissile3;
        }

        private void UnregisterCallbacks(ITestMoteurActions instance)
        {
            @FireMissile1.started -= instance.OnFireMissile1;
            @FireMissile1.performed -= instance.OnFireMissile1;
            @FireMissile1.canceled -= instance.OnFireMissile1;
            @PlaceTurret.started -= instance.OnPlaceTurret;
            @PlaceTurret.performed -= instance.OnPlaceTurret;
            @PlaceTurret.canceled -= instance.OnPlaceTurret;
            @FollowMouse.started -= instance.OnFollowMouse;
            @FollowMouse.performed -= instance.OnFollowMouse;
            @FollowMouse.canceled -= instance.OnFollowMouse;
            @FireMissile2.started -= instance.OnFireMissile2;
            @FireMissile2.performed -= instance.OnFireMissile2;
            @FireMissile2.canceled -= instance.OnFireMissile2;
            @FireMissile3.started -= instance.OnFireMissile3;
            @FireMissile3.performed -= instance.OnFireMissile3;
            @FireMissile3.canceled -= instance.OnFireMissile3;
        }

        public void RemoveCallbacks(ITestMoteurActions instance)
        {
            if (m_Wrapper.m_TestMoteurActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITestMoteurActions instance)
        {
            foreach (var item in m_Wrapper.m_TestMoteurActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TestMoteurActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TestMoteurActions @TestMoteur => new TestMoteurActions(this);
    public interface ITestMoteurActions
    {
        void OnFireMissile1(InputAction.CallbackContext context);
        void OnPlaceTurret(InputAction.CallbackContext context);
        void OnFollowMouse(InputAction.CallbackContext context);
        void OnFireMissile2(InputAction.CallbackContext context);
        void OnFireMissile3(InputAction.CallbackContext context);
    }
}
