using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// MODIFICATION THAT IS PROPAGATED ON CONTACT OR SOMETHING

// e.g fire should contain two modification (fire, + propagate fire)

// TODO conditional modification

namespace Cirrus.ARPG.World.Objects.Actions.Modifiers
{
    public class PropagateModifier : Modifier
    {
        private List<Modifier> modification;

        protected override Product Create(BaseObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}