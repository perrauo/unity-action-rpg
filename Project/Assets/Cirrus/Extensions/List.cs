//using UnityEngine;
//using System.Collections;

namespace Cirrus.Extensions
{
    public static class ListExtension
    {
        // Use this for initialization
        public static T RemoveRandom<T>(this System.Collections.Generic.List<T> list)
        {
            int index = UnityEngine.Random.Range(0, list.Count);
            var val = list[index];
            list.RemoveAt(index);
            return val;
        }

        public static bool IsEmpty<T>(this System.Collections.Generic.List<T> collection)
        {
            return collection.Count == 0;
        }

        // Update is called once per frame
        //void Update()
        //{

        //}
    }
}