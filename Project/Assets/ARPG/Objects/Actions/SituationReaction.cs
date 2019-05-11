using UnityEngine;
using System.Collections;
using Cirrus.Editor;

namespace Cirrus.ARPG.Objects.Actions
{
    public class SituationReaction : MonoBehaviour
    {
        [Editor.Required]
        [SerializeField]
        protected BaseObject _source;

        [SerializeField]
        protected SimpleAction _actionResource;
        protected SimpleAction.Product _action;

        //[Editor.Required]
        //[SerializeField]
        //protected Conditions.SituationListener _situation;

        [Editor.Required]
        [SerializeField]
        protected DH.Conditions.BaseCondition _condition;

        public void Start()
        {
            //_situation.OnSituationUpdatedHandler += OnSituationUpdated;
        }

        private void OnSituationUpdated()
        {
            //if (_situation.IsSatisfied)
            //{
            //    if (_source.Verify(_condition))
            //    {
            //        _action.Use();
            //    }
            //}
        }

    }
}