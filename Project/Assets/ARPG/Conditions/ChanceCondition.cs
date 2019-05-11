using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/Chance")]
    public class ChanceCondition : BaseCondition
    {
        [SerializeField]
        private Numeric.Chance _chance;
        
        public override bool Verify()
        {
            return _chance.IsOccurrence;
        }
    }
}