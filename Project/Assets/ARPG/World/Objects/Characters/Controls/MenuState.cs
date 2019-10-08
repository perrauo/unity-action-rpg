using System;
using System.Collections;
using System.Collections.Generic;
using Cirrus.FSM;
using UnityEngine;


// TODO:  OVERRIDE ALL BASE FUNCTIONS WITHOUT DOING ANYTHING

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public class MenuState : StateResource, IResource
    {
        public override int Id { get { return (int)Controls.Id.Menu; } }

        public override IState PopulateState(object[] context)
        {
            return new State(context, this);
        }

        public class State : Controls.State, IState, IControllerState
        {
            public State(object[] context, MenuState resource) : base(context, resource) { }


            public Character Character { get { return (Character) Context[1]; } }


            //public override void 

            // TODO: replace by tryenter tryexit menu function (they are the trans)
            public override void ToggleMenu()
            {
                if (Controller.FSM.TrySetState(Controls.Id.Human))
                {
                    base.ToggleMenu();

                    //ARPG.UI.HUD.Instance.Menu.Close();

                }
            }

            public override void MenuMove(Vector2Int movement)
            {
                ARPG.UI.HUD.Instance.Menu.Move(movement);
            }

            public override void CycleSubmenus(int movement)
            {
                ARPG.UI.HUD.Instance.Menu.CycleSubmenus(movement);
            }


            public override void Enter(params object[] args)
            {
                Character.TargetAxes.Left /= 2;
                Character.Axes.Left = Vector3.zero;
            }

            public override void Reenter(params object[] args)
            {

            }

            public override void Exit()
            {

            }

            public override void BeginUpdate()
            {

            }

            public override void EndUpdate()
            {

            }

            public override void Adapt(Option option, BaseObject target, params object[] args)
            {

            }

            public override void Adapt()
            {

            }

            public override void Jump()
            {
                Character.Jump();
            }
        }

    }

}