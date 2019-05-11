using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;
using Cirrus.FSM;

namespace Cirrus.ARPG.Objects.Characters.FSM
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/FSM/Jump")]
    public class Jump : Resource
    {
        override public int Id { get { return (int)FSM.Id.Jump; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        new public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }
            
            public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
            {
                base.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
                Character.FSM.SetState((int)FSM.Id.Grounded);
            }


            public override void Enter(params object[] args)
            {
                Character.CharacterController.velocity.y += KinematicController.Config.JumpSpeed;
                Character.CharacterController.Motor.ForceUnground();
                Character.FSM.SetState((int)FSM.Id.Airborne);
            }

            public override void Jump()
            {
                // Do nothing : do not respond to jump event
            }




        }
    }

}