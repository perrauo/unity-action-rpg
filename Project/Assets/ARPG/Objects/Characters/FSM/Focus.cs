using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

// Select focus target (z-targeting)


namespace Cirrus.ARPG.Objects.Characters.FSM
{
    public class Focus : Resource
    {
        override public int Id { get { return (int)FSM.Id.Action; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.Resource resource) : base(context, resource) { }

        }




    }

}