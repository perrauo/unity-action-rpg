using UnityEngine;
using System.Collections;

using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Actions.Strategies
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Self")]
    public class Self : Resource
    {
        public override Strategies.Resource.Strategy Create(BaseObject source)
        {
            return new Strategy(this, source);
        }

        public class Strategy : Strategies.Resource.Strategy
        {
            public Strategy(Resource resource, BaseObject source) : base(resource, source) { }

            public override bool Use()
            {
                OnTargetHitHandler.Invoke(_source);
                return true;
            }

            public override void UseAgainst(BaseObject target)
            {
                OnTargetHitHandler?.Invoke(_source);//
            }
        }
    }
}