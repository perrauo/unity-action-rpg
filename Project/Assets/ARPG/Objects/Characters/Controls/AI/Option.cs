
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;
//using System;
using Cirrus.Editor;
using Cirrus.ARPG.Conditions;


//TASK
// Follow
// Observe
// Command (Command to specific target, choice of task based on consideration


namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    // Perform Task once destination is reached
    public partial class Decision
    {
        public Option Option;
        public float Utility;
        public FSM.Id State;
        public BaseObject Target;
        public Vector3 Destination;
        public NavMeshPath Path;
    }


    public abstract class Option : MonoBehaviour
    { 
        [SerializeField]
        protected Agent _agent;

        // TODO: Agent is not omnicient should not be able to see character behind cover
        // etc. 

        // TODO: IsVisionCone : VisionCone Condition, Consideration
         
        [SerializeField]
        private List<Object> _targetIgnore;

        [SerializeField]
        private List<Object> _targets;


        // TODO hide
        [ReadOnly]
        [SerializeField]
        List<BaseObject> _targetsFinal;

        public IEnumerable<BaseObject> Targets
        {
            get {
                return _targetsFinal;
            }
        }

        public bool NoTargets
        {
            get
            {
                return _targetsFinal.Count == 0;
            }
        }
             

        //[EnumFlag]
        //[SerializeField]
        //protected Characters.FSM.Id stateMask;

        [SerializeField]
        public Consideration[] _sourceConsiderations;

        [SerializeField]
        public Consideration[] _targetConsiderations;


        [SerializeField]
        public float _baseUtility = 1f;



        public void Init()
        {
            _targetsFinal = Utils.Flatten(_targets).ToList();
            _targetsFinal.AddRange(Utils.Flatten(_agent.DefaultTargets));

            var removedList = Utils.Flatten(_targetIgnore);
            foreach (var removed in removedList)
            {
                _targetsFinal.Remove(removed);
            }

            removedList = Utils.Flatten(_agent.DefaultTargetIgnore);
            foreach (var removed in removedList)
            {
                _targetsFinal.Remove(removed);
            }


            foreach (var cons in _sourceConsiderations)
            {
                if (cons == null)
                    continue;

                var listener = cons.CreateListener(_agent.Source, _agent.Source);
                listener.OnObjectListenedHandler += OnEnvironmentChanged;
            }

            foreach (var t in _targetsFinal)
            {
                foreach (var cons in _targetConsiderations)
                {
                    if (cons == null)
                        continue;

                    var listener = cons.CreateListener(_agent.Source, t);
                    listener.OnObjectListenedHandler += OnEnvironmentChanged;
                }
            }
        }

        public void OnEnvironmentChanged(BaseObject target, params object[] args)
        {
            _agent.OnEnvironmentChanged(this, target, args);
        }


        public abstract Decision CreateDecision(BaseObject target);


        protected bool AssessSource(ref float utility)
        {
            foreach (var cons in _sourceConsiderations)
            {
                if (cons == null)
                    continue;

                if (!cons.Evaluate(ref utility, _agent.Source, _agent.Source))
                {
                    return false;
                }
            }

            return true;
        }


        protected bool AssessTarget(ref float utility, BaseObject target)
        {
            foreach (var cons in _targetConsiderations)
            {
                if (cons == null)
                    continue;          

                if (!cons.Evaluate(ref utility, _agent.Source, target))
                {
                    return false;
                }
            }

            return true;
        }


        public virtual bool Assess(out float utility, BaseObject target)
        {
            utility = _baseUtility;
            if (AssessSource(ref utility) && AssessTarget(ref utility, target))
            {
                return true;
            }

            return false;
        }


        public virtual bool Assess(out float utility)
        {
            utility = _baseUtility;
            if (AssessSource(ref utility))
            {
                return true;
            }

            return false;;
        }


        public virtual bool Assess(out float utility, out BaseObject target)
        {
            utility = float.MinValue;
            target = null;

            float utilitySource = _baseUtility;
            float utilityTarget = 0;
            if (AssessSource(ref utilitySource))
            {       
                foreach (var t in _targetsFinal)
                {
                    if (t == null)
                        continue;

                    utilityTarget = utilitySource;
                    if (AssessTarget(ref utilityTarget, t) && utilityTarget > utility)
                    {
                        target = t;
                        utility = utilityTarget;
                    }
                }
            }

            return target != null;
        }
    }

}