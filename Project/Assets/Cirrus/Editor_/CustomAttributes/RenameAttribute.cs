// Contributed code by Petris.
// https://github.com/MichalPetryka/LiteNetLib4Mirror
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Cirrus.Extensions;

//namespace Mirror.Ignorance.Editor
//{

namespace Cirrus.Editor
{
    public class LabelOverride : PropertyAttribute
    {
        public string label;
        public LabelOverride(string label)
        {
            this.label = label;
        }

        [CustomPropertyDrawer(typeof(LabelOverride))]
        public class ThisPropertyDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                try
                {
                    var propertyAttribute = this.attribute as LabelOverride;
                    if (IsItBloodyArrayTho(property) == false)
                    {
                        label.text = propertyAttribute.label;

                    }
                    else
                    {
                        Debug.LogWarningFormat(
                            "{0}(\"{1}\") doesn't support arrays ",
                            typeof(LabelOverride).Name,
                            propertyAttribute.label
                        );
                    }
                    EditorGUI.PropertyField(position, property, label);
                }
                catch (System.Exception ex) { Debug.LogException(ex); }
            }

            bool IsItBloodyArrayTho(SerializedProperty property)
            {
                string path = property.propertyPath;
                int idot = path.IndexOf('.');
                if (idot == -1) return false;
                string propName = path.Substring(0, idot);
                // Debug.Log(propName);
                SerializedProperty p = property.serializedObject.FindProperty(propName);
                // Debug.Log(p.isArray);
                return p.isArray;
                //CREDITS: https://answers.unity.com/questions/603882/serializedproperty-isnt-being-detected-as-an-array.html
            }
        }

    }


    public class CollectionRenameAttribute : PropertyAttribute
    {
        public CollectionRenameAttribute(string name)
        {
            NewName = name;
        }

        public string NewName { get; }
    }

    [CustomPropertyDrawer(typeof(CollectionRenameAttribute))]
    public class CollectionRenameEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Editor.RefEditorGUI.DefaultPropertyField(position, property.GetParent(), new GUIContent("Hello"));
            //EditorGUI.
            //EditorGUI.BeginProperty(position,  new GUIContent(((CollectionRenameAttribute)attribute).NewName), property.GetParent());
            //EditorGUI.PropertyField(position, property.GetParent(), new GUIContent("Hello"), true);
            //EditorGUI.PropertyField(position, property.GetParent(), new GUIContent(((CollectionRenameAttribute)attribute).NewName));
            //EditorGUI.PropertyField(position, property, new GUIContent(label.text));
        }

    }

    public class ArrayRenameAttribute : PropertyAttribute
    {
        public ArrayRenameAttribute(string name)
        {
            NewName = name;
        }

        public string NewName { get; }
    }

    public class RenameAttribute : PropertyAttribute
    {
        public RenameAttribute(string name)
        {
            NewName = name;
        }

        public string NewName { get; }
    }

    [CustomPropertyDrawer(typeof(RenameAttribute))]
    public class RenameEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, new GUIContent(((RenameAttribute)attribute).NewName));
        }
    }

    [CustomPropertyDrawer(typeof(ArrayRenameAttribute))]
    public class ArrayRenameEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label.text.EndsWith(" 0") ? new GUIContent(label.text.Replace("Element", ((ArrayRenameAttribute)attribute).NewName) + " (Default)") : new GUIContent(label.text.Replace("Element", ((ArrayRenameAttribute)attribute).NewName)));
        }
    }


    [AttributeUsage(AttributeTargets.Field)]
    public class RenameEnumAttribute : PropertyAttribute
    {

        public string name;

        public RenameEnumAttribute(string name)
        {
            this.name = name;
        }

    }

    [CustomPropertyDrawer(typeof(RenameEnumAttribute))]
    public class RenameEnumDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RenameEnumAttribute rename = (RenameEnumAttribute)attribute;
            label.text = rename.name;

            if (property.propertyType == SerializedPropertyType.Enum)
            {
                drawEnum(position, property, label);
            }
            else
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }


        private void drawEnum(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            Type type = fieldInfo.FieldType;
            string[] names = property.enumNames;
            string[] values = new string[names.Length];


            for (int i = 0; i < names.Length; i++)
            {
                FieldInfo info = type.GetField(names[i]);
                RenameEnumAttribute[] atts = (RenameEnumAttribute[])info.GetCustomAttributes(typeof(RenameEnumAttribute), false);
                values[i] = atts.Length == 0 ? names[i] : atts[0].name;
            }

            int index = EditorGUI.Popup(position, label.text, property.enumValueIndex, values);
            if (EditorGUI.EndChangeCheck() && index != -1) property.enumValueIndex = index;
        }
    }
}
//}
#endif