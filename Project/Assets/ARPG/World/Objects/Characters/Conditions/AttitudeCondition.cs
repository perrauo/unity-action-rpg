using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters.Controls;

namespace Cirrus.ARPG.World.Objects.Characters.Conditions.Relations
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Conditions/Attitude")]
    public class AttitudeCondition : Objects.Conditions.ObjectCondition
    {
        [SerializeField]
        private AttitudeType _type;

        [SerializeField]
        private Numeric.Comparison _test;

        private AttitudeCondition resource;

        [SerializeField]
        private float _reference;

        public override bool Verify(Character self, BaseObject other)
        {
            AttitudeProduct motivation = self.Agent.GetAttitude(_type);
            Debug.Assert(motivation != null);
            return resource._test.Verify(motivation.GetTowards(other), _reference);
        }

        public override bool Verify(Character self, Characters.Character other)
        {
            return Verify(self, other as BaseObject);
        }

        //public override void AttachListener(World.Objects.Conditions.ConditionListener listener, BaseObject subj)
        //{
        //    throw new System.NotImplementedException();
        //}

    }
}