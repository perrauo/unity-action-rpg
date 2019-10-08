using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;
using Cirrus.Extensions;
using System.Linq;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    // INCLUDES ACTION ON SELF

    public partial class Decision
    {
        public ActionOption Action;
    }

    public class ActionOption : Option
    {
        [SerializeField]
        public int _count = 1;

        // TODO: Only allow a single action per task (Make more tasks)
        [SerializeField]
        public Actions.SceneSkill Ability;

        //public override int Id => (int) Controls.Id.Action;

        protected override void PopulateDecision(IEnumerable<BaseObject> targets, ref Decision decision)
        {
            decision.Action = this;      
        }

        public override void OnValidate()
        {
            base.OnValidate();

            if (_agent == null)
            {
                if (transform.parent != null)
                {
                    _agent = transform.GetComponentInParent<Agent>();
                }
            }       
        }

        #region FSM

        [SerializeField]
        private Numeric.Chance _chanceRandomPosition;

        private bool _isAbilityActive = false;

        private Vector3 _abilityStartPosition;

        //private Actions.Ability _ability;


        protected override IEnumerator CalculatePathCoroutine(float waitTime)
        {
            while (true)
            {
                if (Ability == null)
                {
                    yield return new WaitForSeconds(waitTime);
                    continue;
                }

                if (_isAbilityActive)
                {
                    yield return new WaitForSeconds(waitTime);
                    continue;
                }

                Vector3 centroid = GetCentroid();

                if (_agent.Source.Transform.position.IsBetween(centroid, Ability.MaxRange, Ability.MinRange))
                {
                    yield return new WaitForSeconds(waitTime);
                    continue;
                }

                if (_destination.IsBetween(centroid, Ability.MaxRange, Ability.MinRange))
                {
                    yield return new WaitForSeconds(waitTime);
                    continue;
                }

                if (_chanceRandomPosition.IsTrue)
                {
                    if (_agent.RandomClosestPoint(
                            centroid,
                            Ability.MinRange,
                            Ability.MaxRange,
                            out _destination))
                    {
                        _agent.NavMeshAgent.SetDestination(_destination);
                    }
                }
                else
                {
                    if (_agent.PointBetween(
                            _agent.Source.Transform.position,
                            centroid,
                            Ability.MinRange,
                            Ability.MinRange,
                            out _destination))
                    {
                        _agent.NavMeshAgent.SetDestination(_destination);
                    }
                }

                yield return new WaitForSeconds(waitTime);
            }
        }

        public override void Enter(params object[] args)
        {
            base.Enter(args);

            //_ability = _agent.Decision.Action.Ability;
            Ability.OnEndLagFinishedHandler += OnAbilityEndLagFinished;

            StopCalculatingPath();
            StartCalculatingPath();
        }

        public override void Reenter(params object[] args)
        {
            base.Reenter(args);

            //_ability = _agent.Decision.Action.Ability;
            Ability.OnEndLagFinishedHandler += OnAbilityEndLagFinished;

            StopCalculatingPath();
            StartCalculatingPath();

        }

        public void TryUseAbility()
        {
            if (!_agent.Source.AbilityUser.IsLagging && Ability.IsAvailable)
            {
                if (_agent.Decision.Targets.Count() == 1 &&
                    _agent.Source.TryUseAbilityAgainst(
                        Ability,
                        _agent.Decision.Targets.First()))
                {
                    StopCalculatingPath();
                    _abilityStartPosition = _agent.Source.Transform.position;
                    _isAbilityActive = true;
                }
                else if (_agent.Source.TryUseAbility(Ability))
                {
                    StopCalculatingPath();
                    _abilityStartPosition = _agent.Source.Transform.position;
                    _isAbilityActive = true;
                }
            }
        }

        // If ability is finished 
        // i.e finished lagging means a new ability can be used
        public void OnAbilityEndLagFinished()
        {
            _isAbilityActive = false;
            StartCalculatingPath();
        }

        public override void BeginUpdate()
        {
            base.BeginUpdate();


            if (_isAbilityActive)
            {
                _agent.Source.TargetAxes.Right =
                    new Vector2(Ability.Direction.x, Ability.Direction.z).normalized;
            }
            else
            {
                if (
                    _abilityStartPosition.IsCloseEnough(
                        _destination,
                        ArrivalTolerance))
                {
                    TryUseAbility();
                }
                else if (
                        _agent.Source.Transform.position.IsCloseEnough(
                            _destination,
                            ArrivalTolerance))
                {
                    _agent.Source.TargetAxes.Left = Vector2.zero;
                    _agent.Source.Axes.Left /= 2;

                    TryUseAbility();
                }
                else
                {
                    var dir = _destination - _agent.Source.Transform.position;
                    _agent.Source.TargetAxes.Right = new Vector2(dir.x, dir.z);
                    UpdateMovement();
                }

            }
        }


        public override void EndUpdate()
        {
            base.EndUpdate();
        }

        public override void Exit()
        {
            StopCalculatingPath();

            if (Ability != null)
                Ability.OnEndLagFinishedHandler -= OnAbilityEndLagFinished;

            _agent.Source.Axes.Left = Vector2.zero;
            base.Exit();
        }

        public override void UpdateDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_destination, .2f);
        }


        #endregion

    }
}