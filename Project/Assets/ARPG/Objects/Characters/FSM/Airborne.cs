using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

namespace Cirrus.ARPG.Objects.Characters.FSM
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/FSM/Airborne")]
    public class Airborne : Resource
    {
        override public int Id { get { return (int)FSM.Id.Airborne; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }
    
        public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }

            public override void BeforeCharacterUpdate(float deltaTime)
            {
                base.BeforeCharacterUpdate(deltaTime);
                Character.CharacterController.velocity.y -= KinematicController.Config.Gravity;
            }

            public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
            {
                base.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
                Character.FSM.SetState((int)FSM.Id.Grounded);
            }

            public override void Jump()
            {
                // Do nothing : do not respond to jump event
            }

            public override void Injure()
            {
                Character.FSM.SetState(FSM.Id.InjuredAirborne);
            }

        }





    }

}