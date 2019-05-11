using UnityEngine;
using UnityEditor;

namespace Cirrus.FSM
{
    public class Idle : Resource
    {
        override public int Id { get { return (int) DefaultState.Idle; } }

        public override FSM.State Create(object[] context)
        {
            throw new System.NotImplementedException();
        }

        new public class State : FSM.State
        {
            public State() : base(null, null) { }
        }
    }

}
