using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;
using Cirrus.FSM;

namespace Cirrus.ARPG.Objects.Characters.FSM
{
    public class Dead : Resource
    {
        override public int Id { get { return (int)FSM.Id.Dead; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        new public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }
        }


    }

}