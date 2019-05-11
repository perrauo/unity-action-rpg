//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////   a situation is something that exists in an ongoing way.
//// an event happens once


//// a set of circumstances in which one finds oneself; a state of affairs.


//// DH: A situation is a group of conditions that pertain to an Object
//// A multi situation includes multiple situation
//// We can therefore use multi situation to dictate conditions over multiple objects


//// Multiple Listeners per object OK



//// The importance of this is that it groups many listeners/conditions



//// TODO: Lists of situations in the levels for dangers
//// Threats : list of hostility situatio


//namespace Cirrus.ARPG.Conditions
//{
//    public delegate void OnSituationUpdated();


//    public class SituationListener : MonoBehaviour
//    {
//        //[SerializeField]
//        //list of condition listeners

//        private int _satisfiedFlags = 0x000000;

//        private int _satisfiedMask = 0x000000;

//        [HideInInspector]
//        public bool IsSatisfied = false;

//        // TODO: Put object here

//        [SerializeField]
//        private List<ConditionListener> _conditionListeners;

//        public OnSituationUpdated OnSituationUpdatedHandler;


//        public void Awake()
//        {
//            int idx = 0x1;
//            foreach (ConditionListener listener in _conditionListeners)
//            {
//                if (listener == null) continue;

//                listener.OnListenedStateChangedHandler += OnListenedStateUpdated;
//                listener.SatisfiedFlag = idx;
//                _satisfiedMask |= listener.SatisfiedFlag;
//                idx <<= 1;
//            }
//        }


//        public void OnListenedStateUpdated(ConditionListener listener)
//        {
//            if (listener.IsSatisfied)
//            {
//                _satisfiedFlags |= listener.SatisfiedFlag;
//            }
//            else
//            {
//                _satisfiedFlags &= ~listener.SatisfiedFlag; 
//            }

//            bool res = ((_satisfiedFlags & _satisfiedMask) == _satisfiedMask);

//            if (IsSatisfied != res)
//            {
//                IsSatisfied = res;
//                OnSituationUpdatedHandler?.Invoke();
//            }
            
//        }


//    }

//}
