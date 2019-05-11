using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

// Select focus target (z-targeting)


namespace Cirrus.ARPG.Objects.Characters.FSM
{
    public class InjuredGrounded : Grounded
    {
        override public int Id { get { return (int)FSM.Id.InjuredGrounded; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        public class State : Grounded.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }

            public override void Injure()
            {
               // NOTHING Character.FSM.SetState(FSM.Id.InjuredGrounded);
            }

            public override void Enter(params object[] args)
            {
                base.Enter(args);

                Character.CharacterController.velocity = Vector3.zero;

                if (Character.Animator != null)
                {
                    Character.Animator.Play("Injured");
                }
  
            }

            protected override bool IsMovementInputEnabled { get { return false; } }

        }
    }

}