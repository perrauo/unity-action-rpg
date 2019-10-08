using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.Editor;
using Cirrus.Tags;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.World.Objects.Conditions
{

    // NOTIFY ONLY IF CONDITION RESULT CHANGED

    [CreateAssetMenu(menuName = "Cirrus/Objects/Conditions/Attribute")]
    public class AttributeCondition : ObjectCondition
    {
        [SerializeField]
        private Tag _tag;

        [SerializeField]
        private Numeric.Comparison _comparison;

        enum Mode
        {
            Ratio,
            Current,
            Total
        }

        [SerializeField]
        private Mode _mode = Mode.Ratio;


        public override bool Verify(Characters.Character subj)
        {
            Attributes.StatResource.StatPersistence stat = 
                subj.Attributes.GetStat(_tag);

            switch (_mode)
            {
                case Mode.Ratio:
                    return _comparison.Verify(stat.Current / stat.Total);
                case Mode.Current:
                    return _comparison.Verify(stat.Current);
                case Mode.Total:
                    return _comparison.Verify(stat.Total);
                default:
                    return false;
            }    
        }

        public override bool Verify(Characters.Character source, Characters.Character target)
        {
            Attributes.StatResource.StatPersistence stat1 = source.Attributes.GetStat(_tag); 
            Attributes.StatResource.StatPersistence stat2 = source.Attributes.GetStat(_tag);

            float value1, value2 = 0;
            switch (_mode)
            {
                case Mode.Ratio:
                    value1 = stat1.Current / stat1.Total;
                    value2 = stat2.Current / stat2.Total;
                    break;
                case Mode.Current:
                    value1 = stat1.Current / stat1.Total;
                    value2 = stat2.Current / stat2.Total;
                    break;
                case Mode.Total:
                    value1 = stat1.Current / stat1.Total;
                    value2 = stat2.Current / stat2.Total;
                    break;
                default:
                    return false;
            }

            return _comparison.Verify(value1 - value2);
        }


        // USE THE SAME THING IF COMPARISON BETWEEN TWO
        public override IConditionedState GetListenedState(BaseObject target)
        {
            return target.Attributes.GetStat(_tag);
        }

        public override IConditionedState GetListenedState(Characters.Character target)
        {
            return target.Attributes.GetStat(_tag);
        }

    }

}
