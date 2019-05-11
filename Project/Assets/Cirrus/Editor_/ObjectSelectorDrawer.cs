
#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.Editor
{
    //Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
    //Modified by: Sebastian Lague

    [CustomPropertyDrawer(typeof(ObjectSelectorAttribute))]
    public class ObjectSelectorDrawer : PropertyDrawer
    {
        int index = 1;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            if (property == null || property.objectReferenceValue == null)
            {
                Cirrus.Editor.RefEditorGUI.DefaultPropertyField(position, property, label);
                return;
            }


            MonoBehaviour behaviour = property.objectReferenceValue as MonoBehaviour;
            if (behaviour == null)
            {
                Default(position, property, label);
                return;
            }

            List<MonoBehaviour> components = new List<MonoBehaviour>(behaviour.gameObject.GetComponents<MonoBehaviour>());
            if (components.Count == 1)
            {
                Default(position, property, label);
                return;
            }

            index = Mathf.Max(1, components.IndexOf(behaviour) + 1);
            string[] texts = new string[components.Count + 1];
            texts[0] = "None";
            for (int i = 1; i < components.Count + 1; i++)
                texts[i] = i.ToString() + " : " + components[i - 1].ToString();

            index = EditorGUI.Popup(position, property.displayName, index, texts);

            if (index == 0)
            {
                property.objectReferenceValue = null;
                Default(position, property, label);
                return;
            }


            property.objectReferenceValue = components[index - 1];
        }

        public void Default(Rect position, SerializedProperty property, GUIContent label)
        {
            Cirrus.Editor.RefEditorGUI.DefaultPropertyField(position, property, label);
        }

    }

}
#endif