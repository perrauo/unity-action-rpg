using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects
{

    public class ObjectPhysic : MonoBehaviour
    {
        [SerializeField]
        public float Gravity = 4f;

        [SerializeField]
        public float Mass = 0.2f;

        [SerializeField]
        public float PushCoefficient = 4f;

        [SerializeField]
        [Editor.ReadOnly]
        public Vector3 PushVelocity = Vector3.zero;

        [SerializeField]
        [Editor.ReadOnly]
        public Vector3 MoveVelocity = Vector3.zero;

        [SerializeField]
        [Editor.ReadOnly]
        public Vector3 BaseVelocity = Vector3.zero;

        [SerializeField]
        public Vector3 TotalVelocity {
            get {
                return BaseVelocity + PushVelocity + MoveVelocity;
            }
        }
    }
}