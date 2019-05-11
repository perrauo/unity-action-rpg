using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects;
using Cirrus.ARPG.Objects.Characters;

namespace Cirrus.ARPG.Actions
{
    public class MultiEffect : BaseEffect
    {
        [SerializeField]
        private List<BaseEffect> _effects;

        protected override void DoApply()
        {
            foreach (var ef in _effects)
            {
                ef.TryApply();
            }
        }

        protected override void DoApply(BaseObject target)
        {
            foreach (var ef in _effects)
            {
                ef.TryApply(target);
            }
        }

        protected override void DoApply(Character target)
        {
            foreach (var ef in _effects)
            {
                ef.TryApply(target);
            }
        }

        protected override void DoApply(BaseObject source, BaseObject target)
        {
            foreach (var ef in _effects)
            {
                ef.TryApply(source, target);
            }
        }


        protected override void DoApply(BaseObject source, Character target)
        {
            foreach (var ef in _effects)
            {
                ef.TryApply(source, target);
            }
        }

        protected override void DoApply(Character source, Character target)
        {
            foreach (var ef in _effects)
            {
                ef.TryApply(source, target);
            }
        }

        protected override void DoApply(Character source, BaseObject target)
        {
            foreach (var ef in _effects)
            {
                ef.TryApply(source, target);
            }
        }









    }
}
