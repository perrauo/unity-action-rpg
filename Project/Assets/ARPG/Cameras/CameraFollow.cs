using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects;

namespace Cirrus.ARPG.Cameras
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following.

        [SerializeField]
        private Vector3 _offset;                     // The initial offset from the target.


        [SerializeField]
        private float _rotationSpeed = 5;

        private void Awake()
        {
            Levels.Room.OnRoomLoadedHandler += OnRoomLoaded;
        }


        void Start ()
        {
            if (target == null)
                return;

            // Calculate the initial offset.
            //offset = transform.position - target.position;
        }


        void FixedUpdate ()
        {
            if (target == null)
                return;

            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.position + _offset;

            //// Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * UnityEngine.Time.deltaTime);

            var p = target.transform.position;
            var targetRotation = Quaternion.LookRotation(p - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * UnityEngine.Time.deltaTime);

        }


        public void RegisterTarget(BaseObject baseObject)
        {
            target = baseObject.transform;
        }


        public void OnRoomLoaded(Levels.Room room)
        {
            //target = Game.Instance.Player.transform;
        }

    }
}

