using UnityEngine;
using System.Collections;

namespace Cirrus.Extensions
{

    public static class Vector2Extension
    {
        public static Vector2Int ToVector2Int(this Vector2 vec2)
        {
            return new Vector2Int((int)vec2.x, (int)vec2.y);// (int)vec3.z);
        }
    }
}
