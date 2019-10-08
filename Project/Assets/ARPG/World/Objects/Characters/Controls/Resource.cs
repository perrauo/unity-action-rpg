using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Cirrus.ARPG.World.Objects.Characters.Controls
{ 
    // should not be shared, instead updates from attributes should be sent if needed
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Controls/Resource")]
    public class Resource : ScriptableObject
    {
        // Raycast to determine if slop, or jump
        [SerializeField]
        public float LedgeRaycastLenght = 4f;

        [SerializeField]
        public float AxesLeftStep = 0.4f;

        [SerializeField]
        public float AxesRightStep = 0.4f;


        [SerializeField]
        public float LedgeHeightJumpThreshold = 2f;

        [SerializeField]
        public float AxesSmooth = 0.4f;

        [SerializeField]
        public float AxesSensitivity = 0.4f;
    }

}
