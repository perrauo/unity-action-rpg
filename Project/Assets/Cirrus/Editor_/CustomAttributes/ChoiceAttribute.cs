using UnityEngine;
//using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using UnityEditor;
using System.Linq;

namespace Cirrus.Editor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ChoiceAttribute : PropertyAttribute
    {
        public string[] others;

        public ChoiceAttribute(string[] otherVariableName)
        {
            others = otherVariableName;
        }

    }


#if UNITY_EDITOR

    //Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
    //Modified by: Sebastian Lague


    [CustomPropertyDrawer(typeof(ChoiceAttribute))]
    public class ChoicePropertyDrawer : PropertyDrawer
    {

        public void Default(Rect position, SerializedProperty property, GUIContent label)
        {
            Cirrus.Editor.RefEditorGUI.DefaultPropertyField(position, property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ChoiceAttribute condHAtt = (ChoiceAttribute)attribute;

            var sourcePropertyValue = condHAtt.others.Select(x => property.serializedObject.FindProperty(x));

            foreach (var v in sourcePropertyValue)
            {
                if (v.objectReferenceValue == property.objectReferenceValue)
                {
                    continue;
                }
                else if (v.objectReferenceValue != null)
                {
                    return;
                }
            }

            Default(position, property, label);

        }
    }
#endif

}





