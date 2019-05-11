using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects.Actions;
using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    public partial class Decision
    {
        public WanderOption.Data Wander;
    }

    public class WanderOption : Option
    {
        public class Data
        {
            public bool IsFromStart;
            public float Range;
        }

        [SerializeField]
        private bool _isFromStartPosition;

        [SerializeField]
        private float _range = 10.0f;


        public override Decision CreateDecision(BaseObject target)
        {
            return new Decision
            {
                Option = this,
                State = FSM.Id.Wander,

                Wander = new Data
                {
                    IsFromStart = _isFromStartPosition,
                    Range = _range                 
                }
                
            };
        }
    }
}
