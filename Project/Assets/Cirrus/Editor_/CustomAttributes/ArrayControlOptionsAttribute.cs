using System;
using System.Collections.Generic;
//using Cirrus.Editor.ThirdParty.UniLinq;
using System.Text;
using UnityEngine;

namespace Cirrus.Editor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ArrayControlOptionsAttribute : Attribute
    {
//        public bool includeArrayChildren { get; protected set; }
        public bool canRemoveItems = true;
        public bool canAddItems = true;

        public ArrayControlOptionsAttribute()
        {
        }
    }
}
