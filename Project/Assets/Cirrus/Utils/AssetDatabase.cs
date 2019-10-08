using UnityEngine;
using System.Collections;

namespace Cirrus.Utils
{

    public static class AssetDatabase
    {
        //public static T FindObjectOfType<T>()
        //{
        //    UnityEditor.AssetDatabase.F
        //}

#if UNITY_EDITOR

        public static T FindObjectOfType<T>() where T : UnityEngine.ScriptableObject
        {
            string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);
            return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);            
        }

#endif

        //// Update is called once per frame
        //void Update()
        //{



        //}
    }
}
