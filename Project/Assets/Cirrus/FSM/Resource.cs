using UnityEngine;
using UnityEditor;
using System;

namespace Cirrus.FSM
{
    enum DefaultState
    {
        Idle = -1,
    }

    public abstract class Resource : ScriptableObject
    {
        virtual public int Id { get { return -1; } }
        public abstract State Create(object[] context);
    }

}
