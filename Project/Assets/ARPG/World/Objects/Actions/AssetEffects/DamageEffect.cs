using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.World.Objects.Characters;
//using Cirrus.ARPG.World.Objects.Actions.Goals;
//using Cirrus.ARPG.World.Objects.Actions.Task;
using UnityEngine;
//using Objects.Characters;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Damage")]
    public class DamageEffect : AssetEffect
    {
        [SerializeField, Editor.EnumFlag]
        public ARPG.World.Objects.Elements.Element _type;

        [SerializeField]
        private Numeric.RangeInt _damage;

        [SerializeField]
        private bool _hasCriticalHit = false;

        [SerializeField]
        [Editor.ConditionalHide("_hasCriticalHit", isVisible = true)]
        [Editor.Required]
        private ARPG.Conditions.ChanceCondition _criticalChanceCondition;

        [SerializeField]
        [Editor.ConditionalHide("_hasCriticalHit", isVisible = true)]
        [Editor.Required]
        private Numeric.Operation _criticalHitOperation;

        protected override void DoApply(BaseObject source, ActionProduct action, BaseObject target)
        {

        }
        
        protected override void DoApply(Character source, ActionProduct action, Characters.Character target)
        {
            // Factor in defence
            float damage = _hasCriticalHit ? _criticalHitOperation.Evaluate(_damage.Value) : _damage.Value;
            target.Attributes.Health.SetCurrent(target.Attributes.Health.Current - damage) ;


            float criticalHealthThreshold = target.Attributes.CriticalHealthThreshold;
            if (target.Attributes.Health.Current < criticalHealthThreshold)
            {
                //target.Injure(source);
            }
        }


    }
}
