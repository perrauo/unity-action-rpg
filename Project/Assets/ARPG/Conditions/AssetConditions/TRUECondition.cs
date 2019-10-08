using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Conditions
{
    [CreateAssetMenu(menuName = "Cirrus/Conditions/TRUE")]
    public class TRUECondition : AssetCondition
    {
        public override bool Verify()
        {
            return true;
        }
    }
}
