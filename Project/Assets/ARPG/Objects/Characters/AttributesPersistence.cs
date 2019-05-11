using UnityEngine;
using System.Collections;

using Cirrus.ARPG.Objects.Attributes;
using System.Collections.Generic;



namespace Cirrus.ARPG.Objects.Characters.Attributes
{
    public class AttributesPersistence : Objects.Attributes.AttributesPersistence
    {
        [SerializeField]
        public StringDetail Nickname;

        [SerializeField]
        private Stat _health;
        public Stat.Product Health;

        [SerializeField]
        private Stat _energy;
        public Stat.Product Energy;

        [SerializeField]
        private Stat _experience;
        public Stat.Product Experience;

        [SerializeField]
        private Stat _gems;
        public Stat.Product Gems;

        private const float ConstitutionReference = 100f;

        private float MinConstitutionThreashold = 5;

        private float ConstitutionError = 2; // TODO based on constitution

        public float CriticalHealthThreshold
        {
            get
            {
                float error = Random.Range(-ConstitutionError, ConstitutionError);
                float res = ConstitutionReference - Constitution.Total + error;
                if (res < MinConstitutionThreashold)
                {
                    res = MinConstitutionThreashold;
                }
            
                float criticalHealth = (res / ConstitutionReference) * Health.Total;
                return criticalHealth;
            }
        }

        [SerializeField]
        private Stat _constitution;
        public Stat.Product Constitution;


        [SerializeField]
        private Stat _defence;
        public Stat.Product Defence;

        [SerializeField]
        private Stat _speed;
        public Stat.Product Speed;


        [SerializeField]
        private Stat _damage;
        public Stat.Product Damage;

        [SerializeField]
        private Stat _regen;
        public Stat.Product Regen;

        [SerializeField]
        private Stat _regenFreq;
        public Stat.Product RegenFreq;

        [SerializeField]
        private Stat _level;
        public Stat.Product Level;


        [SerializeField]
        private Stat _luck;
        public Stat.Product Luck; // critical hits

        //[SerializeField]
        //private Stat _kills;
        //public Stat.Product Kills;


        public override void Awake()
        {
            base.Awake();
            Health =  AddStat(_health);
            Energy = AddStat(_energy);
            Defence = AddStat(_defence);
            Experience = AddStat(_experience);
            Constitution = AddStat(_constitution);
            Gems = AddStat(_gems);
        }



    }
}
