using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;


namespace Cirrus.ARPG.Objects.Characters.KinematicControls
{
    interface ICharacterController
    {
        void AfterCharacterUpdate(float deltaTime);
        void BeforeCharacterUpdate(float deltaTime);
        bool IsColliderValidForCollisions(Collider coll);
        void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport);
        void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport);
        void PostGroundingUpdate(float deltaTime);
        void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport);
        void UpdateRotation(ref Quaternion currentRotation, float deltaTime);
        void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime);

    }
}
