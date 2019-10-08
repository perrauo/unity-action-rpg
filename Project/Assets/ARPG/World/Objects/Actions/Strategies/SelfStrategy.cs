using UnityEngine;
using System.Collections;

using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.World.Objects.Characters.Actions;

namespace Cirrus.ARPG.World.Objects.Actions.Strategies
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Self")]
    public class SelfStrategy : Resource
    {
        public override Strategies.Resource.Strategy Create()
        {
            return new Strategy(this);
        }

        public class Strategy : Strategies.Resource.Strategy
        {
            public Strategy(Resource resource) : base(resource) { }

            public override void UseAgainst(BaseObject target)
            {
                OnTargetHitHandler.Invoke(target);
            }

            //public override void UseAgainst(BaseObject source, BaseObject target)
            //{
            //    OnTargetHitHandler.Invoke(target);
            //}

            //public override void UseAgainst(Characters.Character, BaseObject target)
            //{
            //    OnTargetHitHandler.Invoke(target);
            //}

        }
    }
}