#if UNITY_EDITOR

/*
 * Scriptable Object Context Editor 		
 * --------------------------------------------------------------------
 * Allows you to easily add ways to create scriptable objects to the Create pulldown in the project pane.
 *
 * Author
 * Martin Nerurkar of Sharkbomb Studios (http://www.sharkbombs.com)
 * Based on the CreateScriptableObjectAsset work by Brandon Edmark and Lea Hayes
 * 
 * License
 * This script is made available under a CC0 1.0 Universal license.
 * You can copy, modify, distribute and perform the work, even for commercial purposes, all without asking permission. 
 * Find out more here: https://creativecommons.org/publicdomain/zero/1.0/
 */

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.Editor
{

    public class ScriptableObjectContextEditor
    {

        /// <summary>
        /// Creating specific class menu items.
        /// </summary>
        /// <returns>The created ScriptableObject.</returns>
        /// <typeparam name="T">Type of ScriptableObject to create.</typeparam>
        public static T CreateAsset<T>() where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            string path = GetAssetPath();
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

            BuildAsset(asset, assetPathAndName);

            return asset;
        }

        /// <summary>
        /// Gets the target path for the asset to create.
        /// </summary>
        /// <returns>The asset path.</returns>
        public static string GetAssetPath()
        {
            string path;

            path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            return path;
        }

        /// <summary>
        /// Builds the asset and does neccessary AssetDatabase things.
        /// </summary>
        /// <param name="assetType">Asset type.</param>
        /// <param name="path">Path.</param>
        public static void BuildAsset(ScriptableObject asset, string assetPathAndName)
        {
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        /// <summary>
        /// Create Project Create Context Menu item
        /// </summary>
        [MenuItem("Assets/Create ScriptableObject", false, 1)]
        static void DoCreateScriptableObject()
        {
            string targetScriptPath;
            List<MonoScript> scripts = new List<MonoScript>();
            foreach (Object o in Selection.objects)
            {
                if (o.GetType() == typeof(MonoScript))
                {
                    var scr = ((MonoScript)o);

                    // Check if we are a ScriptableObject
                    if (typeof(ScriptableObject).IsAssignableFrom(scr.GetClass()))
                    {
                        var scriptableObject = ScriptableObject.CreateInstance(scr.GetClass());

                        string path = GetAssetPath();
                        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + scriptableObject.GetType().Name.ToString() + ".asset");

                        BuildAsset(scriptableObject, assetPathAndName);
                    }
                    else
                    {
                        Debug.LogWarning("Create ScriptableObject Asset failed: Selected Class does not inherit from ScriptableObject");
                    }
                }
            }

        }
    }
}

#endif