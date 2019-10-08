using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/AI/Conditional Consideration")]
    public class ConditionalConsideration : AssetConsideration
    {
        [SerializeField]
        private AssetCondition _condition;

        [SerializeField]
        public bool _isVeto = false;

        [SerializeField]
        private float _failUtility = -1;

        [SerializeField]
        private float _successUtility = 1;

        public override bool Evaluate(Character source, BaseObject target, out float utility)
        {
            if (source.DispatchVerify(target, _condition))
            {
                utility = _successUtility;
                return true;
            }
            else
            {
                utility = _failUtility;
                return !_isVeto;
            }
        }

        public override bool Evaluate(Character source, out float utility)
        {
            if (source.Verify(_condition))
            {
                utility = _successUtility;
                return true;
            }
            else
            {
                utility = _failUtility;
                return !_isVeto;
            }
        }

        public override Objects.Conditions.ObjectListener CreateListener(Character source, BaseObject target)
        {
            return new Objects.Conditions.ConditionListener(source, target, _condition);
        }

    }


}