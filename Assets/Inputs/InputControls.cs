//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/InputControls.inputactions
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

public partial class @InputControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""MasterActions"",
            ""id"": ""228de6a8-420d-4ed8-b2c1-88efbe0255ab"",
            ""actions"": [
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""93748024-9d28-4b35-8acb-332e4149f236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""9f891aea-651c-42b6-8581-856dca8ecf19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""914caf53-3346-4acc-ae23-ec9d4b88c044"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""eb421d3f-c3a1-437f-8c93-14a4ca267b0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""e9e6af3b-ac1b-4427-874b-8f6b2d0b51e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""470dd1bd-8219-480b-a359-6ce77faca9a7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AttackButton"",
                    ""type"": ""Button"",
                    ""id"": ""ae47ee8a-7a1d-438f-8983-d3647aa37146"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChargeAttackButton"",
                    ""type"": ""Button"",
                    ""id"": ""51bdc886-e367-4dc6-84fa-e113903d2f85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d49c5048-d47d-4772-a93a-4b228306e9f1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcf9a1f7-74a9-465d-8eff-d7370bd7e9f8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98acb2b7-ed4e-4b71-9676-8a8a1bc1f0be"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8866a300-232d-4640-9a4f-2dbe9970be27"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bc9e8ca-cdc0-4bf7-8656-ce2f9affeb0d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdfe79f6-52b0-42b6-9d1a-5e055bf04a93"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81cd8dbe-9d4c-4c5d-bbb1-d3f1e7bea964"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54a40b07-ca67-46f5-b5ff-1742b51b32e1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""477eddec-a9dd-47cc-a3a1-4f8472ff943a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""104f4dd0-dbe8-49dd-ac85-ad8f587e730d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""86986aeb-cc18-479e-aca7-8f5e914d5389"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d78ff963-a80b-4359-844c-71ae4a23436e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""218021a3-989b-4d3c-b81e-b1a2630739b8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8c9eabda-0dab-4fc3-a020-3d17fa81a325"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""24d7783e-dcc0-4e4d-8c8c-7dc78d454ac9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""082b0d85-c9be-4a8b-a40d-49623f6f1ac4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""babe9262-171d-418e-92b1-264c22b33938"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1d3f616-bd5d-4adb-b7cd-e1bbec56230d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeAttackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MasterActions
        m_MasterActions = asset.FindActionMap("MasterActions", throwIfNotFound: true);
        m_MasterActions_NorthButton = m_MasterActions.FindAction("NorthButton", throwIfNotFound: true);
        m_MasterActions_WestButton = m_MasterActions.FindAction("WestButton", throwIfNotFound: true);
        m_MasterActions_SouthButton = m_MasterActions.FindAction("SouthButton", throwIfNotFound: true);
        m_MasterActions_EastButton = m_MasterActions.FindAction("EastButton", throwIfNotFound: true);
        m_MasterActions_StartButton = m_MasterActions.FindAction("StartButton", throwIfNotFound: true);
        m_MasterActions_Movement = m_MasterActions.FindAction("Movement", throwIfNotFound: true);
        m_MasterActions_AttackButton = m_MasterActions.FindAction("AttackButton", throwIfNotFound: true);
        m_MasterActions_ChargeAttackButton = m_MasterActions.FindAction("ChargeAttackButton", throwIfNotFound: true);
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

    // MasterActions
    private readonly InputActionMap m_MasterActions;
    private List<IMasterActionsActions> m_MasterActionsActionsCallbackInterfaces = new List<IMasterActionsActions>();
    private readonly InputAction m_MasterActions_NorthButton;
    private readonly InputAction m_MasterActions_WestButton;
    private readonly InputAction m_MasterActions_SouthButton;
    private readonly InputAction m_MasterActions_EastButton;
    private readonly InputAction m_MasterActions_StartButton;
    private readonly InputAction m_MasterActions_Movement;
    private readonly InputAction m_MasterActions_AttackButton;
    private readonly InputAction m_MasterActions_ChargeAttackButton;
    public struct MasterActionsActions
    {
        private @InputControls m_Wrapper;
        public MasterActionsActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NorthButton => m_Wrapper.m_MasterActions_NorthButton;
        public InputAction @WestButton => m_Wrapper.m_MasterActions_WestButton;
        public InputAction @SouthButton => m_Wrapper.m_MasterActions_SouthButton;
        public InputAction @EastButton => m_Wrapper.m_MasterActions_EastButton;
        public InputAction @StartButton => m_Wrapper.m_MasterActions_StartButton;
        public InputAction @Movement => m_Wrapper.m_MasterActions_Movement;
        public InputAction @AttackButton => m_Wrapper.m_MasterActions_AttackButton;
        public InputAction @ChargeAttackButton => m_Wrapper.m_MasterActions_ChargeAttackButton;
        public InputActionMap Get() { return m_Wrapper.m_MasterActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MasterActionsActions set) { return set.Get(); }
        public void AddCallbacks(IMasterActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_MasterActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MasterActionsActionsCallbackInterfaces.Add(instance);
            @NorthButton.started += instance.OnNorthButton;
            @NorthButton.performed += instance.OnNorthButton;
            @NorthButton.canceled += instance.OnNorthButton;
            @WestButton.started += instance.OnWestButton;
            @WestButton.performed += instance.OnWestButton;
            @WestButton.canceled += instance.OnWestButton;
            @SouthButton.started += instance.OnSouthButton;
            @SouthButton.performed += instance.OnSouthButton;
            @SouthButton.canceled += instance.OnSouthButton;
            @EastButton.started += instance.OnEastButton;
            @EastButton.performed += instance.OnEastButton;
            @EastButton.canceled += instance.OnEastButton;
            @StartButton.started += instance.OnStartButton;
            @StartButton.performed += instance.OnStartButton;
            @StartButton.canceled += instance.OnStartButton;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @AttackButton.started += instance.OnAttackButton;
            @AttackButton.performed += instance.OnAttackButton;
            @AttackButton.canceled += instance.OnAttackButton;
            @ChargeAttackButton.started += instance.OnChargeAttackButton;
            @ChargeAttackButton.performed += instance.OnChargeAttackButton;
            @ChargeAttackButton.canceled += instance.OnChargeAttackButton;
        }

        private void UnregisterCallbacks(IMasterActionsActions instance)
        {
            @NorthButton.started -= instance.OnNorthButton;
            @NorthButton.performed -= instance.OnNorthButton;
            @NorthButton.canceled -= instance.OnNorthButton;
            @WestButton.started -= instance.OnWestButton;
            @WestButton.performed -= instance.OnWestButton;
            @WestButton.canceled -= instance.OnWestButton;
            @SouthButton.started -= instance.OnSouthButton;
            @SouthButton.performed -= instance.OnSouthButton;
            @SouthButton.canceled -= instance.OnSouthButton;
            @EastButton.started -= instance.OnEastButton;
            @EastButton.performed -= instance.OnEastButton;
            @EastButton.canceled -= instance.OnEastButton;
            @StartButton.started -= instance.OnStartButton;
            @StartButton.performed -= instance.OnStartButton;
            @StartButton.canceled -= instance.OnStartButton;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @AttackButton.started -= instance.OnAttackButton;
            @AttackButton.performed -= instance.OnAttackButton;
            @AttackButton.canceled -= instance.OnAttackButton;
            @ChargeAttackButton.started -= instance.OnChargeAttackButton;
            @ChargeAttackButton.performed -= instance.OnChargeAttackButton;
            @ChargeAttackButton.canceled -= instance.OnChargeAttackButton;
        }

        public void RemoveCallbacks(IMasterActionsActions instance)
        {
            if (m_Wrapper.m_MasterActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMasterActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_MasterActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MasterActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MasterActionsActions @MasterActions => new MasterActionsActions(this);
    public interface IMasterActionsActions
    {
        void OnNorthButton(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
        void OnSouthButton(InputAction.CallbackContext context);
        void OnEastButton(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnAttackButton(InputAction.CallbackContext context);
        void OnChargeAttackButton(InputAction.CallbackContext context);
    }
}
