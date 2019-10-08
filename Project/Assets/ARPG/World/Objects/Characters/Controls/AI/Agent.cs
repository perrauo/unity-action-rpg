using UnityEngine;
using System.Collections;
using UnityAI = UnityEngine.AI;
using System.Collections.Generic;
using Cirrus.ARPG.Conditions;
using UnityEngine.AI;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public delegate void OnEnvironmentChanged(Option option, BaseObject target, params object[] args);


    public class Agent : MonoBehaviour
    {
        [SerializeField]
        public AgentPersistence _persistence;

        [SerializeField]
        public NavMeshAgent NavMeshAgent;

        [SerializeField]
        public Character Source;

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
        private Option[] _options;

        [SerializeField]
        public IdleOption _idleOption;

        [SerializeField]
        public List<Object> DefaultTargetIgnore;

        [SerializeField]
        public List<Object> DefaultTargets;

        [SerializeField]
        private float _utilityDeltaTolerance = 0;



        // TODO put in sensor??
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
            }
        }

        public void OnValidate()
        {
            if (Source == null)
            {
                Source = GetComponentInParent<Character>();
            }

            if (_options.Length == 0)
            {
                _options = GetComponents<Option>();
            }

            if (_options.Length == 0)
            {
                _options = GetComponentsInChildren<Option>();
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

        public void OnEnvironmentChanged(Option option, BaseObject target, params object[] args)
        {
            OnEnvironmentChangedHandler?.Invoke(option, target, args);
        }

        public Option Decide()
        {
            float maxUtility = float.MinValue;
            Option bestOption = null;
            IEnumerable<BaseObject> bestTargets = null;
            foreach (Option opt in _options)
            {
                if (opt == null)
                    continue;

                if (opt.Assess(
                    out IEnumerable<BaseObject> targets, 
                    out float utility))
                {
                    if (utility > maxUtility)
                    {
                        maxUtility = utility;
                        bestOption = opt;
                        bestTargets = targets;
                    }
                }
            }

            if (bestOption != null)
            {
                Decision = bestOption.CreateDecision(bestTargets, maxUtility);
                return bestOption;
            }
            else
            {
                Decision = _idleOption.CreateDecision(null, 0);
                return _idleOption;
            }
        }



        /// <summary>
        /// Returns whether new decision is made
        /// </summary>
        /// <param name="option"></param>
        /// <param name="target"></param>
        /// <param name="args"></param>
        public bool TryDecide(Option option)
        {
            if (option.Assess(out IEnumerable<BaseObject> targets, out float utility))
            {
                if (utility > Decision.Utility)
                {
                    if (option == Decision.Option)
                    {
                        // No need to update
                        Decision.Utility = utility;
                        return false;
                    }
                    else
                    {
                        // Do update
                        _decision = option.CreateDecision(targets, utility);
                        return true;
                    }
                }
                else
                {
                    // If utility of option went down
                    if (option == Decision.Option)
                    {
                        Decide();
                        return true;
                    }
                    else
                    {
                        // No need to update
                        return false;
                    }
                }
            }
            else
            {                
                // Option vetoed, we need to redecide
                Decide();
                return true; // TO try, result?
            }

        }

        public bool RandomPoint(Vector3 center, float min, float max, out Vector3 result)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 circle = Random.insideUnitCircle * Random.Range(min, max);
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


        public bool ClosestPoint(Vector3 origin, Vector3 destination, float tolerance, out Vector3 result)
        {
            Vector3 between = (destination - origin).normalized * tolerance;

            NavMeshHit hit;

            if (NavMesh.SamplePosition(origin + between, out hit, 2.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }           

            result = Vector3.zero;
            return false;
        }


        public bool PointBetween(Vector3 origin, Vector3 destination, float min, float max, out Vector3 result)
        {
            Vector3 between = (origin - destination).normalized * Random.Range(min, max);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(destination + between, out hit, 2.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        }

        // SAME AS ABOVE
        // TODO move method to Layout/Navmesh helper class
        public bool RandomClosestPoint(Vector3 point, float min, float max, out Vector3 result)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 circle = Random.insideUnitCircle.normalized * Random.Range(min, max);
                Vector3 randomPoint = point + new Vector3(circle.x, 0, circle.y);

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
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
