using UnityEngine;
using System.Collections;
//using Cirrus.ARPG.World.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.World.Cameras
{
    [System.Serializable]
    public enum State
    {
        Idle,
        Follow,
        Focus
    }


    public class CameraWrapper : MonoBehaviour
    {
        [SerializeField]
        private State _state;

        [SerializeField]
        private Room _room;

        [SerializeField]
        public Camera Camera;

        private Objects.BaseObject _target;            // The position that that camera will be following.

        public List<Objects.BaseObject> _targets;            // The position that that camera will be following.

        public float _smoothing = 5f;        // The speed with which the camera will be following.

        [SerializeField]
        private Vector3 _offset;                     // The initial offset from the target

        [SerializeField]
        private float _rotationSpeed = 5;

        public void OnValidate()
        {
            if (Camera == null)
                Camera = GetComponent<Camera>();

            if (Camera == null)
                Camera = GetComponentInChildren<Camera>();

            if (_room == null)
                _room = FindObjectOfType<Room>();
        }


        private void Awake()
        {
            Room.OnCharacterStartStaticHandler += OnCharacterStart;
            TryChangeState(State.Idle);
        }

        public void OnCharacterStart(Objects.Characters.Character character)
        {
            TryChangeState(State.Follow, character);
        }

        public void TryChangeState(State state, params object[] args)
        {
            switch (state)
            {
                case State.Focus:
                    _targets = args[0] as List<Objects.BaseObject>;
                    _state = state;
                    break;

                case State.Follow:
                    _target = args[0] as Objects.BaseObject;
                    _state = state;
                    break;

                case State.Idle:                    
                    _state = state;
                    break;
            }
        }

        void LateUpdate()
        {
            Vector3 targetCamPos;
            Quaternion targetRotation;
            switch (_state)
            {

                case State.Follow:

                    if (_target == null)
                        return;

                    // Create a postion the camera is aiming for based on the offset from the target.
                    targetCamPos = _target.Transform.position + _offset;

                    //// Smoothly interpolate between the camera's current position and it's target position.
                    transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime);

                    targetRotation = Quaternion.LookRotation(_target.Transform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

                    break;

                case State.Focus:
                    //TODO: Weigh the player more or less not equal
                    Vector3 total = _targets.Aggregate(Vector3.zero, (sum, next) => sum + next.Transform.position);
                    Vector3 avg = total / _targets.Count;

                    if (_target == null)
                        return;

                    // Create a postion the camera is aiming for based on the offset from the target.
                    targetCamPos = avg + _offset;

                    //// Smoothly interpolate between the camera's current position and it's target position.
                    transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime);

                    targetRotation = Quaternion.LookRotation(avg - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

                    break;

            }

        }
    }
}

