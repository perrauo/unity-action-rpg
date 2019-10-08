using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Utils;
using Cirrus.Editor;
using Cirrus.ARPG.Items;
using Cirrus.ARPG.UI;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    public delegate void OnSceneSkillEvent(SceneSkill ability);

    public enum AbilityType
    {
        Unknown,
        Item,
        Simple,
        Special,
        Key,
        Equipment
    }


    public class SceneSkill : MonoBehaviour
    {
        public virtual AbilityType Type { get { return AbilityType.Simple; } }

        // TODO: Change access
        [SerializeField]
        protected ActiveSkillResource Resource;// { get; }

        private ActiveSkillPersistence _skill;

        [SerializeField]
        public ItemObject InventoryItemTemplate;

        [Required]
        [SerializeField]
        private Character _source;

        [Required]
        [SerializeField]
        private AbilityUser _abilityUser;

        private Objects.Actions.ActionProduct _action;

        public Vector3 Direction
        {
            get
            {
                return _action.Direction;
            }
        }

        //public float MaxRange
        //{
        //    get
        //    {
        //        _action.MaxRange;
        //    }
        //}


        public Sprite Icon { get { return _skill.Icon; } }

        public string Description { get { return _skill.Description; } }

        //private ARPG.Conditions.ICondition Condition { get { return Resource.Condition; } }

        public float MaxCooldown { get { return _skill.CooldownTime; } }

        public float Cooldown
        {
            get
            {
                return 0;
                //return Resource.CooldownTime - _cooldownTimer.Time;
            }
        }

        // Start-up lag, also known as just start-up and windup, is the delay between 
        // a move being initiated and the move having an effect, such as the length of time before a hitbox 
        public float StartLag { get { return 2; } }//; Resource.StartLag; } }

        // Disable inputs??
        //  is the delay between a move's effect finishing and another action being available to begin
        public float EndLag { get { return 2; } }// Resource.EndLag; } }

        public float MinRange { get { return 2; } }// Resource.Action.MinRange; } }

        public float MaxRange { get { return 2; } } //Resource.Action.MaxRange; } }

        public float SimultaneousCapacity { get { return 1; } }// Resource.SimultaneousCapacity; } }

        private Timer _cooldownTimer;

        private Timer _endLagTimer;

        public OnEvent OnCooldownedHandler;

        public OnEvent OnAbilityFinishedHandler;

        public OnEvent OnEndLagFinishedHandler;

        public OnSceneSkillEvent OnUsedHandler;

        public void Awake()
        {
            _skill = Resource.Create();

            _cooldownTimer = new Timer(_skill.CooldownTime, start:false, repeat:false);
            _cooldownTimer.OnTimeLimitHandler += OnCooldownTimeout;

            //_endLagTimer = new Timer(_skill.EndLag, start: false, repeat: false);
            _endLagTimer.OnTimeLimitHandler += OnEndlagTimeout;
        }

        public void Start()
        {
            //_action = _skill.Action.Create();
            _action.OnActionFinishedHandler += OnActionFinished;
        }

        public virtual bool IsAvailable
        {
            get
            {
                //if (_cooldownTimer.IsActive)
                    return false;

                //return !Resource.IsConditional || _source.Verify(Condition);
            }
        }

        public void OnCooldownTimeout()
        {
            OnCooldownedHandler?.Invoke();
        }

        private void OnActionFinished()
        {
            OnAbilityFinishedHandler?.Invoke();
        }

        public void OnEndlagTimeout()
        {
            OnEndLagFinishedHandler?.Invoke();
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
            _action.UseAgainst(_source, target);
            _cooldownTimer.Start();
            _endLagTimer.Start();
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
            _action.Use(_source);
            _cooldownTimer.Start();
            _endLagTimer.Start();
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
