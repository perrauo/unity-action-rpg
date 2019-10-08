using Cirrus.ARPG.Actions;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.ARPG.World.Objects.Characters.Controls;
using System.Collections.Generic;
using UnityEngine;
using Cirrus.Tags;
using Cirrus.ARPG.Conditions;
using Cirrus.ARPG.World.Objects.Actions;

namespace Cirrus.ARPG.World.Objects
{
    public delegate void OnObjectEvent(BaseObject obj);

    public delegate void OnActionHandled(Actions.ActionProduct action);

    public abstract class BaseObject : MonoBehaviour
    {
        [SerializeField]
        public Room _room;

        // TODO
        [SerializeField]
        protected bool _isPersistent = false;

        public abstract Persistence Persistence { get; }

        public string Name {
            get {
                return transform.name;
            }
        }

        [SerializeField]
        private Transform _transform;

        public Transform Transform
        {
            get
            {
                return _transform;
            }
        }
        
        [SerializeField]
        private List<AssetList> _lists;

        [SerializeField]
        private List<Characters.Progression.Reward> _rewards;

        [SerializeField]
        public ObjectPhysic Physic;

        [SerializeField]
        public UI.UIUser ObjectUI;

        [HideInInspector]
        public Vector3 StartPosition;

        public abstract Characters.Attributes.AttributesPersistence Attributes { get; }

        private Dictionary<int, Actions.Modifiers.Modifier.Product> _modifications = null;

        public OnActionHandled OnActionHandledEvent;

        public Objects.Attributes.OnStatEvent OnStatUpdatedHandler;

        public OnObjectEvent OnObjectCollidedHandler;

        [SerializeField]
        private UnityEngine.AI.NavMeshModifierVolume _navMeshModifierVolume;
        public UnityEngine.AI.NavMeshModifierVolume NavMeshModifierVolume { get { return _navMeshModifierVolume; } }

        public virtual void OnValidate()
        {
            if (Physic == null)            
                Physic = GetComponent<ObjectPhysic>();            

            if (_room == null)
                _room = FindObjectOfType<Room>();
        }

        protected abstract void PopulatePersistence();

        public virtual void Awake()
        {
            foreach (AssetList list in _lists)
            {
                if (list != null)
                    list.Add(this);
            }
        }

        public virtual void Start()
        {
            StartPosition = Transform.position;

            if (_isPersistent && _room.IsRegistering)
            {
                PopulatePersistence();
                _room.Register(this);              
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


        public virtual bool Verify(ICondition condition)
        {
            return condition.Verify(this);
        }

        public virtual bool DispatchVerify(BaseObject target, ICondition condition)
        {
            return target.Verify(this, condition);
        }


        public virtual bool Verify(Characters.Character source, ICondition condition)
        {
            return condition.Verify(source, this);
        }

        public virtual bool Verify(BaseObject source, ICondition condition)
        {
            return condition.Verify(source, this);        
        }

        #endregion



        #region Effects

        public virtual void AddModifier(Actions.Modifiers.Type type, Actions.Modifiers.Modifier.Product modification)
        {
            if (_modifications == null)
                _modifications = new Dictionary<int, Actions.Modifiers.Modifier.Product>();

            _modifications.Add(type.GetInstanceID(), modification);
        }


        public virtual bool DispatchTryApply(ActionProduct action, IEffect effect, BaseObject target)
        {
            return target.TryApply(this, action, effect);
        }
        
        public virtual bool TryApply(ActionProduct action, IEffect effect)
        {
            return effect.TryApply(action, this);
        }

        public virtual bool TryApply(BaseObject source, ActionProduct action, IEffect effect)
        {
            return effect.TryApply(source, action, this);
        }

        public virtual bool TryApply(Characters.Character source, ActionProduct action, IEffect effect)
        {
            return effect.TryApply(source, action, this);   
        }


        public void NotifyActionHandled(ActionProduct action)
        {
            OnActionHandledEvent?.Invoke(action);
        }

        #endregion


        // TODO: remove cap by player speed for push (suppor
        public virtual void OnObjectCollision(BaseObject other)
        {
            // calculate force vector
            var force = Transform.position - other.Transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();

            Physic.MoveVelocity += force * other.Physic.PushCoefficient * other.Physic.Mass;

            //Debug.Log("Player collision");

            OnObjectCollidedHandler?.Invoke(other);
        }

        //internal abstract void Create();
    }
}
