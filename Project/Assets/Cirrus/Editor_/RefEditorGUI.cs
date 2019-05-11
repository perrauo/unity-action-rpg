#if UNITY_EDITOR

using UnityEngine;
using System.Collections;


namespace Cirrus.Editor
{
    using System.Reflection;
    using UnityEditor;
    using UnityEngine;

    public static class RefEditorGUI
    {
        public delegate bool DefaultPropertyFieldDelegate(Rect position, SerializedProperty property, GUIContent label);
        public static DefaultPropertyFieldDelegate DefaultPropertyField;
        static RefEditorGUI()
        {
            var t = typeof(EditorGUI);
            var delegateType = typeof(DefaultPropertyFieldDelegate);
            var m = t.GetMethod("DefaultPropertyField", BindingFlags.Static | BindingFlags.NonPublic);
            DefaultPropertyField = (DefaultPropertyFieldDelegate)System.Delegate.CreateDelegate(delegateType, m);
        }
    }
}

#endif