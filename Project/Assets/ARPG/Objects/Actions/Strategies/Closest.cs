using UnityEngine;
using System.Collections;

using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Actions.Strategies
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Closest")]
    public class Closest : Resource
    {
        public override Resource.Strategy Create(BaseObject source)
        {
            return new Strategy(this, source);
        }

        public class Strategy : Resource.Strategy
        {
            Closest _resource;

            public Strategy(Closest resource, BaseObject source) : base(resource, source)
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
            public override bool Use()
            {
                // TODO: for now we use closest, other options maybe?
                Collider[] colliders = Physics.OverlapSphere(_source.transform.position, _resource._range);

                // TODO use priority instead? e.g healer should still be able to heal each other altough not in priority
                float dist = Mathf.Infinity;
                float cmp = -1f;
                BaseObject candidate = null;
                foreach (Collider collider in colliders)
                {
                    var tg = collider.GetComponent<BaseObject>();

                    if (tg == null)
                        continue;

                    if (tg.gameObject == _source.gameObject)
                        continue;

                    cmp = Vector3.Distance(tg.transform.position, tg.transform.position);
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