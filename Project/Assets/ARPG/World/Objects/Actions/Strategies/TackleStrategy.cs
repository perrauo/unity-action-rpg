using UnityEngine;
using System.Collections;

using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.World.Objects.Characters.Actions;

namespace Cirrus.ARPG.World.Objects.Actions.Strategies
{
    // TODO: derive from dash

    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Tackle")]
    public class TackleStrategy : Resource
    {
        [SerializeField]
        public float _timeoutTime = 2f;

        [SerializeField]
        public float _stepSpeed = 10;

        [SerializeField]
        public float _stepSpeedDiscount = 0.5f;

        [SerializeField]
        public float _hitDuration = 2;

        [SerializeField]
        public float _stepDuration = .01f;

        [SerializeField]
        public float _withdrawDelay = 1f;

        [SerializeField]
        public float _withdrawStepDuration = .01f;

        [SerializeField]
        public float _withdrawStepSpeed = 10f;

        [SerializeField]
        public float _withdrawStepDiscount = 0.5f;

        public override Resource.Strategy Create()
        {
            return new Strategy(this);
        }

        public class Strategy : Resource.Strategy
        {
            public TackleStrategy _resource;

            public Strategy(TackleStrategy resource) : base(resource)
            {                
                _resource = resource;
            }

            public override void UseAgainst(Characters.Character source, BaseObject target)
            {                
                source.TackleTarget(this, target);
            }

            // We dont care whihc type of actor
            // TODO: unsubscribe on action finished as well
            public override bool Use(Characters.Character source)
            {
                source.Tackle(this);
                return true;
            }
        }
    }
}

