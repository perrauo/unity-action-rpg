using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Injure")]
    public class InjureEffect : AssetEffect
    {
        protected override void DoApply(ActionProduct action, BaseObject target)
        {
            //target.Injure();
        }

        protected override void DoApply(BaseObject source, ActionProduct action, Characters.Character target)
        {
            target.Injure();
        }

        protected override void DoApply(Characters.Character source, ActionProduct action, Characters.Character target)
        {
            target.Injure();
        }
        
        protected override void DoApply(ActionProduct action, Characters.Character target)
        {
            target.Injure();
        }
    }
}
