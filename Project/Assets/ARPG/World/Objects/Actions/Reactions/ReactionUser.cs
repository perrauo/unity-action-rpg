using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.ARPG.World.Objects.Actions
{
    public class ReactionUser : MonoBehaviour
    {
        [SerializeField]
        private BaseObject _source;

        [SerializeField]
        private List<BaseReaction> _reactions;        

        public void Start()
        {
            

        }
    }
}
