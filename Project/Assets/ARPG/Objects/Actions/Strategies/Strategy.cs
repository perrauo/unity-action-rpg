using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cirrus.ARPG.Objects.Actions.Strategies
{
    public delegate void OnTargetHit(BaseObject target);

    public abstract class Resource : ScriptableObject
    {
        [SerializeField]
        protected float _range = 10f;

        public abstract Strategy Create(BaseObject source);

        public abstract class Strategy
        {
            private Resource _resource;

            protected BaseObject _source;

            public OnTargetHit OnTargetHitHandler;

            public Strategy(Resource resource, BaseObject source)
            {
                _resource = resource;
                _source = source;
            }

            public abstract bool Use();

            public virtual void UseAgainst(BaseObject target)
            {
                OnTargetHitHandler?.Invoke(target);
            }

            // Get targets from Strategy?
            public List<BaseObject> GetFocusTargets()
            {
                // TODO: for now we use closest, other options maybe?
                Collider[] colliders = Physics.OverlapSphere(_source.transform.position, _resource._range);

                List<BaseObject> actionTargets =
                    colliders.Aggregate(new List<BaseObject>(), (x, y) =>
                    {
                        BaseObject a = y.GetComponent<BaseObject>();
                        if (a != null && a != _source) x.Add(a);
                        return x;
                    });

                return actionTargets;
            }

        }
    }
}