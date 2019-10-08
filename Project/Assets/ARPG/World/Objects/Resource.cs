using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects
{
    public abstract class Resource : ScriptableObject
    {
        public abstract BaseObject Template { get; }
    }
}
