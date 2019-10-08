using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/AND")]
    public class ANDCondition : AssetCondition
    {
        [SerializeField]
        private List<AssetCondition> _conditions;

        public override bool Verify(BaseObject target)
        {
            foreach (var cond in _conditions)
            {
                if (!cond.Verify(target))
                    return false;
            }

            return true;
        }

        public override bool Verify(World.Objects.Characters.Character target)
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
