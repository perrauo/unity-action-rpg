using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects.Actions;
using UnityEngine.AI;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public partial class Decision
    {
        public IdleOption Idle;
    }


    public class IdleOption : Option
    {
        //public override int Id => (int)Controls.Id.Idle;

        protected override void PopulateDecision(IEnumerable<BaseObject> targets, ref Decision decision)
        {
            decision.Idle = this;
        }
    }
}
