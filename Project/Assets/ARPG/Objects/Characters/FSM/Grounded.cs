using Cirrus.ARPG.Objects.Actions;
using UnityEngine;

namespace Cirrus.ARPG.Objects.Characters.FSM
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/FSM/Grounded")]
    public class Grounded : Resource
    {
        override public int Id { get { return (int)FSM.Id.Grounded; } }


        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        new public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }

            public override void Enter(params object[] args)
            {
                if (Character.Animator != null)
                {
                    Character.Animator.Play("Idle");
                }
                Character.CharacterController.velocity.y = 0;
            }

            public override void Reenter(params object[] args)
            {
                Character.CharacterController.velocity.y = 0;
            }


            public override void BeforeCharacterUpdate(float deltaTime)
            {
                base.BeforeCharacterUpdate(deltaTime);
            }
            

            public override void PostGroundingUpdate(float deltaTime)
            {
                base.PostGroundingUpdate(deltaTime);

                if (!Character.CharacterController.Motor.GroundingStatus.IsStableOnGround)
                {
                    Character.FSM.SetState((int)FSM.Id.Airborne);
                    return;
                }
            }
 
            public override void Jump()
            {
                if (!IsMovementInputEnabled)
                    return;

                Character.FSM.SetState((int)FSM.Id.Jump);
            }

            public override void Injure()
            {
                Character.FSM.SetState(FSM.Id.InjuredGrounded);
            }


            //

            public override bool UseAction(Actions.Ability action)
            {
                if (!IsMovementInputEnabled)
                    return false;

                base.UseAction(action);
                Character.DoUseAction(action);
                return true;
            }

            public override void UseAction(Actions.Ability action, BaseObject tg)
            {
                if (!IsMovementInputEnabled)
                    return;

                base.UseAction(action, tg);
                Character.DoUseAction(action, tg);
            }

        }


    }

}