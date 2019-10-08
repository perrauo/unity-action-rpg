using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Kill")]
    public class KillEffect : AssetEffect
    {
        protected override void DoApply(ActionProduct action, Characters.Character target)
        {
            target.Kill();
        }
    }
}
