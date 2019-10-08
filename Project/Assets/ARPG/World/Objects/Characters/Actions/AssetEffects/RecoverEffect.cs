using System.Collections;
using System.Collections.Generic;
//using Cirrus.ARPG.World.Objects.Actions.Goals;
//using Cirrus.ARPG.World.Objects.Actions.Task;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Recover")]
    public class RecoverEffect : AssetEffect
    {

        protected override void DoApply(Characters.Character source, ActionProduct action, Characters.Character target)
        {
            target.Recover();
        }
    }
}
