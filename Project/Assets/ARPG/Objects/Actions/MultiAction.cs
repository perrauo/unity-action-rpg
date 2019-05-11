using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Multi Action")]
    public class MultiAction : Action
    {
        [SerializeField]
        private List<Action> _actions;

        public override Action.Product Create(BaseObject source)
        {
            return new Product(source, this);
        }

        public class Product : Action.Product
        {
            private List<Action.Product> _actions = new List<Action.Product>();

            public Product(BaseObject source, MultiAction resource) : base(source, resource)//Resource resource, Actor actor)
            {
                foreach (var res in resource._actions)
                {
                    _actions.Add(res.Create(source));
                }
            }

            public override void Use()
            {
                foreach (var a in _actions)
                {
                    a.Use();
                }
            }

            public override void UseAgainst(BaseObject target)
            {
                foreach (var a in _actions)
                {
                    a.UseAgainst(target);
                }
            }
        }
    }
}
