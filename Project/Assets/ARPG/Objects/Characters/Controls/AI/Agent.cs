using UnityEngine;
using System.Collections;
using UnityAI = UnityEngine.AI;
using System.Collections.Generic;
using Cirrus.ARPG.Conditions;
using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    public delegate void OnEnvironmentChanged(Option option, BaseObject target, params object[] args);


    public class Agent : MonoBehaviour
    {
        [SerializeField]
        public AgentPersistence _persistence;

        [SerializeField]
        public UnityAI.NavMeshAgent NavMeshAgent;

        [SerializeField]
        public Character Source;//.Attitude Hostility;

        // AFFECTS HOW A MONSTER OBSERVES YOU
        [SerializeField]
        private Attitude _curiosity;
        public AttitudeProduct Curiosity;

        [SerializeField]
        private Attitude _hostility;
        public AttitudeProduct Hostility;

        [SerializeField]
        private Attitude _anxiety;
        public AttitudeProduct Anxiety;

        [SerializeField]
        private Attitude _affection;
        public AttitudeProduct Affection;

        private Dictionary<AttitudeType, AttitudeProduct> _motivations;

        [SerializeField]
        public Actions.AbilityUser Actor;

        [SerializeField]
        [Editor.ReadOnly]
        private Option _option;

        [SerializeField]
        private Option[] _options;

        [SerializeField]
        public List<Object> DefaultTargetIgnore;

        [SerializeField]
        public List<Object> DefaultTargets;

        [SerializeField]
        private float _utilityDeltaTolerance = 0;


        public OnEnvironmentChanged OnEnvironmentChangedHandler;
  
        [SerializeField]
        [Editor.ReadOnly]
        private Decision _decision;

        public Decision Decision {
            get {
                return _decision;
            }
            private set {
                _decision = value;
                _option = _decision.Option;
            }
        }


        public void Awake()
        {
            _motivations = new Dictionary<AttitudeType, AttitudeProduct>();
            Hostility = AddAttitude(_hostility, AttitudeType.Hostility);
            Affection = AddAttitude(_hostility, AttitudeType.Affection);
            Anxiety = AddAttitude(_anxiety, AttitudeType.Anxiety);
            Curiosity = AddAttitude(_anxiety, AttitudeType.Curiosity);
        }

        // Clock requires OnEnable
        public void OnEnable()
        {
            // TODO Replace Options by SO?
            foreach (var o in _options)
            {
                if (o == null)
                    continue;

                o.Init();
            }
        }

        public void OnEnvironmentChanged(Option option, BaseObject target, params object[] args)
        {
            OnEnvironmentChangedHandler?.Invoke(option, target, args);
        }


        public void Decide()
        {
            float max = float.MinValue;
            Option bestOption = null;
            BaseObject bestTarget = null;
            foreach (Option opt in _options)
            {
                float utility; BaseObject target;
                if (opt.NoTargets)
                {
                    if (opt.Assess(out utility))
                    {
                        if (utility > max)
                        {
                            max = utility;
                            bestOption = opt;
                        }
                    }
                }
                else if (opt.Assess(out utility, out target))
                {
                    if (utility > max)
                    {
                        max = utility;
                        bestOption = opt;
                        bestTarget = target;
                    }
                }
            }

            if (bestOption != null)
            {
                Decision = bestOption.CreateDecision(Source);
            }
            else
            {
                Decision = IdleOption.Decision;
            }
        }

        /// <summary>
        /// Returns whether new decision is made
        /// </summary>
        /// <param name="option"></param>
        /// <param name="target"></param>
        /// <param name="args"></param>
        public bool Decide(Option option, BaseObject target, params object[] args)
        {
            // If newly updated state is worst
            if (!option.Assess(out float utility, target) || utility < Decision.Utility)
            {
                // If current decision is not the best anymore
                if (Decision.Option == option && Decision.Target == target)
                {
                    Decide();
                    return true;
                }

                return false;
            }
            // If newly updated state is better
            else
            {
                if (Decision.Option == option && Decision.Target == target)
                {
                    return false;
                }
                else
                {
                    _decision = option.CreateDecision(target);
                    return true;
                }
            }
        }

        public bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 circle = Random.insideUnitCircle * range;
                Vector3 randomPoint = center + new Vector3(circle.x, 0, circle.y);
                NavMeshHit hit;

                if (NavMesh.SamplePosition(randomPoint, out hit, 4.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
            }
            result = Vector3.zero;
            return false;
        }

        // TODO move method to Layout/Navmesh helper class
        public bool ClosestPoint(Vector3 point, out Vector3 result, float tolerance)
        {
            if (NavMesh.SamplePosition(point, out NavMeshHit hit, tolerance, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        }

        private AttitudeProduct AddAttitude(Attitude res, AttitudeType id)
        {
            var at = new AttitudeProduct(res, id);
            _motivations.Add(id, at);
            return at;
        }

        // TODO: GetStat(StatType type)
        public AttitudeProduct GetAttitude(AttitudeType stat)
        {
            AttitudeProduct st;

            if (_motivations.TryGetValue(stat, out st))
                return st;

            return null;
        }
    }
}
