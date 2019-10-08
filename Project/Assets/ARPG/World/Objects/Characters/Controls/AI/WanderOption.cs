using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects.Actions;
using UnityEngine.AI;
using Cirrus.Extensions;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public partial class Decision
    {
        public WanderOption Wander;
    }

    public class WanderOption : Option
    {
        [SerializeField]
        public bool IsFromStartPosition;

        [SerializeField]
        public float MinRange = 4.0f;

        [SerializeField]
        public float MaxRange = 10.0f;

        private Vector3 _center;

        private float _minRange;

        private float _maxRange;

        private Timer _timer;

        protected override void PopulateDecision(IEnumerable<BaseObject> targets, ref Decision decision)
        {            
            decision.Wander = this;
        }

        #region FSM


        protected override IEnumerator CalculatePathCoroutine(float waitTime)
        {
            while (true)
            {
                if (_agent.RandomPoint(_center, _agent.Decision.Wander.MinRange, _agent.Decision.Wander.MaxRange, out _destination))
                {
                    _agent.NavMeshAgent.SetDestination(_destination);
                }

                yield return new WaitForSeconds(waitTime);
            }
        }

        public override void UpdateDrawGizmos()
        {
            base.UpdateDrawGizmos();

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_destination, .2f);

        }


        public override void Enter(params object[] args)
        {
            base.Enter(args);

            _destination = Vector3.positiveInfinity;
            StopCalculatingPath();
            StartCalculatingPath();

            _minRange = _agent.Decision.Wander.MaxRange;
            _center = _agent.Decision.Wander.IsFromStartPosition ? _agent.Source.StartPosition : _agent.Source.Transform.position;
        }

        public override void Reenter(params object[] args)
        {
            base.Reenter(args);

            _destination = Vector3.positiveInfinity;
            StopCalculatingPath();
            StartCalculatingPath();

            _minRange = _agent.Decision.Wander.MaxRange;
            _center = _agent.Decision.Wander.IsFromStartPosition ? _agent.Source.StartPosition : _agent.Source.Transform.position;
        }

        public override void Exit()
        {
            StopCalculatingPath();

            _agent.Source.Axes.Left = Vector2.zero;
            base.Exit();
        }


        public override void BeginUpdate()
        {
            base.BeginUpdate();

            if (_agent.Source.Transform.position.IsCloseEnough(
                _destination,
                ArrivalTolerance))
            {
                _agent.Source.TargetAxes.Left = Vector2.zero;
                _agent.Source.Axes.Left /= 2;

                _agent.NavMeshAgent.transform.position = _agent.Source.Transform.position;
                _agent.NavMeshAgent.velocity = _agent.Source.MovementUser.Motor.Velocity;

                _controller.FSM.TrySetState(Controls.Id.Idle);
            }
            else
            {
                UpdateMovement();
            }
        }


        public override void EndUpdate()
        {
            base.EndUpdate();
        }

        #endregion

    }
}
