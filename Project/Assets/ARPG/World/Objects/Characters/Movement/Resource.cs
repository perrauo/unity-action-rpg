using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.Movements
{

    // CHARACTER SPECIFIC
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/KinematicControls/Resource")]
    public class Resource : ScriptableObject
    {
        [SerializeField]
        public float RotationSpeed = 0.4f;

        [SerializeField]
        public float IdleThreshold = 0.4f;

        [SerializeField]
        public float MaxSpeed = 1f;

        [SerializeField]
        public float SpeedSmooth = 0.4f;

        [SerializeField]
        public float ShoveCoefficient = 0.2f;

        [SerializeField]
        public float JumpSpeed = 100f;

    }
}