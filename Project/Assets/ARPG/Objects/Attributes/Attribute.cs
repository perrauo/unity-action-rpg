using UnityEngine;

namespace Cirrus.ARPG.Objects.Attributes
{
    public abstract class Attribute : ScriptableObject
    {

    }

    public abstract class AttributeProduct
    {
        public Attribute attribute;
        
        public AttributeProduct(Attribute attribute)
        {
            this.attribute = attribute;
        }

    }

}


