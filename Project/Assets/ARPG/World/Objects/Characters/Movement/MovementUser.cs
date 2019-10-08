using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;
//using Core.Objects.Actions.Characters;


namespace Cirrus.ARPG.World.Objects.Characters.Movements
{
    public class MovementUser : MonoBehaviour, ICharacterController
    {

        /// <summary>
        // The KinematicCharacterMotor that will be assigned to this CharacterController via the inspector
        /// </summary>
        ///
        [SerializeField]
        public KinematicCharacterMotor Motor;

        [SerializeField]
        public Resource Resource;

        [SerializeField]
        private Character _character;

        //[Header("Stable Movement")]
        //public float MaxStableMoveSpeed = 10f;
        //public float StableMovementSharpness = 15;
        ////public OrientationMethod OrientationMethod = OrientationMethod.TowardsCamera;


        //[Header("Jumping")]
        //public bool AllowJumpingWhenSliding = false;
        //public float JumpSpeed = 10f;
        //public float JumpPreGroundingGraceTime = 0f;
        //public float JumpPostGroundingGraceTime = 0f;

        //[Header("Misc")]
        public List<Collider> IgnoredColliders = new List<Collider>();
        //public Transform CameraFollowPoint;

        //public Vector3 lookInputVector = Vector3.forward;
        //public float RotationSpeed = 10f;
        //public float RotationSharpness = 30f;
        //public Vector3 PlanarDirection { get; private set; }

        public float orientationSharpness = 10;
        public Vector3 direction = Vector3.zero;
        public Vector3 move = Vector3.zero;


        public void AfterCharacterUpdate(float deltaTime)
        {  
            _character.AfterCharacterUpdate(deltaTime);
        }

        public void BeforeCharacterUpdate(float deltaTime)
        {
            _character.BeforeCharacterUpdate(deltaTime);
        }

        public bool IsColliderValidForCollisions(Collider coll)
        {
            if (IgnoredColliders.Contains(coll))
            {
                return false;
            }
            return true;
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            _character.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);               
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            _character.OnMovementHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
        }

        public void PostGroundingUpdate(float deltaTime)
        {
            _character.PostGroundingUpdate(deltaTime);
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
            _character.ProcessHitStabilityReport(hitCollider, hitNormal, hitPoint, atCharacterPosition, atCharacterRotation, ref hitStabilityReport);
        }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            _character.UpdateRotation(ref currentRotation, deltaTime);
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            _character.UpdateVelocity(ref currentVelocity, deltaTime);
        }


        public void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("OnCollisionEnter");
        }


        //public void On

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
            if (hitCollider.gameObject.layer == Game.Instance.Layers.Objects)
            {
                _character.OnObjectCollision(hitCollider.GetComponentInParent<BaseObject>());
            }
        }


        //public void OnCollisionEnter(Collision other)
        //{
        //    Debug.Log("asasd");

        //    // how much the character should be knocked back
        //    var magnitude = 5000;
        //    // calculate force vector
        //    var force = transform.position - other.transform.position;
        //    // normalize force vector to get direction only and trim magnitude
        //    force.Normalize();
        //    gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        //}



        // DEPRECATED
        /// <summary>
        /// Allows you to override the way velocity is projected on an obstruction
        /// </summary>
        public void HandleMovementProjection(ref Vector3 movement, Vector3 obstructionNormal, bool stableOnHit)
        {
            if (Motor.GroundingStatus.IsStableOnGround && !Motor.MustUnground())
            {
                // On stable slopes, simply reorient the movement without any loss
                if (stableOnHit)
                {
                    movement = Motor.GetDirectionTangentToSurface(movement, obstructionNormal) * movement.magnitude;
                }
                // On blocking hits, project the movement on the obstruction while following the grounding plane
                else
                {
                    Vector3 obstructionRightAlongGround = Vector3.Cross(obstructionNormal, Motor.GroundingStatus.GroundNormal).normalized;
                    Vector3 obstructionUpAlongGround = Vector3.Cross(obstructionRightAlongGround, obstructionNormal).normalized;
                    movement = Motor.GetDirectionTangentToSurface(movement, obstructionUpAlongGround) * movement.magnitude;
                    movement = Vector3.ProjectOnPlane(movement, obstructionNormal);
                }
            }
            else
            {
                if (stableOnHit)
                {
                    // Handle stable landing
                    movement = Vector3.ProjectOnPlane(movement, Motor.CharacterUp);
                    movement = Motor.GetDirectionTangentToSurface(movement, obstructionNormal) * movement.magnitude;
                }
                // Handle generic obstruction
                else
                {
                    movement = Vector3.ProjectOnPlane(movement, obstructionNormal);
                }
            }
        }



        public void OnValidate()
        {
            if (Motor == null)
            {
                Motor = GetComponent<KinematicCharacterMotor>();
            }
        }

        public void Awake()
        {
            Motor.CharacterController = this;
        }

        //public override 


    }

}