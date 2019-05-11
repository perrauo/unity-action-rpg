using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

// Select focus target (z-targeting)


namespace Cirrus.ARPG.Objects.Characters.FSM
{
    public class InjuredAirborne : Airborne
    {
        override public int Id { get { return (int)FSM.Id.InjuredAirborne; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        public class State : Airborne.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }

            public override void Injure()
            {
                // NOTHING Character.FSM.SetState(FSM.Id.InjuredGrounded);
            }

            public override void Enter(params object[] args)
            {
                base.Enter(args);

                Character.CharacterController.velocity.x = 0;
                Character.CharacterController.velocity.z = 0;

                if (Character.Animator != null)
                {
                    Character.Animator.Play("Injured");
                }
  
            }

            protected override bool IsMovementInputEnabled { get { return false; } }

        }
    }

}