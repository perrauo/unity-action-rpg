using Cirrus.ARPG.Objects.Characters.Controls.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.Objects.Characters;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Attitude")]
    public class AttitudeEffect : BaseEffect
    {
        [SerializeField]
        private AttitudeType _type;

        [Editor.Required]
        [SerializeField]
        private Numeric.Operation _operation;

        [SerializeField]
        private bool _isBaseUpdate;

        protected override void DoApply(Character source, Character target)
        {
            var attitude = target.Agent.GetAttitude(_type);
            Debug.Assert(attitude != null);


            if (_isBaseUpdate)
            {
                attitude.BaseValue = _operation.Evaluate(attitude.BaseValue);
            }
            else
            {
                float result = attitude.GetTowards(source);
                attitude.SetTowards(source, _operation.Evaluate(result));
            }
        }
    }
}
