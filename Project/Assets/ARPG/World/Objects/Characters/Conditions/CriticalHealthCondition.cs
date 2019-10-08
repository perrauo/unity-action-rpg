using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters.Controls;

namespace Cirrus.ARPG.World.Objects.Characters.Conditions.Relations
{
    // Might be cool to have a buff apply in critical health
    // (about to be injured) sometimes??



    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Conditions/Critical Health")]
    public class CriticalHealthCondition : Objects.Conditions.ObjectCondition
    {
        [SerializeField]
        private Numeric.Comparison comparison;

        public override bool Verify(Character self)
        {
            return comparison.Verify(
                self.Attributes.Health.Current, 
                self.Attributes.CriticalHealthThreshold);
        }

    }

}
