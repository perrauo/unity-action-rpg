using UnityEngine;
using System.Collections;

// TODO : For stack comparison (determien which is the highest)

// STRENGTH VALUE OF THE MODIFICATION
    


namespace Cirrus.ARPG.Objects.Actions.Modifiers
{
    // MODIFICATION OF CERTAIN TYPE SHOULD BE STACKED
    // e.g fire modification of different strength
    public class Stack
    {
        public Modifier.Product Modification;

        public int Size;

    }
    
    public abstract class Modifier : ScriptableObject
    {
        [SerializeField]
        protected Type _type;

        [SerializeField]
        public bool IsStackable = false;

        [SerializeField]
        public Persistence Persistence;

        public void Modify(BaseObject target)
        {
            Product modification = Create(target);
            Persistence.SetPersistence(modification);
        }

        protected abstract Product Create(BaseObject target);

        public abstract class Product
        {
            protected BaseObject _target;

            public virtual void EndPersistence()
            {
            }

            public Product(Modifier resource, BaseObject target)
            {
                _target = target;
                _target.AddModifier(resource._type, this);
            }
        }
    }
}
