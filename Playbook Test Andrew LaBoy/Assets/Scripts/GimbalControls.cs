//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/GimbalControls.inputactions
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

public partial class @GimbalControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GimbalControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GimbalControls"",
    ""maps"": [
        {
            ""name"": ""Gimbal"",
            ""id"": ""dadc7803-a923-4ca9-bedb-b30a37e83193"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f4658ed3-4467-47fc-b3c6-bd6b9f62dd32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InputPosition"",
                    ""type"": ""Value"",
                    ""id"": ""ae5fe00d-9b62-4cf0-98f1-2ea39d141a3e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Transform"",
                    ""type"": ""Value"",
                    ""id"": ""6d76dd1b-7298-4e74-be7b-3b9bf10c6339"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9110912c-b755-4ce2-93d4-41914f9310b2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e83e816d-1c79-4186-9355-776431f808df"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2ed1235-2d8d-4845-9954-d5dd826f4c46"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Transform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gimbal
        m_Gimbal = asset.FindActionMap("Gimbal", throwIfNotFound: true);
        m_Gimbal_Select = m_Gimbal.FindAction("Select", throwIfNotFound: true);
        m_Gimbal_InputPosition = m_Gimbal.FindAction("InputPosition", throwIfNotFound: true);
        m_Gimbal_Transform = m_Gimbal.FindAction("Transform", throwIfNotFound: true);
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

    // Gimbal
    private readonly InputActionMap m_Gimbal;
    private IGimbalActions m_GimbalActionsCallbackInterface;
    private readonly InputAction m_Gimbal_Select;
    private readonly InputAction m_Gimbal_InputPosition;
    private readonly InputAction m_Gimbal_Transform;
    public struct GimbalActions
    {
        private @GimbalControls m_Wrapper;
        public GimbalActions(@GimbalControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Gimbal_Select;
        public InputAction @InputPosition => m_Wrapper.m_Gimbal_InputPosition;
        public InputAction @Transform => m_Wrapper.m_Gimbal_Transform;
        public InputActionMap Get() { return m_Wrapper.m_Gimbal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GimbalActions set) { return set.Get(); }
        public void SetCallbacks(IGimbalActions instance)
        {
            if (m_Wrapper.m_GimbalActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_GimbalActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GimbalActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GimbalActionsCallbackInterface.OnSelect;
                @InputPosition.started -= m_Wrapper.m_GimbalActionsCallbackInterface.OnInputPosition;
                @InputPosition.performed -= m_Wrapper.m_GimbalActionsCallbackInterface.OnInputPosition;
                @InputPosition.canceled -= m_Wrapper.m_GimbalActionsCallbackInterface.OnInputPosition;
                @Transform.started -= m_Wrapper.m_GimbalActionsCallbackInterface.OnTransform;
                @Transform.performed -= m_Wrapper.m_GimbalActionsCallbackInterface.OnTransform;
                @Transform.canceled -= m_Wrapper.m_GimbalActionsCallbackInterface.OnTransform;
            }
            m_Wrapper.m_GimbalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @InputPosition.started += instance.OnInputPosition;
                @InputPosition.performed += instance.OnInputPosition;
                @InputPosition.canceled += instance.OnInputPosition;
                @Transform.started += instance.OnTransform;
                @Transform.performed += instance.OnTransform;
                @Transform.canceled += instance.OnTransform;
            }
        }
    }
    public GimbalActions @Gimbal => new GimbalActions(this);
    public interface IGimbalActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnInputPosition(InputAction.CallbackContext context);
        void OnTransform(InputAction.CallbackContext context);
    }
}