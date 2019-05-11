using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Conditions;
using Cirrus.ARPG.Objects.Conditions;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/AI/Distance Consideration")]
    public class DistanceConsideration : Consideration
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
        private float _distanceUtilityCoefficient = 1;

        public override bool Evaluate(ref float utility, Character character, BaseObject target)
        {
            float distance = (character.transform.position - target.transform.position).sqrMagnitude;
            if (_vetoDistanceComparison.Check(distance))
            {
                return false;
            }

            utility += distance * _distanceUtilityCoefficient;
            return true;
        }

        public override bool Evaluate(ref float utility, Character character, Character target)
        {
            return Evaluate(ref utility, character, target as BaseObject);
        }

        public override ObjectListener CreateListener(Character source, BaseObject target)
        {
            return new DistanceListener(source, target, _vetoDistanceComparison, _sampleRate);
        }


        public void OnValidate()
        {
            _vetoDistanceComparison.OnValidate();
        }
    }
}