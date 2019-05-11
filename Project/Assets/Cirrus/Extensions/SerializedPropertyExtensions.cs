
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections;
//using Pseudo.In

namespace Cirrus.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static SerializedProperty GetParent(this SerializedProperty property)
        {
            string path = property.propertyPath;
            if (path.EndsWith("]"))
            {
                for (int i = 0; i < path.Length; i++)
                {
                    if (path[path.Length - 1] != 'A')
                    {
                        path.Pop(path.Length - 1, out path);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            string[] pathSplit = path.Split('.');
            System.Array.Resize(ref pathSplit, pathSplit.Length - 1);
            string parentPath = pathSplit.Concat(".");
            return property.serializedObject.FindProperty(parentPath);
        }
    }

}