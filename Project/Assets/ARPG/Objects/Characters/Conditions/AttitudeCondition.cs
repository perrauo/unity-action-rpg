using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Characters.Controls.AI;

namespace Cirrus.ARPG.Objects.Characters.Conditions.Relations
{
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
            return resource._test.Check(motivation.GetTowards(other), _reference);
        }


        public override bool Verify(Character self, Characters.Character other)
        {
            return Verify(self, other as BaseObject);
        }

        //public override void AttachListener(Objects.Conditions.ConditionListener listener, BaseObject subj)
        //{
        //    throw new System.NotImplementedException();
        //}

    }
}