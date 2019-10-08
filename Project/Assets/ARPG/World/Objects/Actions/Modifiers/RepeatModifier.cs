using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.Editor;

// STACKABLE HANDLING
// TIERS OF EFFECTS

namespace Cirrus.ARPG.World.Objects.Actions.Modifiers
{
    public class RepeatModifier : Modifier
    {

        [SerializeField]
        private AssetAction _action;

        [SerializeField]
        private float _cooldown = 1;

        [SerializeField]
        private bool _isLimitedRepeats;

        [ConditionalHide("_isLimitedRepeats", isVisible =true)]
        [SerializeField]
        private int _repeats;

        protected override Modifier.Product Create(BaseObject target)
        {
            return new Product(this, target);
        }
        
        public class Product : Modifier.Product
        {
            RepeatModifier _resource;

            [SerializeField]
            private ActionProduct _action;

            private float _time = 0;

            public Product(RepeatModifier resource, BaseObject target) : base(resource, target)
            {
                _action = resource._action.Create();
                _resource = resource;
                Game.Instance.Clock.OnTickedHandler += OnTicked;
            }

            public override void EndPersistence()
            {
                base.EndPersistence();
                Game.Instance.Clock.OnTickedHandler -= OnTicked;
            }

            private void OnTicked()
            {
                _time += Time.deltaTime;
                if (_time >= _resource._cooldown)
                {
                    _time = 0;
                    _action.UseAgainst(_target);
                }
            }
        }


    }
}