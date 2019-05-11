using System;
using System.Collections;
using System.Collections.Generic;
using Cirrus.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI.FSM
{
    public class Wander : Resource
    {
        override public int Id { get { return (int)FSM.Id.Wander; } }

        public override Cirrus.FSM.State Create(object[] context)
        {
            return new State(context, this);
        }

        public class State : FSM.State
        {
            public State(object[] context, Resource resource) : base(context, resource) { }

            private WanderOption.Data _data;

            private Vector3 _center;

            private float _range;

            private float _arrivalTolerance = 2.0f;

            protected override IEnumerator CalculatePathCoroutine(float waitTime)
            {
                while (true)
                {
                    yield return new WaitForSeconds(waitTime);

                    if (Agent.RandomPoint(_center, _range, out _destination))
                    {
                        Agent.NavMeshAgent.SetDestination(_destination);
                    }

                }
            }

            public override void Enter(params object[] args)
            {
                base.Enter(args);
                DoEnter();

                _range = Agent.Decision.Wander.Range;
                _center = Agent.Decision.Wander.IsFromStart ? Character.StartPosition : Character.transform.position;
            }


            public override void BeginTick()
            {
                base.BeginTick();

                if (!Cirrus.Utils.Vectors.CloseEnough(Character.transform.position, _destination, _arrivalTolerance))
                {
                    Move();
                }
                else
                {
                    _targetAxesLeft = Vector2.zero;
                    Character.Axes.Left /= 2;
                }
            }


            public override void EndTick()
            {
                base.EndTick();
                EndMove();
            }


        }


    }

}
