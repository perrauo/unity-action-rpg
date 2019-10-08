using UnityEngine;
using System.Collections;
using Cirrus.Editor;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.Actions
{
    [System.Serializable]
    public class Description
    {
        [SerializeField]
        private List<Numeric.AssetNumber> _values;

        [Header("Use {0}, {1}, etc. to place asset values.")]
        [SerializeField]
        [TextArea]
        private string _text;

        public string Text
        {
            get
            {
                return string.Format(_text, _values.Select(x => x .Value.ToString()).ToArray());
            }
        }
    }


    public interface IAbility
    {
        Sprite Icon { get; }// { return Resource.Icon; } }

        string Description { get; }// { return Resource.Description; } }

    }

    public interface IActiveAbility : IAbility
    {
        // Cooldown complete
        float Cooldown { get; }

        float CooldownTime { get; }

        float SimultaneousTargetsCapacity { get; }// { return 1; } }// Resource.SimultaneousCapacity; } }

        // Start-up lag, also known as just start-up and windup, is the delay between 
        // a move being initiated and the move having an effect, such as the length of time before a hitbox 
        float StartLag { get; }// { return 2; } }//; Resource.StartLag; } }

        // Disable inputs??
        //  is the delay between a move's effect finishing and another action being available to begin
        float EndLag { get; }//{ return; } }// Resource.EndLag; } }

        float MinRange { get; }//**{ return 2; } }// Resource.Action.MinRange; } }

        float MaxRange { get; }// { return 2; } } //Resource.Action.MaxRange; } }

        OnEvent OnCooldownedHandler { get; set; }

        OnEvent OnAbilityFinishedHandler { get; set; }

        OnEvent OnEndLagFinishedHandler { get; set; }

        bool TryUseAgainst(World.Objects.Characters.Character source, World.Objects.BaseObject target);

        bool TryUse(World.Objects.Characters.Character source);
    }

    [System.Serializable]
    public class AbilityPersistence : IActiveAbility
    {
        [SerializeField]
        private AbilityResource _resource;

        [SerializeField]
        private Timer _cooldownTimer;

        private Timer _endLagTimer;

        //[SerializeField]
        private World.Objects.Actions.ActionProduct _action;

        public Sprite Icon => _resource.Icon;// throw new System.NotImplementedException();

        public string Description => _resource.Description;// throw new System.NotImplementedException();

        public string Name => _resource.Name;

        public float Cooldown => !_cooldownTimer.IsActive ? 0 : 1 - (_cooldownTimer.Time / CooldownTime);

        public float CooldownTime => _resource.CooldownTime;

        public float EndLag => _resource.EndLag;

        public float StartLag => _resource.StartLag;

        public float SimultaneousTargetsCapacity => _resource.SimultaneousTargetsCapacity;

        public float MinRange => _action._resoure.MinRange;

        public float MaxRange => _action._resoure.MaxRange;

        public OnEvent OnCooldownedHandler { get; set; }

        public OnEvent OnAbilityFinishedHandler { get; set; }

        public OnEvent OnEndLagFinishedHandler { get; set; }

        public AbilityPersistence(AbilityResource res)
        {
            _resource = res;

            _cooldownTimer = new Timer(res.CooldownTime, start: false, repeat: false);
            _cooldownTimer.OnTimeLimitHandler += OnCooldownTimeout;

            _endLagTimer = new Timer(res.EndLag, start: false, repeat: false);
            _endLagTimer.OnTimeLimitHandler += OnEndlagTimeout;

            _action = res.Action.Create();
            _action.OnActionFinishedHandler += OnActionFinished;
        }

        public virtual bool IsAvailable(World.Objects.Characters.Character source)
        {
            return !_resource.IsConditional || source.Verify(_resource.Condition);
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

        public virtual bool TryUseAgainst(World.Objects.Characters.Character source, World.Objects.BaseObject target)
        {
            if (IsAvailable(source))
            {
                DoUseAgainst(source, target);
                return true;
            }

            return false;
        }

        public virtual void DoUseAgainst(World.Objects.Characters.Character source, World.Objects.BaseObject target)
        {
            _action.UseAgainst(source, target);
            _cooldownTimer.Start();
            _endLagTimer.Start();
        }

        public bool TryUse(World.Objects.Characters.Character source)
        {
            if (IsAvailable(source))
            {
                DoUse(source);
                return true;
            }

            return false;
        }

        private void DoUse(World.Objects.Characters.Character source)
        {
            _action.Use(source);
            _cooldownTimer.Start();
            _endLagTimer.Start();
        }
    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Ability")]
    public class AbilityResource : ScriptableObject
    {
        [SerializeField]
        public Sprite Icon;

        [SerializeField]
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        [SerializeField]
        public Description _description;

        public string Description
        {
            get
            {
                return _description.Text;
            }
        }


        [SerializeField]
        public World.Objects.Actions.AssetAction Action;

        [SerializeField]
        public bool IsConditional = false;

        [ConditionalHide("IsConditional", isVisible = true)]
        [SerializeField]
        public ARPG.Conditions.AssetCondition Condition;

        [SerializeField]
        public float CooldownTime = 5;

        //  Refers to the period of time between an action being inputted and the action having an effect.
        [SerializeField]
        public float StartLag = 2;

        // Refers to the period of time between an action's effect finishing and the player being able to input another action
        [SerializeField]
        public float EndLag = 2;


        [SerializeField]
        public float SimultaneousTargetsCapacity = 1;


        public void OnValidate()
        {
            if (_name != null && _name.Equals(""))
            {
                _name = name;
            }
        }

        public virtual AbilityPersistence Create()
        {
            return new AbilityPersistence(this);
        }

    }
}