using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.Conditions;
using Cirrus.ARPG.World.Objects.Conditions;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/AI/Distance Consideration")]
    public class DistanceConsideration : AssetConsideration
    {
        [Header("At what rate should we check for distance")]
        [SerializeField]
        private float _sampleRate = 2;

        [SerializeField]
        private float _sampleTolerance = 1;

        [SerializeField]
        public bool _isVeto = true;

        [Editor.ConditionalHide("_isVeto", isVisible = true)]
        [Header("Comparison to distance from which we compare for veto")]
        [SerializeField]
        private Numeric.Comparison _vetoDistanceComparison = null;

        [SerializeField]
        private float _distanceUtility = 1;

        [Header("Is greater distance from the target useful to the agent.")]
        [SerializeField]
        private bool _isDistanceUseful = false;

        public override bool Evaluate(Character character, BaseObject target, out float utility)
        {
            float distance = (character.Transform.position - target.Transform.position).magnitude;
            if (_vetoDistanceComparison.Verify(distance))
            {
                utility = 0;
                return false;
            }

            float distUtility =
                _isDistanceUseful ?
                _distanceUtility * (distance / _vetoDistanceComparison.Reference.Value) :
                _distanceUtility * (1 - (distance / _vetoDistanceComparison.Reference.Value));

            utility = distUtility;
            return true;
        }

        public override ObjectListener CreateListener(Character source, BaseObject target)
        {
            return new DistanceListener(source, target, _vetoDistanceComparison, _sampleRate);
        }


        public void OnValidate()
        {
            _vetoDistanceComparison.OnValidate();
        }

        public override bool Evaluate(Character source, out float utility)
        {
            throw new System.NotImplementedException();
        }
    }
}