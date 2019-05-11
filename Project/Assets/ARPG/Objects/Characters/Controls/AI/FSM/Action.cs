using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI.FSM
{
    public class Action : Resource
    {
        override public int Id { get { return (int)FSM.Id.Action; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        public class State : FSM.State
        {
            public State(object[] context, Resource resource) : base(context, resource) { }

  
            new public Action Resource { get { return (Action)base.Resource; } }

            public State(object[] context, Action resource) : base(context, resource) { }

            private ActionOption.Data _data;

            protected override IEnumerator CalculatePathCoroutine(float waitTime)
            {
                while (true)
                {
                    yield return new WaitForSeconds(waitTime);

                    if (Cirrus.Utils.Vectors.CloseEnough(_sampledPosition, _target.transform.position))
                    {
                        continue;
                    }

                    _sampledPosition = _target.transform.position;

                    if (Agent.ClosestPoint(_target.transform.position, out _destination, _data.Range))
                    {
                        Agent.NavMeshAgent.SetDestination(_destination);
                    }                   
                }
            }


            public override void Enter(params object[] args)
            {
                base.Enter(args);

                DoEnter();

                _target = Agent.Decision.Target;
                _data = Agent.Decision.Action;
            }

            public override void BeginTick()
            {
                base.BeginTick();

                var dir = _target.transform.position - Character.transform.position;
                _targetAxesRight = new Vector2(dir.x, dir.z);

                if (Cirrus.Utils.Vectors.CloseEnough(Character.transform.position, _target.transform.position, _data.Range))
                {
                    Character.Axes.Left = Vector2.zero;

                    if (!Character.AbilityUser.IsLagging && _data.Action.IsAvailable)
                    {
                        Character.UseAction(_data.Action, _target);
                    }
                }
                else
                {
                    Move();
                }
            }




            public override void EndTick()
            {
                base.EndTick();

                EndMove();
            }


            public override void Exit()
            {
                Agent.StopCoroutine(_calculatePathCoroutine);
                Character.Axes.Left = Vector2.zero; //TODO ease out
                base.Exit();
            }


            public override void OnDrawGizmos()
            {
                foreach (Vector3 waypoint in Agent.NavMeshAgent.path.corners)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(waypoint, .2f);
                }

                Gizmos.color = Color.red;
                Gizmos.DrawSphere(Agent.NavMeshAgent.destination, .2f);
            }   
        }
    }

}
