using UnityEngine;
using UnityEditor;

namespace Cirrus.FSM
{
    public class Idle : AssetState
    {
        override public int Id { get { return (int) DefaultState.Idle; } }

        public override FSM.IState PopulateState(object[] context)
        {
            throw new System.NotImplementedException();
        }

        new public class State : FSM.State
        {
            public State() : base(null, null) { }
        }
    }

}
