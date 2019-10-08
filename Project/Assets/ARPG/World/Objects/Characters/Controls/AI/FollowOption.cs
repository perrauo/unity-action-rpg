using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;
using Cirrus.Extensions;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{

    public partial class Decision
    {
        public FollowOption Follow;
    }

    public class FollowOption : Option
    {
        [SerializeField]
        public float MinSafeTime = 5f;

        [SerializeField]
        private float _minRange = 5f;

        [SerializeField]
        private float _maxRange = 8f;

        //public override int Id => (int)Controls.Id.Follow;

        protected override void PopulateDecision(IEnumerable<BaseObject> targets, ref Decision decision)
        {            
            decision.Follow = this;
        }

        #region FSM

        protected override IEnumerator CalculatePathCoroutine(float waitTime)
        {
            while (true)
            {
                Vector3 centroid = GetCentroid();

                if (_agent.Source.Transform.position.IsCloseEnough(centroid, ArrivalTolerance))
                {
                    yield return new WaitForSeconds(waitTime);
                    continue;
                }

                if (_destination.IsCloseEnough(centroid, ArrivalTolerance))
                {
                    yield return new WaitForSeconds(waitTime);
                    continue;
                }

                if (_agent.PointBetween(
                        _agent.Source.Transform.position,
                        centroid,
                        _minRange,
                        _maxRange,
                        out _destination))
                {
                    _agent.NavMeshAgent.SetDestination(_destination);
                }

                yield return new WaitForSeconds(waitTime);
            }
        }

        public override void Enter(params object[] args)
        {
            //base.Enter(args);

            StartCalculatingPath();
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
            }
            else
            {
                UpdateMovement();
            }
        }


        public override void Reenter(params object[] args)
        {
            //base.Reenter(args);

            StartCalculatingPath();
        }

        public override void Exit()
        {
            //base.Exit();

            StopCalculatingPath();
        }

        #endregion

    }
}