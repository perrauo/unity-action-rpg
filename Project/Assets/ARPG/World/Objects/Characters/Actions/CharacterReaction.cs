using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    public abstract class CharacterReaction : Objects.Actions.BaseReaction
    {
        [SerializeField]
        protected Character _character;

        public override void OnValidate()
        {
            base.OnValidate();

            if(_character == null)
                _character = GetComponentInParent<Character>();
        }
    }
}
