using Cirrus.ARPG.World.Objects.Characters.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Attitude")]
    public class AttitudeEffect : AssetEffect
    {
        [SerializeField]
        private AttitudeType _type;

        [Editor.Required]
        [SerializeField]
        private Numeric.Operation _operation;

        [SerializeField]
        private bool _isBaseUpdate;

        protected override void DoApply(Character source, ActionProduct action, Character target)
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
