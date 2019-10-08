using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.Playable
{
    public class Resources : ScriptableObject
    { 
        [SerializeField]
        public Character[] Characters;

        //[SerializeField]
        //public Controls PlayerController;
    }
}
