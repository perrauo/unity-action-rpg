using System;
using System.Collections.Generic;
//using Cirrus.Editor.ThirdParty.UniLinq;
using System.Text;
using UnityEngine;

namespace Cirrus.Editor
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HideInCreationWindowAttribute : Attribute
    {
        public HideInCreationWindowAttribute()
        {
        }
    }
}
