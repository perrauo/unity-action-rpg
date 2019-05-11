//using UnityEngine;
//using System.Collections;

//namespace Cirrus.ARPG.Actions
//{
//    public class GlobalReaction : MonoBehaviour
//    {
//        [SerializeField]
//        private Conditions.BaseCondition _condition;

//        [SerializeField]
//        private BaseEffect _effect;

//        [Editor.Required]
//        [SerializeField]
//        protected Objects.Conditions.SituationListener _situation;

//        public void Start()
//        {
//            _situation.OnSituationUpdatedHandler += OnSituationUpdated;
//        }

//        private void OnSituationUpdated()
//        {
//            if (_situation.IsSatisfied)
//                _effect.TryApply();
//        }
//    }
//}
