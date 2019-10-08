using Cirrus.ARPG.World.Objects.Characters.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.World.Objects.Attributes;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.Tags;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Update Stat")]
    public class UpdateStatEffect : AssetEffect
    {
        [SerializeField]
        private Tag _tag;

        [SerializeField]
        private bool _isOperation = false;

        [Editor.ConditionalHide("_isOperation", isVisible = false)]
        [SerializeField]
        private float _value = 1f;

        [Editor.ConditionalHide("_isOperation", isVisible =true)]
        [SerializeField]
        private Numeric.Operation _updateOperation;

        protected override void DoApply(ActionProduct action, Characters.Character target)
        {
            var stat = target.Attributes.GetStat(_tag);
            Debug.Assert(stat != null, "Make sure the stat and effect is given a tag");
            if (_isOperation)
            {
                stat.SetCurrent(_updateOperation.Evaluate(stat.Current, stat.Total));
            }
            else
            {
                stat.SetCurrent(stat.Current + _value);
            }           
        }

        protected override void DoApply(Character source, ActionProduct action, Character target)
        {
            DoApply(action, target);
        }
    }
}
