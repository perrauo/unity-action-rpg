
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;
using Cirrus.ARPG.Objects.Characters.Actions;
//using Cirrus.ARPG.Controls;
using UnityInput = UnityEngine.Experimental.Input;
using Cirrus.ARPG.Playable;


// Controls Navmesh Navigation


namespace Cirrus.ARPG.Objects.Characters.Playable.Controls
{
    public class Controller : Characters.Controls.Controller, DH.Playable.Controls.ICharacterActions
    {
        [SerializeField]
        private DH.Playable.Controls.Player _player;

        [SerializeField]
        private Items.Inventory _inventory;

        [SerializeField]
        private Items.HotBar _hotBar;

        public void SetEnabled(bool isEnabled = true)
        {
            if (isEnabled)
            {
                _player.TryRegisterController(this);
                _player.SetInputsEnabled(this);
            }
            else
            {
                _player.TryUnregisterController(this);
                _player.SetInputsEnabled(this, false);
            }
        }

        public void OnJump(UnityInput.InputAction.CallbackContext context)
        {
            if (!_inventory.IsEnabled)
            {
                _character.Jump();
            }
        }

        // TODO: Simulate LeftStick continuous axis with WASD
        public void OnAxesLeft(UnityInput.InputAction.CallbackContext context)
        {
            if (!_inventory.IsEnabled)
            {
                _character.Axes.Left = Vector2.ClampMagnitude(context.ReadValue<Vector2>(), 1);
            }
        }

        public void OnAxesRight(UnityInput.InputAction.CallbackContext context)
        {
            if (!_inventory.IsEnabled)
            {
                _character.Axes.Right = Vector2.ClampMagnitude(context.ReadValue<Vector2>(), 1);
            }
        }

        public void OnHotBarCycle(UnityInput.InputAction.CallbackContext context)
        {
            int i = Mathf.CeilToInt(context.ReadValue<float>());
            _hotBar.Cycle(i);
        }

        public void OnInventoryMovement(UnityInput.InputAction.CallbackContext context)
        {
            Vector2Int movement = Vector2Int.FloorToInt(context.ReadValue<Vector2>());

            if (_inventory.IsEnabled)
            {
                _inventory.Move(movement);
            }
        }

        public void OnInventorySwap(UnityInput.InputAction.CallbackContext context)
        {
            if (_inventory.IsEnabled)
            {
                _inventory.Swap();
            }
        }

        public void OnInventoryToggle(UnityInput.InputAction.CallbackContext context)
        { 
            if (_inventory.IsEnabled)
            {
                _inventory.Close();
            }
            else
            {
                _inventory.Open(_character);
            }
        }

        #region Actions CallBacks
        public void OnAction1(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(1);
        }

        public void OnAction2(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(2);
        }

        public void OnAction3(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(3);
        }

        public void OnAction4(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(4);
        }

        public void OnAction5(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(5);
        }

        public void OnAction6(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(6);
        }

        public void OnAction7(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(7);
        }

        public void OnAction8(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(8);
        }

        public void OnAction9(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(9);
        }

        public void OnAction0(UnityInput.InputAction.CallbackContext context)
        {
            OnAction(10);
        }

        #endregion

        public void OnAction(int idx)
        {
            if (_inventory.IsEnabled)
            {
                _inventory.Map(idx);
                //Debug.Log("Map action " + idx);
            }
            else
            {       
                Ability ability = _hotBar.GetItem(idx);
                if (ability != null)
                {
                    _character.UseAction(ability);
                }
            }
        }

        //TODO: remove
        public void OnValidate()
        {
            if(_player == null)
                _player = FindObjectOfType<DH.Playable.Controls.Player>();

            if (_inventory == null)
                _inventory = FindObjectOfType<Items.Inventory>();

            if (_hotBar == null)
                _hotBar = FindObjectOfType<Items.HotBar>();
        }

    }
}