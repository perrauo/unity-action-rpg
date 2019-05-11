using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.Objects.Actions
{
    public class ActionReaction : InteractionReaction
    {
        public override void Start()
        {
            base.Start();
            _source.OnActionHandledEvent += OnActionHandled;
        }

        public void OnActionHandled(Action.Product act)
        {
            if (_tags.Intersect(act.Tags).Count() != 0)
            {
                OnInteraction(act.Source);
            }
        }

    }
}
