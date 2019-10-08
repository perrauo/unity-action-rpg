using UnityEngine;
using System.Collections;
using System.Linq;

namespace Cirrus.Extensions
{

    public static class IEnumerableExtension
    {
        public static bool IsEmpty<T>(this System.Collections.Generic.IEnumerable<T> collection)
        {
            return collection.Count() == 0;
        } 
    }
}
