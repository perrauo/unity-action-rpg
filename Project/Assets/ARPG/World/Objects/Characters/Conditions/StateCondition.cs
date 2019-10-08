using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters.Controls;

namespace Cirrus.ARPG.World.Objects.Characters.Conditions.Relations
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Conditions/State")]
    public class StateCondition : Objects.Conditions.ObjectCondition
    {
        [SerializeField]
        [Cirrus.Editor.EnumFlag]
        private Characters.FSM.Id _state;

        [SerializeField]
        private float _reference;

        public override bool Verify(Character self)
        {
            return (self.FSM.Top.Id & (int)_state) != 0; 
        }

    }

}
