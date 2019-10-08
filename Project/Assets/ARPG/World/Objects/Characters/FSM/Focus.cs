using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

// Select focus target (z-targeting)


namespace Cirrus.ARPG.World.Objects.Characters.FSM
{
    public class Focus : Resource
    {
        override public int Id { get { return (int)FSM.Id.Action; } }

        public override Cirrus.FSM.IState PopulateState(object[] context)
        {
            return new State(context, this);
        }

        public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.AssetState resource) : base(context, resource) { }

        }




    }

}