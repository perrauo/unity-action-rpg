using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects.Actions;
using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{

    public partial class Decision
    {
        public PatrolOption.Data Patrol;
    }

    public class PatrolOption : Option
    {
        public class Data
        {
            public IEnumerable<Vector3> WayPoints;
        }

        [SerializeField]
        private bool _isFromStartPosition;

        [SerializeField]
        private float _range = 10.0f;


        // TODO
        public override Decision CreateDecision(BaseObject target)
        {
            return new Decision
            {
                Option = this,
                Target = target,
                State = FSM.Id.Wander,

                Patrol = new Data
                {
  
                }

            };
        }
    }
}
