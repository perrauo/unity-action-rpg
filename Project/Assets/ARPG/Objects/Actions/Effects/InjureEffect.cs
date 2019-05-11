using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.Objects.Actions
{
    //[CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Injure")]
    public class InjureEffect : BaseEffect
    {
        protected override void DoApply(Character target)
        {
            //target.State.Injure();
            //target.Operator.Injure();
        }
    }
}
