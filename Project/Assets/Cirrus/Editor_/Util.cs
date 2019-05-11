#if UNITY_EDITOR

using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Cirrus.Editor
{
    public class Util
    {
        [MenuItem("Assets/Create .txt", false, 1)]
        static void CreateTxt()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);

            string unique = AssetDatabase.GenerateUniqueAssetPath(path + "/Note.txt");

            // Debug.Log(unique);

            using (StreamWriter writer = new StreamWriter(unique, false))
            {
                writer.WriteLine("Hello world..");
                writer.Flush();
            }

            AssetDatabase.Refresh();

        }

        [MenuItem("Assets/Create .cs", false, 1)]
        static void CreateCs()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);

            string unique = AssetDatabase.GenerateUniqueAssetPath(path + "/MyClass.cs");

            Debug.Log(unique);

            using (StreamWriter writer = new StreamWriter(unique, false))
            {
                writer.WriteLine("");
                //writer.WriteLine("aInt.ToString() to write");
                writer.Flush();
            }

            AssetDatabase.Refresh();

        }
    }
}


#endif