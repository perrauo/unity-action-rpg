using UnityEngine;
using System.Collections;
using Cirrus.Editor;
using Cirrus.ARPG.Items;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    public class ActiveSkillPersistence : SkillPersistence, IActiveAbility
    {
        public ActiveSkillResource _resource;

        public AbilityPersistence _ability;

        public ActiveSkillPersistence(ActiveSkillResource res)
        {
            _resource = res;

            _ability = res._ability.Create();
        }

        public override Sprite Icon => _ability.Icon;

        public override string Description => _ability.Description;

        public override string Name => _ability.Name;

        public float CooldownTime => _ability.CooldownTime;

        public float SimultaneousTargetsCapacity => _ability.SimultaneousTargetsCapacity;

        public float StartLag => _ability.StartLag;

        public float EndLag => _ability.EndLag;

        public float MinRange => _ability.MinRange;

        public float MaxRange => _ability.MaxRange;

        public float Cooldown => _ability.Cooldown;

        public OnEvent OnCooldownedHandler { get => _ability.OnCooldownedHandler; set => _ability.OnCooldownedHandler = value; }
        public OnEvent OnAbilityFinishedHandler { get => _ability.OnAbilityFinishedHandler; set => _ability.OnAbilityFinishedHandler = value; }
        public OnEvent OnEndLagFinishedHandler { get => _ability.OnEndLagFinishedHandler; set => _ability.OnEndLagFinishedHandler = value; }

        public bool TryUse(Character source)
        {
            return _ability.TryUse(source);
        }

        public bool TryUseAgainst(Character source, BaseObject target)
        {
            return _ability.TryUseAgainst(source, target);
        }
    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Actions/Active Skill")]
    public class ActiveSkillResource : AssetSkill// ScriptableObject
    {
        [SerializeField]
        public AbilityResource _ability;

        public ActiveSkillPersistence Create()
        {
            return new ActiveSkillPersistence(this);
        }


    }
}
