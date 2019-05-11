using System;
using System.Collections.Generic;
//using Cirrus.Editor.ThirdParty.UniLinq;
using System.Text;
using UnityEngine;

namespace Cirrus.Editor
{
    public class OnlyDerivedTypesAttribute : PropertyAttribute
    {
        public Type type { get; protected set; }

        public OnlyDerivedTypesAttribute()
        {
            
        }

        public OnlyDerivedTypesAttribute(Type type)
        {
            this.type = type;
        }

    }
}
