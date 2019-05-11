using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Playables;

namespace KinematicCharacterController.Examples
{
    public class PlayableMover : BaseMoverController
    {
        public float Speed = 1f;
        public PlayableDirector Director;

        private Transform _transform;

        private void Start()
        {
            _transform = this.transform;
            Director.timeUpdateMode = DirectorUpdateMode.Manual;
        }

        // This is called every FixedUpdate by our PhysicsMover in order to tell it what pose it should go to
        public override void UpdateMovement(out Vector3 GoalPosition, out Quaternion GoalRotation, float deltaTime)
        {
            // Remember pose before animation
            Vector3 _positionBeforeAnim = _transform.position;
            Quaternion _rotationBeforeAnim = _transform.rotation;

            // Update animation
            EvaluateAtTime(Time.time * Speed);

            // Set our platform's Goal pose to the animation's
            GoalPosition = _transform.position;
            GoalRotation = _transform.rotation;

            // Reset the actual transform pose to where it was before evaluating. 
            // This is so that the real movement can be handled by the physics mover; not the animation
            _transform.position = _positionBeforeAnim;
            _transform.rotation = _rotationBeforeAnim;
        }

        public void EvaluateAtTime(double time)
        {
            Director.time = time % Director.duration;
            Director.Evaluate();
        }
    }
}