using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Attributes;
using System.Collections.Generic;
using Cirrus.Tags;

namespace Cirrus.ARPG.World.Objects.Characters.Attributes
{
    [System.Serializable]
    public class AttributesPersistence
    {
        [SerializeField]
        public StatResource.StatPersistence Health;

        [SerializeField]
        public StatResource.StatPersistence MaxHealth;

        [SerializeField]
        public StatResource.StatPersistence HealthRegen;

        [SerializeField]
        public StatResource.StatPersistence HealthRegenTime;

        [SerializeField]
        public StatResource.StatPersistence Energy;

        [SerializeField]
        public StatResource.StatPersistence MaxEnergy;

        [SerializeField]
        public StatResource.StatPersistence EnergyRegen;

        [SerializeField]
        public StatResource.StatPersistence EnergyRegenTime;

        [SerializeField]
        public StatResource.StatPersistence Experience;

        [SerializeField]
        public StatResource.StatPersistence Gems;

        private float ConstitutionPositiveErrorFactor = 0.01f; // TODO based on constitution

        private float ConstitutionNegativeErrorFactor = 0.02f; // TODO based on constitution

        private float BaseThresholdPercent = 0.5f;

        public float CriticalHealthThreshold
        {
            get
            {
                // Negative error increases as constitution increases
                // Positive error decreases as constituition increases
                float error = Random.Range(
                    -ConstitutionNegativeErrorFactor * Constitution.Current,
                    ConstitutionPositiveErrorFactor * (Constitution.Total - Constitution.Current));

                // Return threashold;
                return Mathf.Clamp(Health.Total * BaseThresholdPercent + error, 0, Health.Total);
            }
        }

        [SerializeField]
        public StatResource.StatPersistence Constitution;

        [SerializeField]
        public StatResource.StatPersistence Defence;

        [SerializeField]
        public StatResource.StatPersistence Speed;

        [SerializeField]
        public StatResource.StatPersistence Damage;

        [SerializeField]
        public StatResource.StatPersistence Level;

        [SerializeField]
        public StatResource.StatPersistence Luck; // critical hits

        protected Dictionary<int, StatResource.StatPersistence> _dictionary;

        protected StatResource.StatPersistence AddStat(StatResource stat)
        {
            if (stat == null)
                return null;

            Debug.Assert(stat != null, "Please dont leave the '{}' stat empty.".Replace("{}", stat.name));
            var repr = new StatResource.StatPersistence(stat);
            _dictionary.Add(repr.TypeId, repr);

            return repr;
        }

        protected StatResource.StatPersistence AddStat(StatResource stat, StatResource.StatPersistence total)
        {
            if (stat == null)
                return null;

            Debug.Assert(stat != null, "Please dont leave the '{}' stat empty.".Replace("{}", stat.name));
            var repr = new StatResource.StatPersistence(stat, total);
            _dictionary.Add(repr.TypeId, repr);

            return repr;
        }


        // TODO: GetStat(StatType type)
        public StatResource.StatPersistence GetStat(Tag stat)
        {
            if (_dictionary.TryGetValue(stat.GetInstanceID(), out StatResource.StatPersistence st))
                return st;

            return null;
        }


        public AttributesPersistence(AttributesResource resource)
        {
            _dictionary = new Dictionary<int, StatResource.StatPersistence>();

            MaxHealth = AddStat(resource._maxHealth);
            Health = AddStat(resource._health, MaxHealth);

            HealthRegen = AddStat(resource._healthRegen);
            HealthRegenTime = AddStat(resource._healthRegenTime);
                       
            MaxEnergy = AddStat(resource._maxEnergy);
            Energy = AddStat(resource._energy, MaxEnergy);

            EnergyRegen = AddStat(resource._energyRegen);

            EnergyRegenTime = AddStat(resource._energyRegenTime);

            Defence = AddStat(resource._defence);

            Experience = AddStat(resource._experience);

            Constitution = AddStat(resource._constitution);

            Luck = AddStat(resource._luck);

            Gems = AddStat(resource._gems);

            Level = AddStat(resource._level);

            Damage = AddStat(resource._damage);

            Speed = AddStat(resource._speed);
        }
    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Attributes")]
    public class AttributesResource : ScriptableObject
    {
        public AttributesPersistence CreatePersistence()
        {
            return new AttributesPersistence(this);
        }

        //[SerializeField]
        //public StringDetail Nickname;

        [SerializeField]
        public StatResource _health;

        [SerializeField]
        public StatResource _maxHealth;

        [SerializeField]
        public StatResource _healthRegen;

        [SerializeField]
        public StatResource _healthRegenTime;

        [SerializeField]
        public StatResource _energy;

        [SerializeField]
        public StatResource _maxEnergy;

        [SerializeField]
        public StatResource _energyRegen;

        [SerializeField]
        public StatResource _energyRegenTime;

        [SerializeField]
        public StatResource _experience;

        [SerializeField]
        public StatResource _gems;

        [SerializeField]
        public StatResource _constitution;

        [SerializeField]
        public StatResource _defence;


        [SerializeField]
        public StatResource _speed;


        [SerializeField]
        public StatResource _damage;


        [SerializeField]
        public StatResource _level;


        [SerializeField]
        public StatResource _luck;


    }
}
