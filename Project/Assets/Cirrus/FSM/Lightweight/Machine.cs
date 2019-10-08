using UnityEngine;
using System.Collections;

namespace Cirrus.FSM.Lightweight
{

    // TODO: Copy paste
    public abstract class Machine : MonoBehaviour
    {
        public enum TODOState : int
        {
            TODO1,
            TODO2,
            //..
        }

        private TODOState _stateTO;

        public virtual void Awake() { }

        public virtual void Start() { }

        public virtual void Update() { }
        public virtual void FixedUpdate() { }

        public bool TryChangeState<T>(T state, params object[] args)
        {
            if (VerifyTransition(state))
            {
                return TryFinishChangeState(state, args);
            }

            return false;
        }

        protected virtual bool VerifyTransition<T>(T state, params object[] args)
        {
            switch ((object)state)
            {
                case TODOState.TODO1:
                    break;

                case TODOState.TODO2:
                    break;
            }

            return false;
        }

        // On Change state values
        protected virtual bool TryFinishChangeState<T>(T state, params object[] args)
        {
            switch (_stateTO)
            {
                case TODOState.TODO1:
                    break;

                case TODOState.TODO2:
                    break;
            }

            return false;
        }

    }

}
