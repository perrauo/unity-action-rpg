
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;
using Cirrus.ARPG.World.Objects.Characters.Actions;
//using Cirrus.ARPG.Controls;
using UnityInput = UnityEngine.InputSystem;
//using Cirrus.ARPG.Playable;


// Controls Navmesh Navigation

// TODO control inv and Hotbar through the inventory user the the inv directly

namespace Cirrus.ARPG.Controls
{
    public class Player : MonoBehaviour, ActionMap.IPlayerActions
    {
        [SerializeField]
        public ActionMap _actionMap;

        // TODO: Rework ? replace by mult action map

        public ActionMap.PlayerActions Actions { get { return _actionMap.Player; } }


        // TODO remove reference to player
        // TODO make it a reference to the controller
        [SerializeField]
        private World.Objects.Characters.Character _character;

        //[SerializeField]
        //private UI.HUD _hud;

        public void Awake()
        {
            _actionMap = new ActionMap();
            World.Room.OnCharacterStartStaticHandler += OnCharacterStart;

            //UI.HUD.OnHUDStartStaticHandler += OnHUDStart;
        }

        //public void OnHUDStart(UI.HUD hud)
        //{
        //    _hud = hud;
        //}

        public void OnCharacterStart(World.Objects.Characters.Character character)
        {
            _character = character;
        }

        public void OnCharacterChange(World.Objects.Characters.Character character)
        {
            _character = character;
        }

        public void Enable(bool enabled = true)
        {
            if (enabled)
            {
                Actions.Enable();
                Actions.SetCallbacks(this);
            }
            else
            {
                Actions.Disable(); ;
                Actions.SetCallbacks(null);
            }
        }

        public void OnJump(UnityInput.InputAction.CallbackContext context)
        {           
            _character.Controller.Jump();   
        }

        public void OnAxesLeft(UnityInput.InputAction.CallbackContext context)
        {
            //if (!UI.HUD.Instance.Inventory.IsEnabled)
            {
                _character.Controller.AxesLeft = Vector2.ClampMagnitude(context.ReadValue<Vector2>(), 1);
            }
        }

        public void OnAxesRight(UnityInput.InputAction.CallbackContext context)
        {
            //if (!UI.HUD.Instance.Inventory.IsEnabled)
            {
                var value = context.ReadValue<Vector2>();
                _character.Controller.AxesRight = value;
            }
        }

        public void OnCursorMove(UnityInput.InputAction.CallbackContext context)
        {
            //Vector3 value = context.ReadValue<Vector2>();

            //if (!UI.HUD.Instance.Inventory.IsEnabled)
            //{
            //    RaycastHit hit;
            //    var ray = World.Room.Instance.Camera.Camera.ScreenPointToRay(Input.mousePosition);

            //    //Debug.Log(pos);

            //    if (Physics.Raycast(ray, out hit))
            //    {
            //        var pos = hit.point;
            //        pos.y = _character.Transform.position.y; 


            //        var dir = (pos - _character.Transform.position).normalized;

            //        _character.Controller.AxesRight = dir;

            //        // Do something with the object that was hit by the raycast.
            //    }
            //}
        }

        public void OnCursorClick(UnityInput.InputAction.CallbackContext context)
        {
            //var value = context.ReadValue<Vector2>();

        }

        public void OnCursorHold(UnityInput.InputAction.CallbackContext context)
        {
            //var value = context.ReadValue<Vector2>();
        }


        public void OnHotBarCycleLeft(UnityInput.InputAction.CallbackContext context)
        {
            //UI.HUD.Instance.HotBar.Cycle(-1);
        }

        public void OnHotBarCycleRight(UnityInput.InputAction.CallbackContext context)
        {
            //UI.HUD.Instance.HotBar.Cycle(1);
        }

        public void OnHotBarActionCurrent(UnityInput.InputAction.CallbackContext context)
        {
            //if (UI.HUD.Instance.HotBar.CurrentAbility != null)
            //{
            //    _character.TryUseAbility(UI.HUD.Instance.HotBar.CurrentAbility);
            //}
        }

        public void OnMenuMove(UnityInput.InputAction.CallbackContext context)
        {
            Vector2Int movement = Vector2Int.FloorToInt(context.ReadValue<Vector2>());

            _character.Controller.MenuMove(movement);

            //if (UI.HUD.Instance.Inventory.IsEnabled)
            //{
            //    UI.HUD.Instance.Inventory.Move(movement);
            //}
        }

        public void OnMenuSwap(UnityInput.InputAction.CallbackContext context)
        {
            //UI.HUD.Instance.O

            //if (UI.HUD.Instance.Inventory.IsEnabled)
            //{
            //    UI.HUD.Instance.Inventory.Swap();
            //}
        }

        public void OnMenuToggle(UnityInput.InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                _character.Controller.ToggleMenu();
            }

            //if (UI.HUD.Instance.Inventory.IsEnabled)
            //{
            //    UI.HUD.Instance.Inventory.Close();
            //}
            //else
            //{
            //    UI.HUD.Instance.Inventory.Open(_character);
            //}
        }

        public Timer _timer;

        [SerializeField]
        private float _focusSwitchLimit = 2;

        public void OnFocus(UnityInput.InputAction.CallbackContext context)
        {
            if (_timer == null)
            {
                _timer = new Timer(_focusSwitchLimit, start: false, repeat: false);
                _timer.OnTimeLimitHandler += OnFocusTimesUp;
            }

            if (context.ReadValue<float>() > 0)
            {
                //var pos = Levels.Room.Instance.Camera.Camera.ScreenToWorldPoint(Input.mousePosition);

                //Input.mousePresent

                _character.FocusCycle(true);
                _timer.Reset();
                _timer.Stop();
            }
            else
            {
                if(!_timer.IsActive)
                _timer.Resume();

                
            }
        }


        public void OnFocusTimesUp()
        {
            _character.FocusCycle(false);
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
            //if (UI.HUD.Instance.Inventory.IsEnabled)
            //{
            //    UI.HUD.Instance.HotBar.Select(idx);
            //    UI.HUD.Instance.Inventory.Map(idx);
            //}
            //else
            //{
            //    Ability ability = UI.HUD.Instance.HotBar.GetItem(idx);
            //    if (ability != null)
            //    {
            //        UI.HUD.Instance.HotBar.Select(idx);
            //        _character.TryUseAbility(ability);
            //    }
            //}
        }

        //TODO: remove
        public void OnValidate()
        {
            ////if(_player == null)
            ////    _player = FindObjectOfType<ARPG.Controls.Player>();

            //if (UI.HUD.Instance.HotBar == null)
            //    UI.HUD.Instance.HotBar = FindObjectOfType<World.Objects.Items.Inventory>();

            //if (_hotBar == null) { }
            //    _hotBar = FindObjectOfType<World.Objects.Items.HotBar>();
        }

    }
}