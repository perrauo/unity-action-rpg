using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;

namespace Cirrus.ARPG.Objects.Characters.FSM
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/FSM/Action")]
    public class Action : Resource
    {
        override public int Id { get { return (int)FSM.Id.Action; } }

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