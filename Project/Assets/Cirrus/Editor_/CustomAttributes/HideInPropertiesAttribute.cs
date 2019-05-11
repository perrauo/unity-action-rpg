using System;
using System.Collections.Generic;
//using Cirrus.Editor.ThirdParty.UniLinq;
using System.Text;
using UnityEngine;

namespace Cirrus.Editor
{
    /// <summary>
    /// When used this field will not be displayed in the properties sidebar of the node editor.
    /// </summary>
    public class HideInPropertiesAttribute : PropertyAttribute
    {

        public HideInPropertiesAttribute()
        {
            
        }
    }
}
