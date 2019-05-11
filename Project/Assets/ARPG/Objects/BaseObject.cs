using Cirrus.ARPG.Actions;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.ARPG.Objects.Characters.Controls.AI;
using System.Collections.Generic;
using UnityEngine;
using Cirrus.Tags;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.Objects
{
    public delegate void OnActionHandled(Actions.SimpleAction.Product action);

    public abstract class BaseObject : MonoBehaviour
    {
        public string Name {
            get {
                if (transform.parent == null)
                    return "<Unknown>";
                else return transform.parent.name;
            }
        }

        [SerializeField]
        private List<Tag> _tags;

        public IEnumerable<Tag> Tags
        {
            get
            {
                return _tags;
            }
        }


        [SerializeField]
        private List<Object> _lists;

        [SerializeField]
        private List<Characters.Progression.Reward> _rewards;

        [HideInInspector]
        public Vector3 StartPosition;

        public abstract Attributes.AttributesPersistence Attributes { get; }

        private Dictionary<int, Actions.Modifiers.Modifier.Product> _modifications = null;

        public OnActionHandled OnActionHandledEvent;

        protected virtual void Awake()
        {
            StartPosition = transform.position;
            foreach (IList<BaseObject> list in _lists)
            {
                if (list != null)
                    list.Add(this);
            }
        }

        #region Conditions


        public List<Conditions.ObjectListener> _listeners = new List<Conditions.ObjectListener>();


        public void AddListener(Conditions.ObjectListener listener)
        {
            _listeners.Add(listener);
        }


        public void RemoveListener(Conditions.ObjectListener listener)
        {
            _listeners.Remove(listener);
        }


        public virtual bool Verify(BaseCondition condition)
        {
            return condition.Verify(this);
        }

        public virtual bool Verify(BaseObject source, BaseCondition condition)
        {
            // TODO more obj
            if (source is Character)
            {
                return condition.Verify((BaseObject)(source as Character), this);
            }
            else
            {
                return condition.Verify(source, this);
            }
        }

        #endregion




        #region Effects

        public virtual void AddModifier(Actions.Modifiers.Type type, Actions.Modifiers.Modifier.Product modification)
        {
            if (_modifications == null)
                _modifications = new Dictionary<int, Actions.Modifiers.Modifier.Product>();

            _modifications.Add(type.GetInstanceID(), modification);
        }

        public virtual bool TryApply(BaseObject source, BaseEffect effect)
        {
            if (source is Character)
            {
                return effect.TryApply(source as Character, this);
            }
            else
            {
                return effect.TryApply(source, this);
            }
        }



        public void NotifyActionHandled(Actions.SimpleAction.Product action)
        {
            OnActionHandledEvent?.Invoke(action);
        }

        #endregion

    }
}
