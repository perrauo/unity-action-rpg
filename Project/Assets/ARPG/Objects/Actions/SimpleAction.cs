using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Action")]
    public class SimpleAction : Action
    {
        [SerializeField]
        private DH.Actions.BaseEffect _effect;

        [Required]
        [SerializeField]
        private Strategies.Resource _strategy;

        public override Action.Product Create(BaseObject source)
        {
            return new Product(this, source);
        }

        public class Product : Action.Product
        {
            protected Strategies.Resource.Strategy _strategy;

            public BaseObject Source;

            protected SimpleAction _resource;

            public Product(SimpleAction resource, BaseObject source) : base(source, resource)//Resource resource, Actor actor)
            {
                _resource = resource;
                Source = source;
                _strategy = _resource._strategy.Create(source);
                _strategy.OnTargetHitHandler += OnTargetHit;
            }

            public override void Use()
            {
                _strategy.Use();
            }

            public override void UseAgainst(BaseObject target)
            {
                _strategy.UseAgainst(target);
            }

            public void OnTargetHit(BaseObject target)
            {
                target.TryApply(Source, _resource._effect);
                target.NotifyActionHandled(this);
                
            }
        }
    }
}
