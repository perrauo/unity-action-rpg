using System.Collections;
using System.Collections.Generic;
//using Cirrus.ARPG.Objects.Actions.Goals;
//using Cirrus.ARPG.Objects.Actions.Task;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Heal")]
    public class HealEffect : BaseEffect
    {
        [SerializeField]
        private Numeric.RangeInt _heal;

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


        protected override void DoApply(Characters.Character source, Characters.Character target)
        {
            float heal = 
                _hasCriticalHit && _criticalChanceCondition.Verify() ? 
                _criticalHitOperation.Evaluate(_heal.Value) : _heal.Value;

            target.Persistence.Attributes.Health.SetCurrent(target.Persistence.Attributes.Health.Current + heal);

            float criticalHealthThreshold = target.Persistence.Attributes.CriticalHealthThreshold;
            if (target.Persistence.Attributes.Health.Current >= criticalHealthThreshold)
            {
                //Recover(source);
            }
        }

        //public override void Apply(BaseObject target)
        //{
        //    target.HandleHealEffect(this, Amount);
        //}
    }
}
