using UnityEngine;
using System.Collections;

using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.World.Objects.Characters.Actions;

namespace Cirrus.ARPG.World.Objects.Actions.Strategies
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Closest")]
    public class ClosestStrategy : Resource
    {
        public override Resource.Strategy Create()
        {
            return new Strategy(this);
        }

        public class Strategy : Resource.Strategy
        {
            ClosestStrategy _resource;

            public Strategy(ClosestStrategy resource) : base(resource)
            {
                _resource = resource;
            }
            
            /// <summary>
            /// Returns succesful use
            /// </summary>
            /// <param name="actor"></param>
            /// <param name="action"></param>
            /// <returns></returns>
            // We dont care whihc type of actor
            public override bool Use(BaseObject source)
            {
                // TODO: for now we use closest, other options maybe?
                // TODO min range?
                Collider[] colliders = Physics.OverlapSphere(source.Transform.position, _resource.MaxRange);

                // TODO use priority instead? e.g healer should still be able to heal each other altough not in priority
                float dist = Mathf.Infinity;
                float cmp = -1f;
                BaseObject candidate = null;
                foreach (Collider collider in colliders)
                {
                    var tg = collider.GetComponentInParent<BaseObject>();

                    if (tg == null)
                        continue;

                    if (tg.gameObject == source.gameObject)
                        continue;

                    cmp = Vector3.Distance(tg.Transform.position, tg.Transform.position);
                    if (dist > cmp)
                    {
                        dist = cmp;
                        candidate = tg;
                    }
                }

                if (candidate == null)
                    return false;


                OnTargetHitHandler?.Invoke(candidate);
                return true;

            }

            
        }
    }

}