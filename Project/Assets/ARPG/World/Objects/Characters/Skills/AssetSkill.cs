using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Items;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    public abstract class SkillPersistence : IAbility
    {
        private IAbility _ability;

        public abstract Sprite Icon { get; }

        public abstract string Description { get; }

        public abstract string Name { get; }

        //public SkillPersistence().IAbility ability)
        //{
        //    _abilirt = ability;
        //}
    }


    public abstract class AssetSkill : ScriptableObject
    {
        [SerializeField]
        public bool _locked = false;

        [SerializeField]
        public bool _visible = false;

        //TODO
        public ARPG.Conditions.AssetCondition _unlockConditions;

        // TODO
        public ARPG.Conditions.AssetCondition _visibleConditions;
    }
}