using UnityEngine;
using System.Collections;

using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.World.Objects.Characters.Actions;

namespace Cirrus.ARPG.World.Objects.Actions.Strategies
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Target")]
    public class DirectStrategy : Resource
    {
        public override Resource.Strategy Create()
        {
            return new Strategy(this);
        }

        public class Strategy : Resource.Strategy
        {
            private DirectStrategy _resource;

            public Strategy(DirectStrategy resource) : base(resource)
            {
                _resource = resource;
            }

            public override bool Use(BaseObject source)
            {
                OnTargetHitHandler?.Invoke(source);
                return true;
            }

            public override void UseAgainst(BaseObject source, BaseObject target)
            {
                if ((source.Transform.position - target.Transform.position).magnitude >= _resource.MinRange)
                {
                    OnTargetHitHandler?.Invoke(target);
                }
            }
        }
    }
}