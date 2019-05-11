
#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

namespace Cirrus.Editor
{

    [CustomPropertyDrawer(typeof(EmphasisAttribute))]
    class ColorLabelAttributePropertyDrawer : PropertyDrawer
    {
        EmphasisAttribute colorSpacer
        {
            get { return ((EmphasisAttribute)attribute); }
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var c0 = Cirrus.Utils.Color.Copy(GUI.color);
            var c1 = Cirrus.Utils.Color.Copy(GUI.backgroundColor);
            var c2 = Utils.Color.Copy(GUI.contentColor);
            GUI.color  = colorSpacer.LabelColor;
            GUI.backgroundColor = colorSpacer.LabelColor;
            GUI.contentColor  = colorSpacer.LabelColor;
            Editor.RefEditorGUI.DefaultPropertyField(position, property, label);
            GUI.color = c0;
            GUI.backgroundColor = c1;
            GUI.contentColor = c2;



        }
    }
}

#endif