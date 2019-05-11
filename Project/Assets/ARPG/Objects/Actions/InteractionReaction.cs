using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Actions
{
    public abstract class InteractionReaction : MonoBehaviour
    {

        [SerializeField]
        protected BaseObject _source;

        [SerializeField]
        protected List<Tag> _tags;

        [SerializeField]
        [Editor.Required]
        [Editor.Rename("Actions")]
        public Action _actionResource;

        public Action.Product _action;

        // Opposite does not necessarily mean directed toward self. (Only strategy used does)
        //[Header("Is the reaction directed toward the stimulus?")]
        //[SerializeField]
        //protected bool _isToStimulus;

        [System.Serializable]
        public enum Check
        {
            Situation = 1 << 0,
            Condition = 1 << 1
        }

        [SerializeField]
        [Editor.EnumFlag]
        private Check _checks;

        //[SerializeField]
        //[Editor.ConditionalHide("_checks", enumValue = (int) Check.Situation, isEnumFlags = true, isVisible = true)]
        //protected Conditions.SituationListener _situation;

        [SerializeField]
        [Editor.ConditionalHide("_checks", enumValue = (int)Check.Condition, isEnumFlags = true, isVisible = true)]
        protected DH.Conditions.BaseCondition _condition;


        public virtual void Start()
        {
            _action = _actionResource.Create(_source);
        }

        protected bool IsPreconditionSatisfied
        {
            get
            {
                //if (_situation == null) return true;
                //return _situation.IsSatisfied;
                return true;
            }
        }

        public virtual void OnInteraction(BaseObject other)
        {
            TryReactAgainst(other);
        }

        private bool TryReactAgainst(BaseObject target)
        {
            if (_source.Verify(_condition))
            {
                _action.UseAgainst(target);
                return true;
            }

            return false;
        }
    }
}