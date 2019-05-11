using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Characters.KinematicControls
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/KinematicControls/Configuration")]
    public class Configuration : ScriptableObject
    {
        [SerializeField]
        public float Gravity = 4f;

        [SerializeField]
        public float RotationSpeed = 0.4f;

        [SerializeField]
        public float IdleThreshold = 0.4f;

        [SerializeField]
        public float Speed = 1f;

        [SerializeField]
        public float JumpSpeed = 100f;

    }
}