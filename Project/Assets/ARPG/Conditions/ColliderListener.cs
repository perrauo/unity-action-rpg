//using UnityEngine;
//using System.Collections;

//namespace Cirrus.ARPG.Conditions
//{


//    public class DistanceListener : BaseListener
//    {
//        private ISource _source;

//        [HideInInspector]
//        public bool IsSatisfied = false;

//        public OnListenedStateUpdated OnListenedStateChangedHandler; // Hook this up, per condition

//        [HideInInspector]
//        public int SatisfiedFlag = 0x000;


//        public Listener(DH.Conditions.BaseCondition condition)
//        {
//            _condition = condition;
//            _source.AddConditionListener(this);
//            _source.AddConditionListener(this);
//            OnConditionStateUpdated();
//        }

//        public void Attach(ISource source)
//        {
//            _source = source;
//            _condition.AttachListener(this, source);
//        }

//        public void Attach(BaseObject source)
//        {
//            _source = source;
//            _condition.AttachListener(this, source);
//        }

//        public void Attach(Objects.Characters.Character source)
//        {
//            _source = source;
//            _condition.AttachListener(this, source);
//        }

//        public void OnConditionStateUpdated()
//        {
//            bool prev = IsSatisfied;
//            IsSatisfied = _source.HandleCondition(_condition);
//            if (prev != IsSatisfied)
//            {
//                OnListenedStateChangedHandler?.Invoke(this);
//            }
//        }

//    }

//}