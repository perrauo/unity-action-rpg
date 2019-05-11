using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/FALSE")]
    public class FALSECondition : BaseCondition
    {
        public override bool Verify()
        {
            return false;
        }
    }
}
