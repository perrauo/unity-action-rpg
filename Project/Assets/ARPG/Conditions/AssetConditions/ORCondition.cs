using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/OR")]
    public class ORCondition : AssetCondition
    {
        [SerializeField]
        private List<AssetCondition> _conditions;

        public override bool Verify(World.Objects.BaseObject target)
        {
            foreach (var cond in _conditions)
            {
                if (cond.Verify(target))
                    return true;
            }

            return false;
        }

        public override bool Verify(World.Objects.Characters.Character target)
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
