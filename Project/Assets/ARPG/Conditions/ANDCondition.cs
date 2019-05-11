using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects;
using Cirrus.ARPG.Objects.Characters;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/AND")]
    public class ANDCondition : BaseCondition
    {
        [SerializeField]
        private List<BaseCondition> _conditions;

        public override bool Verify(BaseObject target)
        {
            foreach (var cond in _conditions)
            {
                if (!cond.Verify(target))
                    return false;
            }

            return true;
        }

        public override bool Verify(Character target)
        {
            foreach (var cond in _conditions)
            {
                if (!cond.Verify(target))
                    return false;
            }

            return true;

        }


    }
}
