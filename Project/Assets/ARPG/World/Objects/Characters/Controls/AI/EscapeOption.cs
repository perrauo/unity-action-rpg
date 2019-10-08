using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;
using Cirrus.Extensions;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    // DECISION CONTAINS LIST OF ALL TARGETS WE NEED TO AVOID
    // The consideration det whether we should put it in

    // STEP 1 Determine who I need to run away from


    // STEP 2 Determine shortest path that would prevent to go near them


    // FIND A POINT AWAY FROM ALL TARGETS
    // WE DONT REALLY CARE WHICH WAY TO EXIT (Navmesh obstacle should do the job)

    // FIND POINT IN THE NEXT STATE ITSELF NOT HERE (We may need recalc)

    public partial class Decision
    {
        public EscapeOption Escape;
    }

    public class EscapeOption : Option
    {
        public float MinSafeTime = 5f;

        public float SafeDistance = 10f;

        public float RefreshRate = 5f;

        public float TargetAreaCost = 10f;

        private bool _destSet = false;

        public float _safeTime = 0;

        //public override int Id => (int)Controls.Id.Action;

        protected override void PopulateDecision(IEnumerable<BaseObject> targets, ref Decision decision)
        {
            decision.Escape = this;
        }


        #region FSM

        private Vector3 RandomPointOnCircleEdge(float radius)
        {
            var vector2 = UnityEngine.Random.insideUnitCircle.normalized * radius;
            return new Vector3(vector2.x, 0, vector2.y);
        }

        protected override IEnumerator CalculatePathCoroutine(float waitTime)
        {
            while (true)
            {
                Vector3 centroid = GetCentroid();

                var between = _agent.Source.Transform.position - centroid;
                if (between.magnitude >= _agent.Decision.Escape.SafeDistance)
                {
                    _agent.RandomPoint(
                        _agent.Source.Transform.position,
                        1,
                        1,
                        out _destination);

                    _agent.NavMeshAgent.SetDestination(_destination);
                }
                else
                if (!_destSet || (_destination - centroid).magnitude < _agent.Decision.Escape.SafeDistance)
                {
                    _destSet = true;
                    var dir = between.normalized;

                    _agent.RandomPoint(
                        _agent.Source.Transform.position + dir * (_agent.Decision.Escape.SafeDistance + _destinationRange),
                        _destinationRange,
                        _destinationRange,
                        out _destination);

                    _agent.NavMeshAgent.SetDestination(_destination);

                }

                yield return new WaitForSeconds(waitTime);
            }
        }

        public override void BeginUpdate()
        {
            base.BeginUpdate();

            if (_agent.Source.Transform.position.IsCloseEnough(_destination, ArrivalTolerance))
            {
                _agent.Source.TargetAxes.Left = Vector2.zero;
                _agent.Source.Axes.Left /= 2;

                if (_safeTime >= _agent.Decision.Escape.MinSafeTime)
                {
                    Adapt();
                }
                else
                {
                    _safeTime += Time.deltaTime;
                }
            }
            else
            {
                _safeTime = 0;
                UpdateMovement();
            }
        }

        // Case where run away from same type of area?
        //  Does not matter because will always start from there
        public override void Enter(params object[] args)
        {
            _destSet = false;

            foreach (var t in _agent.Decision.Targets)
            {
                //Agent.Source.NavMeshModifierVolume.A
                _agent.NavMeshAgent.SetAreaCost(t.NavMeshModifierVolume.area, _agent.Decision.Escape.TargetAreaCost);
            }

            _calculatePathCoroutine = CalculatePathCoroutine(_agent.Decision.Escape.RefreshRate);
            _agent.StartCoroutine(_calculatePathCoroutine);
        }


        public override void Exit()
        {
            _agent.StopCoroutine(_calculatePathCoroutine);
        }

        public override void UpdateDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(_destination, .2f);
        }

        #endregion
    }
}