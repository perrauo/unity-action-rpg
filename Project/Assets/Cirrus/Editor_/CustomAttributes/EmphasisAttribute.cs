using UnityEngine;

namespace Cirrus.Editor
{

    /// <summary>
    /// Display multi-select popup for Flags enum correctly.
    /// </summary>
    public class EmphasisAttribute : PropertyAttribute
    {
        public Color LabelColor { get; set; }

        //public 
        public EmphasisAttribute()
        {
            LabelColor = new Color(255, 255, 0, 1);
        }


    }
}