using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    // INCLUDES ACTION ON SELF

    public partial class Decision
    {
        public ActionOption.Data Action;
    }

    public class ActionOption : Option
    {
        public class Data
        {
            public int MaxCount;
            public Actions.Ability Action;
            public int ActionCount;
            public BaseObject Target;
            public float StopDistance;
            public Vector3 Destination;
            public NavMeshPath Path;
            public Option Option;
            public float Range;
            public float Utility;
        }


        [SerializeField]
        public int _count = 1;

          // TODO: Only allow a single action per task (Make more tasks)
        [SerializeField]
        public Actions.Ability _ability;


        public override Decision CreateDecision(BaseObject target)
        {
            return new Decision
            {
                Option = this,
                Target = target,
                State = FSM.Id.Action,
                Action = new Data{
                    ActionCount = _count,
                    Action = _ability,
                    Range = _ability.Range

                },
            };
        }

        public void OnValidate()
        {
            if (_agent == null)
            {
                if (transform.parent != null)
                {
                    _agent = transform.GetComponentInParent<Agent>();
                }
            }
           
        }


    }
}