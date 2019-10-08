using UnityEngine;
using UnityEditor;
using System.Collections;



#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer
{


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        Rect newposition = position;
        newposition.y += 18f;
        SerializedProperty data = property.FindPropertyRelative("rows");
        //data.rows[0][]
        for (int j = 0; j < 7; j++)
        {
            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            newposition.height = 18f;
            if (row.arraySize != 7)
                row.arraySize = 7;
            newposition.width = position.width / 7;
            for (int i = 0; i < 7; i++)
            {
                EditorGUI.PropertyField(newposition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newposition.x += newposition.width;
            }

            newposition.x = position.x;
            newposition.y += 18f;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}


#endif



[System.Serializable]
public class ArrayLayout
{

    [System.Serializable]
    public struct rowData
    {
        //public Cirrus.ARPG.Inventory.Ability[] row;
    }

    public rowData[] rows = new rowData[7]; //Grid of 7x7
}
