using UnityEngine;
using UnityEditor;
using KinematicCharacterController;
using System;
using System.Linq;



// Character state

namespace Cirrus.ARPG.World.Objects.Characters.FSM
{
    [System.Serializable]
    public enum Id
    {
        Default = 1 << 1,
        Action = 1 << 2,
        Jump = 1 << 3,
        Dead = 1 << 4,
        Tackle = 1 << 5,
        Injured = 1 << 6,
    }

    // We don't care if we can't instantiate this SO, because it's abstract
    public abstract class Resource : Cirrus.FSM.AssetState
    {
        override public int Id { get { return -1; } }
    }

    public abstract class State : Cirrus.FSM.State
    {
        public State(object[] context, Cirrus.FSM.AssetState resource) : base(context, resource) { }
        protected Character Character { get { return (Character)Context[0]; } }
        //protected Movements.MovementUser KinematicController { get { return (Movements.MovementUser)Context[1]; } }

        public override void Enter(params object[] args) { }

        public override void Exit() { }

        public override void BeginUpdate() { }

        public override void EndUpdate() { }      

    }


}
