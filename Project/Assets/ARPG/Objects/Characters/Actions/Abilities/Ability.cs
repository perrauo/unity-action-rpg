using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Utils;
using Cirrus.Editor;
using Cirrus.ARPG.Objects.Items;

namespace Cirrus.ARPG.Objects.Characters.Actions
{
    public delegate void OnCooldowned();

    public delegate void OnUsed(Ability ability);

    public abstract class Ability : MonoBehaviour, IInventoryItem
    {
        // TODO: Change access
        protected abstract Resource Resource { get; }

        [Required]
        [SerializeField]
        private BaseObject _source;

        [Required]
        [SerializeField]
        private AbilityUser _abilityUser;

        private Objects.Actions.Action.Product _action;

        public Sprite Icon {get { return Resource.Icon; } }

        public string Description { get { return Resource.Description; } }

        private DH.Conditions.BaseCondition Condition { get { return Resource.Condition; } }

        public float MaxCooldown { get { return Resource.MaxCooldown; } }

        [HideInInspector]
        public float Cooldown = 0;

        [HideInInspector]
        public bool IsCooldownFinished = true;

        public float StartLag { get { return Resource.StartLag; } }

        public float EndLag { get { return Resource.EndLag; } }

        public float Range { get { return Resource.Action.Range; } }



        public OnCooldowned OnCooldownedHandler;

        public OnUsed OnUsedHandler;

        public void Start()//Resource resource, Actor actor)
        {
            _action = Resource.Action.Create(_source);
            IsCooldownFinished = true;
        }

        public virtual bool IsAvailable
        {
            get
            {
                if (!IsCooldownFinished)
                    return false;

                return !Resource.IsConditional || _source.Verify(Condition);
            }
        }

        public void DoReset()
        {
            Cooldown = MaxCooldown;
            IsCooldownFinished = false;
            Levels.Room.Instance.Clock.OnTickedHandler += OnTick;
        }

        public bool TryUse()
        {
            if (IsAvailable)
            {
                DoUse();
                return true;
            }
            return false;
        }

        private void DoUse()
        {
            _action.Use();
            DoReset();
        }

        public virtual bool TryUseAgainst(BaseObject target)
        {
            if (IsAvailable)
            {
                DoUseAgainst(target);
                return true;
            }

            return false;

        }

        public virtual void DoUseAgainst(BaseObject target)
        {
            _action.UseAgainst(target);
            DoReset();
        }

        private void OnTick()
        {
            if (Cirrus.Utils.Mathf.CloseEnough(Cooldown, 0))
            {
                Cooldown = 0;
                if (OnCooldownedHandler != null)
                {
                    OnCooldownedHandler.Invoke();
                }

                IsCooldownFinished = true;
                Levels.Room.Instance.Clock.OnTickedHandler -= OnTick; //since available unsucribe to clock
            }
            else
            {
                Cooldown -= UnityEngine.Time.deltaTime;
            }
        }

        public void OnValidate()
        {
            if (_source != null)
                return;

             if (transform.parent == null)
                return;

            if (_source == null)
            {
                _source = transform.parent.GetComponentInChildren<Character>();
                _abilityUser = transform.parent.GetComponentInChildren<AbilityUser>();
                if(_source)
                return;
            }

            if (transform.parent.parent == null)
                return;

            if (_source == null)
            {
                _source = transform.parent.parent.GetComponentInChildren<Character>();
                _abilityUser = transform.parent.parent.GetComponentInChildren<AbilityUser>();
                if (_source)
                    return;
            }

            if (transform.parent.parent.parent == null)
                return;

            if (_source == null)
            {
                _source = transform.parent.parent.parent.GetComponentInChildren<Character>();
                _abilityUser = transform.parent.parent.parent.GetComponentInChildren<AbilityUser>();
                if (_source)
                    return;
            }



        }


    }
}
