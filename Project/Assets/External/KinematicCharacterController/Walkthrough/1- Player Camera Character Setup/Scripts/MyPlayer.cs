using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

namespace KinematicCharacterController.Walkthrough.PlayerCameraCharacterSetup
{
    public class MyPlayer : MonoBehaviour
    {
        public OrbitCamera OrbitCamera;
        public Transform CameraFollowPoint;
        public MyCharacterController Character;
        public float MouseSensitivity = 0.01f;

        private Vector3 _lookInputVector = Vector3.zero;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Tell camera to follow transform
            OrbitCamera.SetFollowTransform(CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
            OrbitCamera.IgnoredColliders = Character.GetComponentsInChildren<Collider>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            HandleCameraInput();
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            float mouseLookAxisUp = UnityEngine.Input.GetAxisRaw("Mouse Y");
            float mouseLookAxisRight = UnityEngine.Input.GetAxisRaw("Mouse X");
            _lookInputVector = new Vector3(mouseLookAxisRight * MouseSensitivity, mouseLookAxisUp * MouseSensitivity, 0f);

            // Prevent moving the camera while the cursor isn't locked
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                _lookInputVector = Vector3.zero;
            }

            // Input for zooming the camera (disabled in WebGL because it can cause problems)
            float scrollInput = -UnityEngine.Input.GetAxis("Mouse ScrollWheel");
    #if UNITY_WEBGL
            scrollInput = 0f;
    #endif

            // Apply inputs to the camera
            OrbitCamera.UpdateWithInput(Time.deltaTime, scrollInput, _lookInputVector);

            // Handle toggling zoom level
            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                OrbitCamera.TargetDistance = (OrbitCamera.TargetDistance == 0f) ? OrbitCamera.DefaultDistance : 0f;
            }
        }
    }
}