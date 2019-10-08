using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Cirrus.FSM
{
    /// <summary>
    /// TODO Handle events do not force everything to appear in the loop
    /// Make it so that some states respond to events
    /// </summary>

    [System.Serializable]
    public class Machine : MonoBehaviour
    {
        [SerializeField]
        private GameObject _stateLabel;

        [SerializeField]
        [Editor.ObjectSelector]
        public MonoBehaviour[] Context;

        Mutex _mutex;


        private IState _first;

        public void OnValidate()
        {
            if (_sceneStates.Length == 0)
            {
                _sceneStates = GetComponents<SceneState>();
            }

            //if (_sceneStates.Length == 0)
            //{
            //    _sceneStates = GetComponentsInChildren<SceneState>();
            //}
        }

        public void Awake()
        {
            _dictionary = new Dictionary<int, IState>();
            _mutex = new Mutex();
            _stack = new Stack<IState>();

            //_dictionary.Add((int)DefaultState.Idle, new Idle.State());
            _first = null;
            foreach (AssetState res in _assetStates)
            {
                if (res != null)
                {
                    if (_dictionary.ContainsKey(res.Id))
                        continue;

                    IState state = CreateState(res);
                    _dictionary.Add(res.Id, state);

                    if (_first == null && res.IsStart)
                        _first = state;
                }

            }

            foreach (SceneState res in _sceneStates)
            {
                if (res != null)
                {
                    if (_dictionary.ContainsKey(res.Id))
                        continue;

                    IState state = CreateState(res);
                    _dictionary.Add(res.Id, state);

                    if (_first == null && res.IsStart)
                        _first = state;
                }

            }

            if (_first == null)
            {
                if (_dictionary.Count != 0)
                    _first = _dictionary.Values.First();
            }
        }

        public void Start()
        {
            TryPushState(_first.Id);
        }


        public Stack<IState> _stack;

        [SerializeField]
        public IState Top
        {
            get
            {
                return _stack == null ?
                    null :
                    _stack.Count == 0 ? null : _stack.Peek();
            }
        }

        [SerializeField]
        public AssetState[] _assetStates;

        [SerializeField]
        public SceneState[] _sceneStates;

        private Dictionary<int, IState> _dictionary;

        private bool _enabled = true;

        public void Disable()
        {
            _enabled = false;
        }

        public void Enable()
        {
            _enabled = true;
        }

        public virtual IState CreateState(IResource resource)
        {
            return resource.PopulateState(Context);
        }


        public string StateName = "";


        public void Update()
        {
            if (_stateLabel != null)
            {
                _stateLabel.name = Top == null ? "?" : Top.Name;
            }

            if (!_enabled)
                return;

            if (Top != null)
            {
                Top.BeginUpdate();
                Top.EndUpdate();
            }
        }

        public void FixedUpdate()
        {
            if (!_enabled)
                return;

            if (Top != null)
            {
                Top.BeginUpdate();
                Top.EndUpdate();
            }
        }


        public void OnDrawGizmos()
        {
            if (!_enabled)
                return;



            if (Top != null)
            {
                Top.UpdateDrawGizmos();
            }
        }


        public void DrawGizmosIcon(Vector3 pos)
        {
            if (Top != null)
            {
                //Gizmos.DrawIcon(pos, Top.ToString(), true);
                //Handles.Label(pos, Top.ToString());
                //Utils.TextGizmo.Draw(pos, Top.ToString());

            }
        }

        public bool TrySetState<T>(T state, params object[] args)
        {
            return TrySetState((int)(object)state, args);
        }

        public bool TryPushState<T>(T state, params object[] args)
        {
            return TryPushState((int)(object)state, args);
        }

        public bool TryPushState(int state, params object[] args)
        {
            if (_dictionary.TryGetValue(state, out IState res))
            {
                IState current = Top;

                if (current != null)
                    current.Exit();

                if (current != null && current.Id == res.Id)
                {
                    res.Reenter(args);
                }
                else
                {
                    _mutex.WaitOne();

                    _stack.Push(res);

                    _mutex.ReleaseMutex();

                    res.Enter(args);
                }

                return true;
            }

            return false;
        }

        public bool TryPopState(params object[] args)
        {
            if (_stack.Count > 1)
            {
                Top.Exit();
                IState prev = Top;

                _mutex.WaitOne();
                _stack.Pop();
                _mutex.ReleaseMutex();

                if (prev.Id == Top.Id)
                {
                    Top.Reenter(args);
                }
                else
                {
                    Top.Enter(args);
                }

                return true;
            }

            return false;
        }

        public bool TrySetState(int state, params object[] args)
        {
            if(_dictionary.TryGetValue(state, out IState res))
            {
                IState current = Top; 

                if(current != null)
                    current.Exit();

                if (current != null && current.Id == res.Id)
                {
                    res.Reenter(args);
                }
                else
                {
                    _mutex.WaitOne();

                    _stack.Clear();

                    _stack.Push(res);

                    _mutex.ReleaseMutex();

                    res.Enter(args);
                }

                return true;
            }

            return false;
        }
    }

}
