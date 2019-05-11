using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/OR")]
    public class ORCondition : BaseCondition
    {
        [SerializeField]
        private List<BaseCondition> _conditions;

        public override bool Verify(Objects.BaseObject target)
        {
            foreach (var cond in _conditions)
            {
                if (cond.Verify(target))
                    return true;
            }

            return false;
        }

        public override bool Verify(Objects.Characters.Character target)
        {
            foreach (var cond in _conditions)
            {
                if (!cond.Verify(target))
                    return true;
            }

            return false;

        }


    }
}
