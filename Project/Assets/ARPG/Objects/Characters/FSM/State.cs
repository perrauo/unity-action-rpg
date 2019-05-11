using UnityEngine;
using UnityEditor;
using KinematicCharacterController;
using System;



// Character state

namespace Cirrus.ARPG.Objects.Characters.FSM
{
    [System.Serializable]
    public enum Id
    {
        Action = 1 << 1,
        Grounded = 1 << 2,
        Airborne = 1 << 3,
        Jump = 1 << 4,
        Dead = 1 << 5,
        InjuredGrounded = 1 << 6,
        InjuredAirborne = 1 << 7,
    }

    // We don't care if we can't instantiate this SO, because it's abstract
    public abstract class Resource : Cirrus.FSM.Resource
    {
        override public int Id { get { return -1; } }
    }

    public abstract class State : Cirrus.FSM.State, KinematicControls.ICharacterController
    {
        public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }
        protected Character Character { get { return (Character)context[0]; } }
        protected KinematicControls.CustomCharacterController KinematicController { get { return (KinematicControls.CustomCharacterController)context[1]; } }

        public override void Enter(params object[] args) { }
        public override void Exit() { }
        public override void BeginTick() { }
        public override void EndTick() { }

        public virtual void Jump() { }

        public virtual void Injure() { }
        public virtual void Heals() { }

        protected virtual bool IsMovementInputEnabled { get { return true; } }

        private Vector3 _targetDirection = Vector3.zero;
        private Vector3 _direction = Vector3.zero;


        public virtual bool UseAction(Characters.Actions.Ability action)
        {
            if (!IsMovementInputEnabled)
                return false;
            
            return true;
        }

    
        public virtual void UseAction(Actions.Ability action, BaseObject tg)
        {
            if (!IsMovementInputEnabled)
                return;
        }

        public virtual bool IsColliderValidForCollisions(Collider coll) { return true; }

        public virtual void OnGroundHit(
            Collider hitCollider, 
            Vector3 hitNormal, 
            Vector3 hitPoint, 
            ref HitStabilityReport hitStabilityReport) { }

        public virtual void OnMovementHit(
            Collider hitCollider, 
            Vector3 hitNormal, 
            Vector3 hitPoint, 
            ref HitStabilityReport hitStabilityReport) { }

        public virtual void PostGroundingUpdate(float deltaTime) { }

        public virtual void ProcessHitStabilityReport(
            Collider hitCollider, 
            Vector3 hitNormal, 
            Vector3 hitPoint,
            Vector3 atCharacterPosition, 
            Quaternion atCharacterRotation, 
            ref HitStabilityReport hitStabilityReport){ }


        public virtual void BeforeCharacterUpdate(float deltaTime)
        {
            if (!IsMovementInputEnabled)
                return;

            Vector2 v =
                Character.Axes.Left *
                Character.CharacterController.Config.Speed;

            Character.CharacterController.velocity.x = v.x;
            Character.CharacterController.velocity.z = v.y;
        }

        public virtual void AfterCharacterUpdate(float deltaTime) { }


        public virtual void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            if (!IsMovementInputEnabled)
                return;

            if (!Cirrus.Utils.Mathf.CloseEnough(Character.Axes.Right.magnitude, 0))
            {
                // Smoothly interpolate from current to target look direction
                var v = Character.Axes.Right;

                _targetDirection = new Vector3(v.x, 0.0f, v.y);

                _direction = Vector3.Lerp(_direction, _targetDirection, KinematicController.Config.RotationSpeed);

                if (Cirrus.Utils.Vectors.CloseEnough(_direction, Vector3.zero))
                    return;

                currentRotation = Quaternion.LookRotation(_direction);
            }
            else
            {
                // Smoothly interpolate from current to target look direction  
                _targetDirection = new Vector3(Character.Axes.Left.x, 0.0f, Character.Axes.Left.y);
                _direction = Vector3.Lerp(_direction, _targetDirection, KinematicController.Config.RotationSpeed);

                if (Cirrus.Utils.Vectors.CloseEnough(_direction, Vector3.zero))
                    return;

                currentRotation = Quaternion.LookRotation(_direction);

            }


        }

        public virtual void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
              currentVelocity = Character.CharacterController.velocity;
        }

    }


}
