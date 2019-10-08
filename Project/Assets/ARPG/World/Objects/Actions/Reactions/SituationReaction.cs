using UnityEngine;
using System.Collections;
using Cirrus.Editor;

namespace Cirrus.ARPG.World.Objects.Actions
{
    public class SituationReaction : MonoBehaviour
    {
        [Editor.Required]
        [SerializeField]
        protected BaseObject _source;

        [SerializeField]
        protected SimpleAssetAction _actionResource;
        protected SimpleActionProduct _action;

        //[Editor.Required]
        //[SerializeField]
        //protected Conditions.SituationListener _situation;

        [Required]
        [SerializeField]
        protected ARPG.Conditions.ICondition _condition;

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