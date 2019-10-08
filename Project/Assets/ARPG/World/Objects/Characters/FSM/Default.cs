using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;
//using Cirrus.FSM;

namespace Cirrus.ARPG.World.Objects.Characters.FSM
{
    public class Default : Resource
    {
        override public int Id { get { return (int)FSM.Id.Default; } }

        public override Cirrus.FSM.IState PopulateState(object[] context)
        {
            return new State(context, this);
        }

        new public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.AssetState resource) : base(context, resource) { }
        }


    }

}