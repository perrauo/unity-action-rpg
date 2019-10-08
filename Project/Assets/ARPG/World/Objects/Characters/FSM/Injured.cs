using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

// Select focus target (z-targeting)


namespace Cirrus.ARPG.World.Objects.Characters.FSM
{
    public class Injured : Resource
    {
        override public int Id { get { return (int)FSM.Id.Injured; } }

        public override IState PopulateState(object[] context)
        {
            return new State(context, this);
        }

        public class State : FSM.State
        {
            public State(object[] context, AssetState resource) : base(context, resource) { }

        }
    }

}