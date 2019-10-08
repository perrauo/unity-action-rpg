using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cirrus.ARPG.World.Objects.Actions.Strategies
{
    public delegate void OnTargetHitFromObject(BaseObject source, BaseObject target);

    public delegate void OnTargetHitFromCharacter(Characters.Character source, BaseObject target);

    public abstract class Resource : ScriptableObject
    {
        // Minimal distance at which we can hit the target (not too close)
        public float MinRange = 10f;

        // Maximal distance at which we can hit the target
        public float MaxRange = 10f;

        public abstract Strategy Create();

        public abstract class Strategy
        {
            private Resource _resource;

            public Objects.OnObjectEvent OnTargetHitHandler;

            public OnTargetHitFromObject OnTargetHitFromObjectHandler;

            public OnTargetHitFromCharacter OnTargetHitFromCharacterHandler;


            [SerializeField]
            public Vector3 _direction = Vector3.forward;

            public Vector3 Direction { get { return _direction; } }

            public OnEvent OnStrategyFinishedHandler;

            public Strategy(Resource resource)
            {
                _resource = resource;
            }

            public virtual bool Use()
            {
                return false;
            }

            public virtual bool Use(BaseObject source)
            {
                return Use();
            }

            public virtual bool Use(Characters.Character source)
            {
                return Use(source as BaseObject);
            }

            public virtual void UseAgainst(BaseObject target)
            {
                //OnTargetHitHandler?.Invoke(target);
            }

            public virtual void UseAgainst(BaseObject source, BaseObject target)
            {
                UseAgainst(target);
            }

            public virtual void UseAgainst(Characters.Character source, BaseObject target)
            {
                UseAgainst(source as BaseObject, target);
            }
        }
    }
}