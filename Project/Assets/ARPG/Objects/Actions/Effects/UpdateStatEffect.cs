using Cirrus.ARPG.Objects.Characters.Controls.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.Objects.Attributes;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Update Stat")]
    public class UpdateStatEffect : BaseEffect
    {
        [SerializeField]
        private Tag _tag;

        [SerializeField]
        public bool _isCurrentUpdate;

        [Editor.Required]
        [SerializeField]
        private Numeric.Operation _updateOperation;

        protected override void DoApply(Character target)
        {
            var stat = target.Persistence.Attributes.GetStat(_tag);
            Debug.Assert(stat != null, "Make sure the stat and effect is given a tag");
 
            if (_isCurrentUpdate)
            {
                Debug.Assert(stat.IsRatio);
                stat.SetCurrent(_updateOperation.Evaluate(stat.Current, stat.Total));
            }
            else
            {
                stat.SetTotal(_updateOperation.Evaluate(stat.Current, stat.Total));
            }
        }

        protected override void DoApply(Character source, Character target)
        {
            DoApply(target);
        }
    }
}
