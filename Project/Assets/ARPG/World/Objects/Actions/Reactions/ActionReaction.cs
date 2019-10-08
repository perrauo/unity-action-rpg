using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Reactions/Action Reaction")]
    public class ActionReaction : InteractionReaction
    {
        [SerializeField]
        private List<Tags.Tag> _tags;

        public override void Awake()
        {
            base.Awake();

            _source.OnActionHandledEvent += OnActionHandled;
        }

        public void OnActionHandled(ActionProduct act)
        {
            if (_tags.Intersect(act.Tags).Count() != 0)
            {
                //OnInteraction(act.Source);
            }
        }
    }
}
