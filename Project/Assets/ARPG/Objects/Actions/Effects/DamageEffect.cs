using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects.Characters;
//using Cirrus.ARPG.Objects.Actions.Goals;
//using Cirrus.ARPG.Objects.Actions.Task;
using UnityEngine;
//using Objects.Characters;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Damage")]
    public class DamageEffect : DH.Actions.BaseEffect
    {
        [SerializeField, Editor.EnumFlag]
        public DH.Objects.Elements.Element _type;

        [SerializeField]
        private Numeric.RangeInt _damage;

        [SerializeField]
        private bool _hasCriticalHit = false;

        [SerializeField]
        [Editor.ConditionalHide("_hasCriticalHit", isVisible = true)]
        [Editor.Required]
        private DH.Conditions.ChanceCondition _criticalChanceCondition;

        [SerializeField]
        [Editor.ConditionalHide("_hasCriticalHit", isVisible = true)]
        [Editor.Required]
        private Numeric.Operation _criticalHitOperation;

        protected override void DoApply(BaseObject source, BaseObject target)
        {

        }
        
        protected override void DoApply(Character source, Character target)
        {
            // Factor in defence
            float damage = _hasCriticalHit ? _criticalHitOperation.Evaluate(_damage.Value) : _damage.Value;
            target.Persistence.Attributes.Health.SetCurrent(target.Persistence.Attributes.Health.Current - damage) ;


            float criticalHealthThreshold = target.Persistence.Attributes.CriticalHealthThreshold;
            if (target.Persistence.Attributes.Health.Current < criticalHealthThreshold)
            {
                //target.Injure(source);
            }
        }


    }
}
