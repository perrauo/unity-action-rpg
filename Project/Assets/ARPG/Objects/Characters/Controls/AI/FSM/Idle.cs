using System;
using System.Collections;
using System.Collections.Generic;
using Cirrus.FSM;
using Cirrus.FSM;
using UnityEngine;

using System.Timers;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI.FSM
{
    public class Idle : Resource
    {
        override public int Id { get { return (int)FSM.Id.Idle; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        public class State : FSM.State
        {
            public State(object[] context, Idle resource) : base(context, resource)
            {
 
            }
        }

    }

}
