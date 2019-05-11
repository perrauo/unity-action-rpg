using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/TRUE")]
    public class TRUECondition : BaseCondition
    {
        public override bool Verify()
        {
            return true;
        }
    }
}
