using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.World.Objects.UI
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 5f;

        
        // Update is called once per frame
        void FixedUpdate()
        {
            transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
        }
    }
}