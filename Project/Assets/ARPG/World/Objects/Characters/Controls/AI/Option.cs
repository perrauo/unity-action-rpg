
using System.Collections.Generic;
using System.Linq;
//using System.Collections.Generic.


using UnityEngine;
using UnityEngine.AI;
//using System;
using Cirrus.Editor;
using Cirrus.ARPG.Conditions;
using Cirrus.FSM;
using System.Collections;


//TASK
// Follow
// Observe
// Command (Command to specific target, choice of task based on consideration


namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public enum Id
    {
        Human,
        Decide,
        Action,
        UseAction,
        Wander,
        Patrol,
        Observe,
        Follow,
        Decision,
        Idle,
        Escape,
        Injured,
        Menu
    }

    // Perform Task once destination is reached
    public partial class Decision
    {
        public Option Option;
        public float Utility;
        //public FSM.Id State;
        public IEnumerable<BaseObject> Targets;
        public BaseObject Target;
        public Vector3 Destination;
        public NavMeshPath Path;
    }


    public abstract class Option : SceneState, IResource, IControllerState, IState
    {
        #region Ctrl

        public virtual  void ToggleMenu()
        {

        }

        public void MenuMove(Vector2Int movement)
        {
            //throw new System.NotImplementedException();
        }

        public void CycleSubmenus(int direction)
        {
            //throw new System.NotImplementedException();
        }


        public virtual Vector2 AxesLeft
        {
            get
            {
                return Vector2.zero;
            }

            set
            {

            }

        }

        public virtual Vector2 AxesRight
        {
            get
            {
                return Vector2.zero;
            }

            set
            {

            }

        }


#endregion

        public override string Name
        {
            get
            {
                return GetType().Name;
            }
        }

        [SerializeField]
        public bool _useDefaultBehaviour = true;

        [ConditionalHide("_useDefaultBehaviour", isVisible = false)]
        [SerializeField]
        public AIBehaviour _aiBehaviour;

        [SerializeField]
        public float ArrivalTolerance = 0.5f;

        [SerializeField]
        public float NavmeshRefreshTime = 2f;

        public bool _isRefreshingEnvironment = false;

        [ConditionalHide("_isRefreshingEnvironment", isVisible = true)]
        [SerializeField]
        public float EnvironmentRefreshTime = 6f;

        protected IEnumerator _calculatePathCoroutine;

        protected bool _isCalculatingPath = false;

        protected Vector3 _sampledPosition = Vector3.zero;

        protected Vector3 _destination = Vector3.positiveInfinity;

        protected float _destinationRange = 2.0f;

        protected Resource _resource;

        private Timer _environmentRefreshTimer;

        [SerializeField]
        protected Controller _controller;

        [SerializeField]
        protected Agent _agent;

        [SerializeField]
        private int _simultaneousTargets = 1;

        [SerializeField]
        private bool _allowNoTargets = false;

        [SerializeField]
        private ListListener _targets;

        public bool NoTargets
        {
            get
            {
                return _targets.Count() == 0;
            }
        }

        public override int Id { get { return GetInstanceID(); } } 

        [SerializeField]
        public AssetConsideration[] _sourceConsiderations;

        [SerializeField]
        public AssetConsideration[] _targetConsiderations;

        [SerializeField]
        public float _baseUtility = 1f;

        public virtual void OnValidate()
        {
            if (_agent == null)
                _agent = GetComponentInParent<Agent>();

            if (_controller == null)
            {
                _controller = GetComponent<Controller>();
            }
        }

        public void OnTargetAdded(BaseObject obj)
        {
            foreach (var cons in _targetConsiderations)
            {
                if (cons == null)
                    continue;

                var listener = cons.CreateListener(_agent.Source, obj);
                listener.OnObjectListenedHandler += OnEnvironmentChanged;
            }
        }

        public void OnTargetRemoved(BaseObject obj)
        {
            // TODO remove listeners
        }

        public void Awake()
        {
            if (_isRefreshingEnvironment)
            {
                _environmentRefreshTimer = new Timer(EnvironmentRefreshTime, start: false);
                _environmentRefreshTimer.OnTimeLimitHandler += OnEnvironmentRefreshedTimeout;
            }

            _targets.Init(_agent.Source);
            _targets.OnAddedHandler += OnTargetAdded;
            _targets.OnRemovedHandler += OnTargetRemoved;

            foreach (var cons in _sourceConsiderations)
            {
                if (cons == null)
                    continue;

                var listener = cons.CreateListener(_agent.Source, _agent.Source);
                listener.OnObjectListenedHandler += OnEnvironmentChanged;
            }

            foreach (var t in _targets)
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


        public Decision CreateDecision(IEnumerable<BaseObject> targets, float utility)
        {
            var decision = new Decision
            {
                Option = this,
                Utility = utility,
                Targets = targets,
            };

            PopulateDecision(targets, ref decision);
            return decision;
        }

        protected abstract void PopulateDecision(IEnumerable<BaseObject> targets, ref Decision decision);


        protected bool AssessSource(out float utility)
        {
            utility = 0;
            foreach (var cons in _sourceConsiderations)
            {
                if (cons == null)
                {
                    continue;
                }

                if (cons.Evaluate(_agent.Source, out float evalUtility))
                {
                    utility += evalUtility;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }


        protected bool AssessTarget(BaseObject target, out float utility)
        {
            utility = 0;
            foreach (var cons in _targetConsiderations)
            {
                if (cons == null)
                    continue;

                if (cons.Evaluate(_agent.Source, target, out float evalUtil))
                {
                    utility += evalUtil;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public virtual bool Assess(out IEnumerable<BaseObject> targets, out float utility)
        {
            var list = new List<BaseObject>();
            targets = list;
            utility = 0;

            if (AssessSource(out float utilitySource))
            {
                float combinedUtility = 0;

                // TODO do not always destory the heap
                Collections.SimpleHeap<BaseObject> heap = new Collections.SimpleHeap<BaseObject>(Collections.HeapType.minHeap);

                foreach (var t in _targets)
                {
                    if (t == null)
                        continue;

                    if (AssessTarget(t, out float utilityTarget))
                    {
                        if (heap.Count >= _simultaneousTargets)
                        {
                            heap.Peek(out BaseObject lowest, out float lowestUtility);
                            if (utilityTarget > lowestUtility)
                            {
                                combinedUtility -= lowestUtility;
                                heap.DeleteBest();

                                combinedUtility += utilityTarget;
                                heap.Insert(t, utilityTarget);
                            }
                        }
                        else
                        {
                            combinedUtility += utilityTarget;
                            heap.Insert(t, utilityTarget);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (heap.IsEmpty() && !_allowNoTargets)
                {
                    return false;
                }

                int count = heap.Count;

                while (!heap.IsEmpty())
                {
                    heap.Peek(out BaseObject b, out float u);
                    // TODO: Simply add object, utility not necessary
                    list.Add(b);// Target(b, u + _baseUtility/count));
                    heap.ExtractBest();
                }

                // base utility + source utility + average target utility
                utility = _baseUtility + utilitySource + (count == 0 ? 0 : (combinedUtility / count));
                return true;
            }
            else
            {
                return false;
            }
        }


        #region FSM

        private AIBehaviour AIBehaviour
        {
            get
            {
                if (_useDefaultBehaviour)
                {
                    return _controller.DefaultBehaviour;
                }

                return _aiBehaviour;
            }
        }

        protected void StopCalculatingPath()
        {
            _isCalculatingPath = false;

            if (_calculatePathCoroutine != null)
                _agent.Source.StopCoroutine(_calculatePathCoroutine);
        }

        protected void StartCalculatingPath()
        {
            if (!_isCalculatingPath)
            {
                _isCalculatingPath = true;

                _calculatePathCoroutine = CalculatePathCoroutine(NavmeshRefreshTime);
                _agent.Source.StartCoroutine(_calculatePathCoroutine);
            }
        }


        public void StartAdaptEnvironment()
        {
            if (_isRefreshingEnvironment)
            {
                _environmentRefreshTimer.Start();
            }

        }

        public void StopAdaptEnvironment()
        {
            if (_isRefreshingEnvironment)
            {
                _environmentRefreshTimer.Start();
            }

        }


        // Override if you do not want to reconsider
        public virtual void Adapt(Option option, BaseObject target, params object[] args)
        {
            if (_agent.TryDecide(option))
            {
                _controller.FSM.TrySetState(option.Id);
            }
        }

        public void OnEnvironmentRefreshedTimeout()
        {
            Adapt();
        }

        public virtual void Adapt()
        {
            Option option = _agent.Decide();

            if (option == null)
                return; 

            _controller.FSM.TrySetState(option.Id);
        }

        public override void Enter(params object[] args)
        {
            base.Enter();

            //Debug.Log("Entered");

            _agent.Source.Axes.Left = Vector2.zero;
            _agent.Source.TargetAxes.Left = Vector2.zero;

            StartAdaptEnvironment();

        }

        public override void Reenter(params object[] args)
        {
            base.Enter();

            _agent.Source.Axes.Left = Vector2.zero;
            _agent.Source.TargetAxes.Left = Vector2.zero;

            StartAdaptEnvironment();
        }

        public override void Exit()
        {
            StopAdaptEnvironment();
        }



        public override void BeginUpdate()
        {

        }

        public override void EndUpdate()
        {
            _agent.Source.Axes.Left = Vector3.Lerp(_agent.Source.Axes.Left, _agent.Source.TargetAxes.Left, _controller.Resource.AxesLeftStep);
            _agent.Source.Axes.Right = Vector3.Lerp(_agent.Source.Axes.Right, _agent.Source.TargetAxes.Right, _controller.Resource.AxesRightStep);
        }

        public virtual Vector3 GetCentroid()
        {
            // Calc point to run away from
            Vector3 centroid = Vector3.zero;
            float offset = 1;
            foreach (var t in _agent.Decision.Targets)
            {
                if (t == null)
                    continue;

                // Closer target have bigger weight
                // TODO: use utility as weight instead. utility should take distance into account anyways
                float weight = offset / _agent.Decision.Targets.Count();
                centroid += weight * t.Transform.position;

                offset += 1;
            }

            return centroid;
        }

        public virtual void UpdateMovement()
        {
            AIBehaviour.UpdateMovement(_controller, _agent, _agent.Source);
        }

        public virtual void UpdateDirection()
        {

        }


        protected virtual IEnumerator CalculatePathCoroutine(float waitTime)
        {
            yield return null;
        }


        public void Jump()
        {
            _agent.Source.Jump();
        }


        public override IState PopulateState(object[] context)
        {
            return this;
        }

        public override void UpdateDrawGizmos()
        {
            //throw new System.NotImplementedException();
        }



        #endregion

    }
}