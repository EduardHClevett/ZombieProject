// GENERATED AUTOMATICALLY FROM 'Assets/Inputs.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Inputs : IInputActionCollection
{
    private InputActionAsset asset;
    public Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""16b621a9-6684-437f-bbf2-c634a02e400a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2d803f4a-e541-47f0-b993-1357ffb497e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""9674a281-123d-4d53-a6be-ba00c1e42783"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Value"",
                    ""id"": ""89426aae-efc7-4f28-9227-01da12db97e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Value"",
                    ""id"": ""1dde61b3-4da9-4671-930d-855065e2ec3b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""bbbc1622-10ac-4a4c-85d2-cb40a75b90b5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""1228b1de-3231-4359-abcc-d4e48b8293a5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""90f9a754-0c39-44d5-a35f-d2b5c157d024"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Value"",
                    ""id"": ""9d34ff33-1412-4514-a0ab-9c7b2dac8f2c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookX"",
                    ""type"": ""Value"",
                    ""id"": ""84b9d4c8-c840-4923-8d81-7a68c3e14c7b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookY"",
                    ""type"": ""Value"",
                    ""id"": ""f27b1d17-2d6d-4439-97e3-e13b5145c47e"",
                    ""expectedControlType"": """",
                    ""processors"": ""Invert"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""4ef0d66c-8d86-49db-a507-b6d3459eb1fb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""67de82ed-baf2-4c42-97e7-62c2e6982ea1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KB_Input"",
                    ""id"": ""30da2c2d-2f1d-4eb8-b92b-53e656965025"",
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
                    ""id"": ""cb212dff-5be9-4a12-8e79-fe5f974b46ec"",
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
                    ""id"": ""ef7fe91a-f113-4311-a1ea-173c2abc7d4a"",
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
                    ""id"": ""15632442-be4c-403f-bfd1-1bea6aa472a5"",
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
                    ""id"": ""f9cfc7a0-3a40-4084-9b45-74b81977c442"",
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
                    ""id"": ""e2be9c39-c951-4093-8380-587c2d96d2a8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4bec1f7-62f0-45fd-8f83-2dd9ee191659"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0def9ef8-253b-4e2f-bc48-7784a576178c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4a5f7ae-724f-4654-84e6-9a6ba8230cc3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b97b2020-b7cd-4198-b7b0-fb0a095571ff"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb34ca37-317d-4fef-b220-7a6386fb6819"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf935ae2-9123-47d8-ba45-272fb9460c78"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dad91e4-3a02-49cb-bf0e-0b6353922d50"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4463c5cd-b5cb-49d1-ad8d-2a3eb1be77c7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76fcc6e6-ff2c-43e1-a12b-781df18efe18"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8d2144b-69c6-4e36-aeb1-54bc162be028"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85ce155f-5496-49c0-a2b7-461b53227ee3"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""655338ba-a11d-421c-bd13-8a5abc88253e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20c741c2-0439-4dad-a7d1-eaeeaff6f9c3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbab0aba-4ad6-44d0-a777-fa8aabfd1734"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcd3b845-4ed8-4ec0-b9b9-5daef9951e84"",
                    ""path"": ""<XInputController>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efa06fc2-f05d-498e-bff7-9652be945bd8"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e402146-c057-47bc-994f-3b0e32333300"",
                    ""path"": ""<XInputController>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e00fd3fd-bb83-4de8-a784-098d55b1691c"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90adc9b4-2080-4e32-b884-95af5ada729b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_Jump = m_InGame.FindAction("Jump", throwIfNotFound: true);
        m_InGame_Interact = m_InGame.FindAction("Interact", throwIfNotFound: true);
        m_InGame_Reload = m_InGame.FindAction("Reload", throwIfNotFound: true);
        m_InGame_Shoot = m_InGame.FindAction("Shoot", throwIfNotFound: true);
        m_InGame_Aim = m_InGame.FindAction("Aim", throwIfNotFound: true);
        m_InGame_Sprint = m_InGame.FindAction("Sprint", throwIfNotFound: true);
        m_InGame_Pause = m_InGame.FindAction("Pause", throwIfNotFound: true);
        m_InGame_LookX = m_InGame.FindAction("LookX", throwIfNotFound: true);
        m_InGame_LookY = m_InGame.FindAction("LookY", throwIfNotFound: true);
        m_InGame_SwitchWeapon = m_InGame.FindAction("SwitchWeapon", throwIfNotFound: true);
    }

    ~Inputs()
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

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_Jump;
    private readonly InputAction m_InGame_Interact;
    private readonly InputAction m_InGame_Reload;
    private readonly InputAction m_InGame_Shoot;
    private readonly InputAction m_InGame_Aim;
    private readonly InputAction m_InGame_Sprint;
    private readonly InputAction m_InGame_Pause;
    private readonly InputAction m_InGame_LookX;
    private readonly InputAction m_InGame_LookY;
    private readonly InputAction m_InGame_SwitchWeapon;
    public struct InGameActions
    {
        private Inputs m_Wrapper;
        public InGameActions(Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @Jump => m_Wrapper.m_InGame_Jump;
        public InputAction @Interact => m_Wrapper.m_InGame_Interact;
        public InputAction @Reload => m_Wrapper.m_InGame_Reload;
        public InputAction @Shoot => m_Wrapper.m_InGame_Shoot;
        public InputAction @Aim => m_Wrapper.m_InGame_Aim;
        public InputAction @Sprint => m_Wrapper.m_InGame_Sprint;
        public InputAction @Pause => m_Wrapper.m_InGame_Pause;
        public InputAction @LookX => m_Wrapper.m_InGame_LookX;
        public InputAction @LookY => m_Wrapper.m_InGame_LookY;
        public InputAction @SwitchWeapon => m_Wrapper.m_InGame_SwitchWeapon;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                Jump.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                Interact.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnInteract;
                Reload.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnReload;
                Reload.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnReload;
                Reload.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnReload;
                Shoot.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnShoot;
                Aim.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnAim;
                Aim.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnAim;
                Aim.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnAim;
                Sprint.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnSprint;
                Sprint.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnSprint;
                Pause.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                Pause.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                Pause.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                LookX.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookX;
                LookX.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookX;
                LookX.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookX;
                LookY.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookY;
                LookY.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookY;
                LookY.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookY;
                SwitchWeapon.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnSwitchWeapon;
                SwitchWeapon.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnSwitchWeapon;
                SwitchWeapon.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnSwitchWeapon;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
                Reload.started += instance.OnReload;
                Reload.performed += instance.OnReload;
                Reload.canceled += instance.OnReload;
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                Aim.started += instance.OnAim;
                Aim.performed += instance.OnAim;
                Aim.canceled += instance.OnAim;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.canceled += instance.OnSprint;
                Pause.started += instance.OnPause;
                Pause.performed += instance.OnPause;
                Pause.canceled += instance.OnPause;
                LookX.started += instance.OnLookX;
                LookX.performed += instance.OnLookX;
                LookX.canceled += instance.OnLookX;
                LookY.started += instance.OnLookY;
                LookY.performed += instance.OnLookY;
                LookY.canceled += instance.OnLookY;
                SwitchWeapon.started += instance.OnSwitchWeapon;
                SwitchWeapon.performed += instance.OnSwitchWeapon;
                SwitchWeapon.canceled += instance.OnSwitchWeapon;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnLookX(InputAction.CallbackContext context);
        void OnLookY(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
    }
}