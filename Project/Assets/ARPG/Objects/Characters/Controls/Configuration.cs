using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Cirrus.ARPG.Objects.Characters.Controls
{ 
    // should not be shared, instead updates from attributes should be sent if needed
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Controls/Configuration")]
    public class Configuration : ScriptableObject
    {
        [SerializeField]
        public float LedgeHeightJumpThreshold = 2f;

        [SerializeField]
        public float AxesSmooth = 0.4f;

        [SerializeField]
        public float AxesSensitivity = 0.4f;
    }

}
