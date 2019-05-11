
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.Utils
{
    class ScriptableObject
    {
        public static List<T> CreateUnique<T>(ref List<T> items)
        {
            if(!typeof(UnityEngine.ScriptableObject).IsAssignableFrom(typeof(T)))
                throw new System.Exception("ScriptableObject.Unique does not apply to non scriptable object type.");
            List<T> newItems = items.Aggregate<T, List<T>>(
                new List<T>(), 
                (cummul, item) => {
                    if (item != null)
                        cummul.Add( (T) (object) Object.Instantiate((UnityEngine.ScriptableObject) ((object) item)));
                    return cummul; });

            return newItems; 
        }

        public static T CreateUnique<T>(T item)
        {
            if (!typeof(UnityEngine.ScriptableObject).IsAssignableFrom(typeof(T)))
                throw new System.Exception("ScriptableObject.Unique does not apply to non scriptable object type.");

            //item = (T)(object)Object.Instantiate((UnityEngine.ScriptableObject)((object)item));
            return item;
        }



    }
}
