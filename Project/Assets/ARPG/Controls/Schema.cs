// GENERATED AUTOMATICALLY FROM 'Assets/ARPG/Controls/Schema.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


namespace Cirrus.ARPG.Playable.Controls
{
    [Serializable]
    public class Schema : InputActionAssetReference
    {
        public Schema()
        {
        }
        public Schema(InputActionAsset asset)
            : base(asset)
        {
        }
        private bool m_Initialized;
        private void Initialize()
        {
            // Character
            m_Character = asset.GetActionMap("Character");
            m_Character_AxesLeft = m_Character.GetAction("Axes.Left");
            m_Character_AxesRight = m_Character.GetAction("Axes.Right");
            m_Character_InventorySwap = m_Character.GetAction("Inventory.Swap");
            m_Character_InventoryToggle = m_Character.GetAction("Inventory.Toggle");
            m_Character_InventoryMovement = m_Character.GetAction("Inventory.Movement");
            m_Character_Jump = m_Character.GetAction("Jump");
            m_Character_Action1 = m_Character.GetAction("Action1");
            m_Character_Action2 = m_Character.GetAction("Action2");
            m_Character_Action3 = m_Character.GetAction("Action3");
            m_Character_Action4 = m_Character.GetAction("Action4");
            m_Character_Action5 = m_Character.GetAction("Action5");
            m_Character_Action6 = m_Character.GetAction("Action6");
            m_Character_Action7 = m_Character.GetAction("Action7");
            m_Character_Action8 = m_Character.GetAction("Action8");
            m_Character_Action9 = m_Character.GetAction("Action9");
            m_Character_Action0 = m_Character.GetAction("Action0");
            m_Character_HotBarCycle = m_Character.GetAction("HotBar.Cycle");
            // Level
            m_Level = asset.GetActionMap("Level");
            m_Level_CycleCharacter = m_Level.GetAction("CycleCharacter");
            m_Initialized = true;
        }
        private void Uninitialize()
        {
            if (m_CharacterActionsCallbackInterface != null)
            {
                Character.SetCallbacks(null);
            }
            m_Character = null;
            m_Character_AxesLeft = null;
            m_Character_AxesRight = null;
            m_Character_InventorySwap = null;
            m_Character_InventoryToggle = null;
            m_Character_InventoryMovement = null;
            m_Character_Jump = null;
            m_Character_Action1 = null;
            m_Character_Action2 = null;
            m_Character_Action3 = null;
            m_Character_Action4 = null;
            m_Character_Action5 = null;
            m_Character_Action6 = null;
            m_Character_Action7 = null;
            m_Character_Action8 = null;
            m_Character_Action9 = null;
            m_Character_Action0 = null;
            m_Character_HotBarCycle = null;
            if (m_LevelActionsCallbackInterface != null)
            {
                Level.SetCallbacks(null);
            }
            m_Level = null;
            m_Level_CycleCharacter = null;
            m_Initialized = false;
        }
        public void SetAsset(InputActionAsset newAsset)
        {
            if (newAsset == asset) return;
            var CharacterCallbacks = m_CharacterActionsCallbackInterface;
            var LevelCallbacks = m_LevelActionsCallbackInterface;
            if (m_Initialized) Uninitialize();
            asset = newAsset;
            Character.SetCallbacks(CharacterCallbacks);
            Level.SetCallbacks(LevelCallbacks);
        }
        public override void MakePrivateCopyOfActions()
        {
            SetAsset(ScriptableObject.Instantiate(asset));
        }
        // Character
        private InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private InputAction m_Character_AxesLeft;
        private InputAction m_Character_AxesRight;
        private InputAction m_Character_InventorySwap;
        private InputAction m_Character_InventoryToggle;
        private InputAction m_Character_InventoryMovement;
        private InputAction m_Character_Jump;
        private InputAction m_Character_Action1;
        private InputAction m_Character_Action2;
        private InputAction m_Character_Action3;
        private InputAction m_Character_Action4;
        private InputAction m_Character_Action5;
        private InputAction m_Character_Action6;
        private InputAction m_Character_Action7;
        private InputAction m_Character_Action8;
        private InputAction m_Character_Action9;
        private InputAction m_Character_Action0;
        private InputAction m_Character_HotBarCycle;
        public struct CharacterActions
        {
            private Schema m_Wrapper;
            public CharacterActions(Schema wrapper) { m_Wrapper = wrapper; }
            public InputAction @AxesLeft { get { return m_Wrapper.m_Character_AxesLeft; } }
            public InputAction @AxesRight { get { return m_Wrapper.m_Character_AxesRight; } }
            public InputAction @InventorySwap { get { return m_Wrapper.m_Character_InventorySwap; } }
            public InputAction @InventoryToggle { get { return m_Wrapper.m_Character_InventoryToggle; } }
            public InputAction @InventoryMovement { get { return m_Wrapper.m_Character_InventoryMovement; } }
            public InputAction @Jump { get { return m_Wrapper.m_Character_Jump; } }
            public InputAction @Action1 { get { return m_Wrapper.m_Character_Action1; } }
            public InputAction @Action2 { get { return m_Wrapper.m_Character_Action2; } }
            public InputAction @Action3 { get { return m_Wrapper.m_Character_Action3; } }
            public InputAction @Action4 { get { return m_Wrapper.m_Character_Action4; } }
            public InputAction @Action5 { get { return m_Wrapper.m_Character_Action5; } }
            public InputAction @Action6 { get { return m_Wrapper.m_Character_Action6; } }
            public InputAction @Action7 { get { return m_Wrapper.m_Character_Action7; } }
            public InputAction @Action8 { get { return m_Wrapper.m_Character_Action8; } }
            public InputAction @Action9 { get { return m_Wrapper.m_Character_Action9; } }
            public InputAction @Action0 { get { return m_Wrapper.m_Character_Action0; } }
            public InputAction @HotBarCycle { get { return m_Wrapper.m_Character_HotBarCycle; } }
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled { get { return Get().enabled; } }
            public InputActionMap Clone() { return Get().Clone(); }
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    AxesLeft.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAxesLeft;
                    AxesLeft.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAxesLeft;
                    AxesLeft.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAxesLeft;
                    AxesRight.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAxesRight;
                    AxesRight.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAxesRight;
                    AxesRight.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAxesRight;
                    InventorySwap.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventorySwap;
                    InventorySwap.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventorySwap;
                    InventorySwap.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventorySwap;
                    InventoryToggle.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventoryToggle;
                    InventoryToggle.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventoryToggle;
                    InventoryToggle.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventoryToggle;
                    InventoryMovement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventoryMovement;
                    InventoryMovement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventoryMovement;
                    InventoryMovement.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInventoryMovement;
                    Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    Jump.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    Action1.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction1;
                    Action1.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction1;
                    Action1.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction1;
                    Action2.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction2;
                    Action2.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction2;
                    Action2.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction2;
                    Action3.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction3;
                    Action3.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction3;
                    Action3.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction3;
                    Action4.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction4;
                    Action4.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction4;
                    Action4.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction4;
                    Action5.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction5;
                    Action5.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction5;
                    Action5.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction5;
                    Action6.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction6;
                    Action6.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction6;
                    Action6.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction6;
                    Action7.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction7;
                    Action7.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction7;
                    Action7.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction7;
                    Action8.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction8;
                    Action8.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction8;
                    Action8.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction8;
                    Action9.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction9;
                    Action9.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction9;
                    Action9.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction9;
                    Action0.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction0;
                    Action0.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction0;
                    Action0.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAction0;
                    HotBarCycle.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHotBarCycle;
                    HotBarCycle.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHotBarCycle;
                    HotBarCycle.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHotBarCycle;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    AxesLeft.started += instance.OnAxesLeft;
                    AxesLeft.performed += instance.OnAxesLeft;
                    AxesLeft.cancelled += instance.OnAxesLeft;
                    AxesRight.started += instance.OnAxesRight;
                    AxesRight.performed += instance.OnAxesRight;
                    AxesRight.cancelled += instance.OnAxesRight;
                    InventorySwap.started += instance.OnInventorySwap;
                    InventorySwap.performed += instance.OnInventorySwap;
                    InventorySwap.cancelled += instance.OnInventorySwap;
                    InventoryToggle.started += instance.OnInventoryToggle;
                    InventoryToggle.performed += instance.OnInventoryToggle;
                    InventoryToggle.cancelled += instance.OnInventoryToggle;
                    InventoryMovement.started += instance.OnInventoryMovement;
                    InventoryMovement.performed += instance.OnInventoryMovement;
                    InventoryMovement.cancelled += instance.OnInventoryMovement;
                    Jump.started += instance.OnJump;
                    Jump.performed += instance.OnJump;
                    Jump.cancelled += instance.OnJump;
                    Action1.started += instance.OnAction1;
                    Action1.performed += instance.OnAction1;
                    Action1.cancelled += instance.OnAction1;
                    Action2.started += instance.OnAction2;
                    Action2.performed += instance.OnAction2;
                    Action2.cancelled += instance.OnAction2;
                    Action3.started += instance.OnAction3;
                    Action3.performed += instance.OnAction3;
                    Action3.cancelled += instance.OnAction3;
                    Action4.started += instance.OnAction4;
                    Action4.performed += instance.OnAction4;
                    Action4.cancelled += instance.OnAction4;
                    Action5.started += instance.OnAction5;
                    Action5.performed += instance.OnAction5;
                    Action5.cancelled += instance.OnAction5;
                    Action6.started += instance.OnAction6;
                    Action6.performed += instance.OnAction6;
                    Action6.cancelled += instance.OnAction6;
                    Action7.started += instance.OnAction7;
                    Action7.performed += instance.OnAction7;
                    Action7.cancelled += instance.OnAction7;
                    Action8.started += instance.OnAction8;
                    Action8.performed += instance.OnAction8;
                    Action8.cancelled += instance.OnAction8;
                    Action9.started += instance.OnAction9;
                    Action9.performed += instance.OnAction9;
                    Action9.cancelled += instance.OnAction9;
                    Action0.started += instance.OnAction0;
                    Action0.performed += instance.OnAction0;
                    Action0.cancelled += instance.OnAction0;
                    HotBarCycle.started += instance.OnHotBarCycle;
                    HotBarCycle.performed += instance.OnHotBarCycle;
                    HotBarCycle.cancelled += instance.OnHotBarCycle;
                }
            }
        }
        public CharacterActions @Character
        {
            get
            {
                if (!m_Initialized) Initialize();
                return new CharacterActions(this);
            }
        }
        // Level
        private InputActionMap m_Level;
        private ILevelActions m_LevelActionsCallbackInterface;
        private InputAction m_Level_CycleCharacter;
        public struct LevelActions
        {
            private Schema m_Wrapper;
            public LevelActions(Schema wrapper) { m_Wrapper = wrapper; }
            public InputAction @CycleCharacter { get { return m_Wrapper.m_Level_CycleCharacter; } }
            public InputActionMap Get() { return m_Wrapper.m_Level; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled { get { return Get().enabled; } }
            public InputActionMap Clone() { return Get().Clone(); }
            public static implicit operator InputActionMap(LevelActions set) { return set.Get(); }
            public void SetCallbacks(ILevelActions instance)
            {
                if (m_Wrapper.m_LevelActionsCallbackInterface != null)
                {
                    CycleCharacter.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnCycleCharacter;
                    CycleCharacter.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnCycleCharacter;
                    CycleCharacter.cancelled -= m_Wrapper.m_LevelActionsCallbackInterface.OnCycleCharacter;
                }
                m_Wrapper.m_LevelActionsCallbackInterface = instance;
                if (instance != null)
                {
                    CycleCharacter.started += instance.OnCycleCharacter;
                    CycleCharacter.performed += instance.OnCycleCharacter;
                    CycleCharacter.cancelled += instance.OnCycleCharacter;
                }
            }
        }
        public LevelActions @Level
        {
            get
            {
                if (!m_Initialized) Initialize();
                return new LevelActions(this);
            }
        }
    }
    public interface ICharacterActions
    {
        void OnAxesLeft(InputAction.CallbackContext context);
        void OnAxesRight(InputAction.CallbackContext context);
        void OnInventorySwap(InputAction.CallbackContext context);
        void OnInventoryToggle(InputAction.CallbackContext context);
        void OnInventoryMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
        void OnAction2(InputAction.CallbackContext context);
        void OnAction3(InputAction.CallbackContext context);
        void OnAction4(InputAction.CallbackContext context);
        void OnAction5(InputAction.CallbackContext context);
        void OnAction6(InputAction.CallbackContext context);
        void OnAction7(InputAction.CallbackContext context);
        void OnAction8(InputAction.CallbackContext context);
        void OnAction9(InputAction.CallbackContext context);
        void OnAction0(InputAction.CallbackContext context);
        void OnHotBarCycle(InputAction.CallbackContext context);
    }
    public interface ILevelActions
    {
        void OnCycleCharacter(InputAction.CallbackContext context);
    }
}
