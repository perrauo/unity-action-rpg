
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.Utils
{
    public class Vectors
    {
        public static Vector3 X0Y(Vector2 vector)
        {
            return new Vector3(vector.x, 0, vector.y);
        }

        public static Vector3 X0Z(Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z);
        }

        private const float tolerance = 0.1f;
        public static bool CloseEnough(Vector3 pos0, Vector3 pos1)
        {
            return (Vector3.Distance(pos0, pos1) <= tolerance);
        }

        public static bool CloseEnough(Vector3 pos0, Vector3 pos1, float tolerance)
        {
            return (Vector3.Distance(pos0, pos1) <= tolerance);
        }

    }

}