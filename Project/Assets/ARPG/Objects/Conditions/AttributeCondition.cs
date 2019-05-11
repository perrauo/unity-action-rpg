using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.Editor;
using Cirrus.Tags;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.Objects.Conditions
{

    // NOTIFY ONLY IF CONDITION RESULT CHANGED

    public class AttributeCondition : ObjectCondition
    {
        [SerializeField]
        private bool _isOnPostUpdate = false;

        [SerializeField]
        private bool _isOnCurrent = false;

        [ConditionalHide("_isOnPostUpdate", isVisible = true)]
        [SerializeField]
        private Numeric.Operation _updateOperation;

        [ConditionalHide("_isOnCurrent", false)]
        [SerializeField]
        private Tag _tag;

        [SerializeField]
        private Numeric.Comparison _comparison;

        public override bool Verify(Character subj)
        {
            Attributes.Stat.Product stat = subj.Persistence.Attributes.GetStat(_tag);

            float value = _isOnCurrent ? stat.Current : stat.Total;

            if (_isOnPostUpdate)
            {
                return _comparison.Check(_updateOperation.Evaluate(value));//, stat.Total));
            }
            else
            {
                return _comparison.Check(value);
            }
        }


        // USE THE SAME THING IF COMPARISON BETWEEN TWO
        public override IState GetListenedState(BaseObject target)
        {
            return target.Attributes.GetStat(_tag);
        }

        public override IState GetListenedState(Character target)
        {
            return target.Attributes.GetStat(_tag);
        }

    }

}
