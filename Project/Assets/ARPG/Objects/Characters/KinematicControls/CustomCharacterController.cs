using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;
//using Core.Objects.Actions.Characters;


namespace Cirrus.ARPG.Objects.Characters.KinematicControls
{
    public class CustomCharacterController : BaseCharacterController, ICharacterController
    {
        //private KinematicCharacterController.

        [SerializeField]
        public Configuration Config;

        [SerializeField]
        private Cirrus.ARPG.Objects.Characters.Character _character;

        //[Header("Stable Movement")]
        //public float MaxStableMoveSpeed = 10f;
        //public float StableMovementSharpness = 15;
        ////public OrientationMethod OrientationMethod = OrientationMethod.TowardsCamera;

        //[Header("Air Movement")]
        //public float MaxAirMoveSpeed = 10f;
        //public float AirAccelerationSpeed = 5f;
        public float Drag = 0.1f;

        //[Header("Jumping")]
        //public bool AllowJumpingWhenSliding = false;
        //public float JumpSpeed = 10f;
        //public float JumpPreGroundingGraceTime = 0f;
        //public float JumpPostGroundingGraceTime = 0f;

        //[Header("Misc")]
        public List<Collider> IgnoredColliders = new List<Collider>();

        //public bool OrientTowardsGravity = false;
        public Vector3 Gravity = new Vector3(0, -30f, 0);
        //public Transform MeshRoot;
        //public Transform CameraFollowPoint;

        //public Vector3 lookInputVector = Vector3.forward;
        //public float RotationSpeed = 10f;
        //public float RotationSharpness = 30f;
        //public Vector3 PlanarDirection { get; private set; }

        public float orientationSharpness = 10;
        public Vector3 direction = Vector3.zero;
        public Vector3 move = Vector3.zero;
        public Vector3 velocity = Vector3.zero;


        public override void AfterCharacterUpdate(float deltaTime)
        {  
            _character.AfterCharacterUpdate(deltaTime);
        }

        public override void BeforeCharacterUpdate(float deltaTime)
        {
            _character.BeforeCharacterUpdate(deltaTime);
        }

        public override bool IsColliderValidForCollisions(Collider coll)
        {
            if (IgnoredColliders.Contains(coll))
            {
                return false;
            }
            return true;
        }

        public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            _character.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);               
        }

        public override void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            _character.OnMovementHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
        }

        public override void PostGroundingUpdate(float deltaTime)
        {
            _character.PostGroundingUpdate(deltaTime);
        }

        public override void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
            _character.ProcessHitStabilityReport(hitCollider, hitNormal, hitPoint, atCharacterPosition, atCharacterRotation, ref hitStabilityReport);
        }

        public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            _character.UpdateRotation(ref currentRotation, deltaTime);
        }

        public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            _character.UpdateVelocity(ref currentVelocity, deltaTime);
        }



        //public override 


    }

}