//using UnityEngine;
//using System.Collections;

//namespace Cirrus.Circuit
//{
//    [System.Serializable]
//    public class FSM : MonoBehaviour
//    {
//        [System.Serializable]
//        public enum State
//        {
//            LevelSelection,
//            Round,
//            Score,
//        }

//        [SerializeField]
//        private State _state = State.LevelSelection;

//        public void Awake()
//        {
//            TryChangeState(State.LevelSelection);
//        }

//        public void FixedUpdate()
//        {
//            switch (_state)
//            {
//                case State.LevelSelection:
//                case State.Round:
//                case State.Score:

//                    break;
//            }


//        }

//        public void Update()
//        {
//            switch (_state)
//            {
//                case State.LevelSelection:
//                case State.Round:
//                case State.Score:
//                    break;
//            }
//        }

//        public bool TryChangeState(State transition, params object[] args)
//        {
//            if (TryTransition(transition, out State destination))
//            {
//                return TryFinishChangeState(destination, args);
//            }

//            return false;
//        }

//        protected bool TryTransition(State transition, out State destination, params object[] args)
//        {
//            switch (_state)
//            {
//                case State.Round:

//                    switch (transition)
//                    {
//                        case State.LevelSelection:
//                        case State.Score:
//                            destination = transition;
//                            return true;
//                    }
//                    break;

//                case State.LevelSelection:
//                    switch (transition)
//                    {
//                        case State.LevelSelection:
//                        case State.Score:
//                            destination = transition;
//                            return true;
//                    }
//                    break;

//                case State.Score:
//                    switch (transition)
//                    {
//                        case State.LevelSelection:
//                        case State.Round:
//                            destination = transition;
//                            return true;
//                    }
//                    break;
//            }

//            destination = State.Round;
//            return false;
//        }

//        protected bool TryFinishChangeState(State target, params object[] args)
//        {

//            switch (target)
//            {
//                case State.LevelSelection:
//                    return true;

//                case State.Round:
//                    return true;

//                case State.Score:

//                    return true;
//                default:
//                    return false;
//            }

//        }

//    }
//}