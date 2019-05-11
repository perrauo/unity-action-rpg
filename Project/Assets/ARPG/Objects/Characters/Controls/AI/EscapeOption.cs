using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    // DECISION CONTAINS LIST OF ALL TARGETS WE NEED TO AVOID
    // The consideration det whether we should put it in

    // STEP 1 Determine who I need to run away from


    // STEP 2 Determine shortest path that would prevent to go near them


    // FIND A POINT AWAY FROM ALL TARGETS
    // WE DONT REALLY CARE WHICH WAY TO EXIT (Navmesh obstacle should do the job)

    // FIND POINT IN THE NEXT STATE ITSELF NOT HERE (We may need recalc)



    public abstract class EscapeOption : Option
    {
        public override Decision CreateDecision(BaseObject target)
        {
            return new Decision
            {
                Option = this,
                Target = target
            };
        }

    }
}