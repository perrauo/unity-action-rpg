
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.Utils
{
    [System.Serializable]
    public enum Flag
    {
        _0 = 1 << 0,
        _1 = 1 << 1,
        _2 = 1 << 2,
        _3 = 1 << 3,
        _4 = 1 << 4,
        _5 = 1 << 5,
        _6 = 1 << 6,
        _7 = 1 << 7,
        _8 = 1 << 8,
        _9 = 1 << 9,
        _10 = 1 << 10,
        _11 = 1 << 11,
        _12 = 1 << 12,
        _13 = 1 << 13,
        _14 = 1 << 14,
        _15 = 1 << 15,
        _16 = 1 << 16,
        _17 = 1 << 17,
        _18 = 1 << 18,
        _19 = 1 << 19,
        _20 = 1 << 20,
        _21 = 1 << 21,
        _22 = 1 << 22,
        _23 = 1 << 23,
        _24 = 1 << 24,
        _25 = 1 << 25,
        _26 = 1 << 26,
        _27 = 1 << 27,
        _28 = 1 << 28,
        _29 = 1 << 29,
        _30 = 1 << 30,
        _31 = 1 << 31
    }


    public enum DataType
    {
        Double,
        Float,
        Int,
        Long,
        String,
        Char,
        Bool
    }

    public class Validation
    {
        public static void Error(string err)
        {
            Debug.LogError(err);
            //UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
            
        }


        public static void Assert(bool condition, string msg="")
        {
#if UNITY_EDITOR

            if (!condition)
            {
                Debug.LogError("Assertion failed " + msg);
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }

#endif
        }


        public static void AssertNotNull(object obj, string idname="<unknown-identifier>", string classname = "<unknown-identifier>")
        {
#if UNITY_EDITOR

            if (obj == null)
            {     
                Debug.LogError("Missing reference '"+ idname + "' in the inspector for class '"+ classname +"'.");
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }

#endif
        }


    }

    public class GameObjects
    {
        private static void _RecurseCollapseChildrenToList<TComponent>(GameObject parent, ref List<TComponent> collapsedChildren)
        {
            foreach (Transform child in parent.transform)
            {
                var component = child.gameObject.GetComponent<TComponent>();
                if (component != null)
                {
                    collapsedChildren.Add(component);
                }

                _RecurseCollapseChildrenToList(child.gameObject, ref collapsedChildren);
            }
        }

        public static List<TComponent> CollapseChildrenToList<TComponent>(GameObject parent)
        {
            List<TComponent> collapsedChildren = new List<TComponent>();

            foreach (Transform child in parent.transform)
            {
                _RecurseCollapseChildrenToList(child.gameObject, ref collapsedChildren);
            }

            return collapsedChildren;
        }
    }


    public class Mathf
    {
        private const float tolerance = 0.1f;
        public static bool CloseEnough(float a, float b, float tolerance = Mathf.tolerance)
        {
            return (UnityEngine.Mathf.Abs(a - b) < tolerance);
        }

        public static float Normalize(float value, float min, float max, float zero)
        {
            if (zero < min)
                zero = min;
            // Prevent NaN/Inf from dividing 0 by something.
            if (UnityEngine.Mathf.Approximately(value, min))
            {
                if (min < zero)
                    return -1f;
                return 0f;
            }
            var percentage = (value - min) / (max - min);
            if (min < zero)
                return 2 * percentage - 1;
            return percentage;
        }

        public static float DeadZone(float value, float min, float max)
        {
            var absValue = UnityEngine.Mathf.Abs(value);
            if (absValue < min)
                return 0;
            if (absValue > max)
                return UnityEngine.Mathf.Sign(value);

            return UnityEngine.Mathf.Sign(value) * ((absValue - min) / (max - min));
        }


    }

}