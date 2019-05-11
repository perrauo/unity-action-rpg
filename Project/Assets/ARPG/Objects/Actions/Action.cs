using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Actions
{
    public abstract class Action : ScriptableObject
    {
        public abstract Product Create(BaseObject source);

        [SerializeField]
        public List<Tag> _tags;

        [SerializeField]
        public float Range = 10f;


        public abstract class Product
        {
            public BaseObject Source;

            public Action _resoure;

            public IEnumerable<Tag> Tags
            {
                get
                {
                    return _resoure._tags;
                }
            }

            public Product(BaseObject source, Action act)//Resource resource, Actor actor)
            {
                _resoure = act;
                Source = source;
            }

            public abstract void Use();

            public abstract void UseAgainst(BaseObject target);
        }
    }
}
