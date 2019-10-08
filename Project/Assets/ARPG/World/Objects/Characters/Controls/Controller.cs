
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;
using Cirrus.ARPG.World.Objects.Characters.Actions;
using UnityInput = UnityEngine.InputSystem;// .Input;
using Cirrus.FSM;
using System;
//using Cirrus.ARPG.Controls;


// Controls Navmesh Navigation


namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public class Controller : MonoBehaviour
    {
        [SerializeField]
        public Resource Resource;

        [SerializeField]
        private Agent _agent;

        [SerializeField]
        private Character _character;

        [SerializeField]
        public Machine FSM;

        [SerializeField]
        public AIBehaviour DefaultBehaviour;

        public virtual Vector2 AxesLeft
        {
            get
            {
                return State.AxesLeft;
            }

            set {
                State.AxesLeft = value;
            }
        }

        public virtual Vector2 AxesRight
        {
            get
            {
                return State.AxesRight;
            }

            set
            {
                State.AxesRight = value;
            }
        }


        public IControllerState State
        {   get
            {
                return (IControllerState) FSM.Top;
            }
        }

        public void Start()
        {
            _agent.OnEnvironmentChangedHandler += OnEnvironmentChanged;

            State.Adapt();
        }

        public void Update()
        {

        }


        public void Injure()
        {
            FSM.TrySetState(Controls.Id.Injured);
        }


        public void OnEnvironmentChanged(Option option, BaseObject target, params object[] args)
        {
            State.Adapt(option, target, args);
        }


        public void Jump()
        {
            State.Jump();
        }


        public void ToggleMenu()
        {
            State.ToggleMenu();            
        }

        public void MenuMove(Vector2Int movement)
        {
            State.MenuMove(movement);
        }

        public void CycleSubmenu(int direction)
        {
            State.CycleSubmenus(direction);
        }

    }
}