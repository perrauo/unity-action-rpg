using System;
using System.Collections;
using System.Collections.Generic;
using Cirrus.FSM;
using UnityEngine;


// TODO:  OVERRIDE ALL BASE FUNCTIONS WITHOUT DOING ANYTHING

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public class HumanState : StateResource, IResource
    {
        public override int Id { get { return (int)Controls.Id.Human; } }

        public override IState PopulateState(object[] context)
        {
            return new State(context, this);
        }

        public class State : Controls.State, IState, IControllerState
        {
            public State(object[] context, HumanState resource) : base(context, resource) { }


            public Character Character { get { return (Character) Context[1]; } }


            public override void ToggleMenu()
            {
                if (Controller.FSM.TrySetState(Controls.Id.Menu))
                {
                    base.ToggleMenu();

                    ARPG.UI.HUD.Instance.Menu.Open();
                }
            }

            public override Vector2 AxesLeft
            {
                get
                {
                    return Character.Axes.Left;
                }

                set
                {
                    Character.Axes.Left = value;
                }

            }

            public override Vector2 AxesRight
            {
                get
                {
                    return Character.Axes.Right;
                }

                set
                {
                    Character.Axes.Right = value;
                }

            }


            public override void Enter(params object[] args)
            {

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
                //throw new NotImplementedException();
            }

            public override void Adapt()
            {
                //throw new NotImplementedException();
            }

            public override void Jump()
            {
                Character.Jump();
            }
        }

    }

}