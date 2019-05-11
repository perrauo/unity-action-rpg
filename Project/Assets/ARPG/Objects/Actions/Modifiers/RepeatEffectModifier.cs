using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.Editor;

// STACKABLE HANDLING
// TIERS OF EFFECTS

namespace Cirrus.ARPG.Objects.Actions.Modifiers
{
    public class RepeatEffectModification : Modifier
    {
        [SerializeField]
        private List<DH.Actions.BaseEffect> _effects;

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
            RepeatEffectModification _resource;

            private float _time = 0;

            public Product(RepeatEffectModification resource, BaseObject target) : base(resource, target)
            {
                _resource = resource;
                Levels.Room.Instance.Clock.OnTickedHandler += OnTicked;
            }

            public override void EndPersistence()
            {
                base.EndPersistence();
                Levels.Room.Instance.Clock.OnTickedHandler -= OnTicked;
            }

            private void OnTicked()
            {
                _time += UnityEngine.Time.deltaTime;
                if (_time >= _resource._cooldown)
                {
                    _time = 0;
                    ApplyEffects();
                }
            }

            private void ApplyEffects()
            {
                foreach (DH.Actions.BaseEffect effect in _resource._effects)
                {
                    effect.TryApply(_target);
                }
            }
        }


    }
}