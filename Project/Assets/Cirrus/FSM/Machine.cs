using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Cirrus.FSM
{
    /// <summary>
    /// TODO Handle events do not force everything to appear in the loop
    /// Make it so that some states respond to events
    /// </summary>

    [System.Serializable]
    public class Machine
    {
        //Must be set manually
        [SerializeField]
        private int _contextSize = 5;
        public object[] Context = null;

        public void SetContext(object context, int idx)
        {
            if(Context == null) this.Context = new object[_contextSize];
            Context[idx] = context;
        }

        public void Start()
        {
            _stack = new Stack<State>();
            _dictionary = new Dictionary<int, State>();

            State first = Populate();

            // sets the first in the array as active
            if (first != null)
            {
                SetState(first.Id);
            }
        }

        [SerializeField]
        public State Top
        { get { return _stack == null || _stack.Count==0 ? null : _stack.Peek(); } }


        [SerializeField]
        public Resource[] states;
        private Stack<State> _stack = null;
        private Dictionary<int, State> _dictionary;

        private bool _enabled = true;

        public void Disable()
        {
            _enabled = false;
        }

        public void Enable()
        {
            _enabled = true;
        }


        /// <summary>
        /// populates the dictionary and returns the first state
        /// </summary>
        /// <returns></returns>
        private State Populate()
        {
            _dictionary.Add((int)Cirrus.FSM.DefaultState.Idle, new Idle.State());
            State first = null;
            foreach (Resource res in states)
            {
                if (res != null)
                {
                    if (_dictionary.ContainsKey(res.Id))
                        continue;

                    State state = CreateState(res);
                    _dictionary.Add(res.Id, state);

                    if(first == null)
                        first = state;
                }

            }

            return first;

        }

        public virtual State CreateState(Resource resource)
        {
            return resource.Create(Context);
        }


        public string StateName = "";


        public void DoUpdate()
        {
            if (!_enabled)
                return;

            if (_stack.Count == 0)
                return;

            if (Top != null)
            {
                int pos = Top.ToString().LastIndexOf(".") + 1;
                StateName = Top.ToString().Substring(pos, Top.ToString().Length - pos);

                Top.BeginTick();
                Top.EndTick();
            }
        }

        public void OnDrawGizmos()
        {
            if (!_enabled)
                return;

            if (_stack == null)
                return;

            if (_stack.Count == 0)
                return;

            if (Top != null)
            {
                Top.OnDrawGizmos();
            }
        }

        public void SetState<T>(T state, params object[] args)
        {
            if (Top != null)
            {
                if (Top.Id == -1)
                    return;

                Top.Exit();
                _stack.Clear();
            }


            if (_stack.Count != 0 && _stack.Peek().Id == (int)(object)state)
            {
                _dictionary[(int)(object)state].Reenter(args);
            }
            else
            {
                _stack.Push(_dictionary[(int)(object)state]);
                _dictionary[(int)(object)state].Enter(args);
            }
        }

        public void SetState(int state, params object[] args)
        {
            if (Top != null)
            {
                if (Top.Id == (int)(object)state)
                    return;

                if (Top.Id == -1)
                {
                    return;
                }
            
                Top.Exit();
                _stack.Clear();
            }

            if (_stack.Count != 0 && _stack.Peek().Id == state)
            {
                _dictionary[(int)(object)state].Reenter(args);
            }
            else
            {
                _stack.Push(_dictionary[(int)(object)state]);
                _dictionary[(int)(object)state].Enter(args);
            }
        }

        public void PushState(int state, params object[] args)
        {
            _stack.Push(_dictionary[state]);
            _dictionary[state].Enter(args);
        }

        public void PopState()
        {
            if (Top != null)
            {
                if (Top.Id == -1)
                    return;

                Top.Exit();
                _stack.Pop();
            }
        }

    }

}
