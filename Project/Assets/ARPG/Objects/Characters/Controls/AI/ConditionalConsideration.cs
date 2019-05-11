using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/AI/Conditional Consideration")]
    public class ConditionalConsideration : Consideration
    {
        [SerializeField]
        private DH.Conditions.BaseCondition _condition;

        [SerializeField]
        public bool _isVeto = false;

        [SerializeField]
        public BaseCondition Condition;

        [SerializeField]
        private Numeric.Operation _failOperation;

        [SerializeField]
        private Numeric.Operation _successOperation;


        public override bool Evaluate(ref float utility, Character source, BaseObject target)
        {
            if (_condition.Verify(source, target))
            {
                utility = _successOperation.Evaluate(utility);
                return true;
            }
            else
            {
                utility = _successOperation.Evaluate(utility);
                return !_isVeto;
            }
        }

        public override bool Evaluate(ref float utility, Character source, Character target)
        {
            if (_condition.Verify(source, target))
            {
                utility = _successOperation.Evaluate(utility);
                return true;
            }
            else
            {
                utility = _successOperation.Evaluate(utility);
                return !_isVeto;
            }
        }

        public override Objects.Conditions.ObjectListener CreateListener(Character source, BaseObject target)
        {
            return new Objects.Conditions.ConditionListener(source, target, _condition);
        }

    }


}