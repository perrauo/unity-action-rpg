using UnityEngine;
using System.Collections;

namespace Cirrus.Extensions
{

    public static class Vector3Extension
    {
    

        public static Vector3 ToVector3(this Vector3Int vec3)
        {
            return new Vector3(vec3.x, vec3.y, vec3.z);
        }

        public static Vector3Int SetXYZ(this Vector3Int vec3, int x, int y, int z)
        {
            vec3.x = x;
            vec3.y = y;
            vec3.z = z;
            return vec3;
        }

        public static Vector3Int SetXY(this Vector3Int vec3, int x, int y)
        {
            vec3.x = x;
            vec3.y = y;
            //vec3.z = z;
            return vec3;
        }

        public static Vector3Int SetXZ(this Vector3Int vec3, int x, int z)
        {
            //return new Vector3Int(x, vec3.y, z);
            vec3.x = x;
            //vec3.y = y;
            vec3.z = z;
            return vec3;
        }

        public static Vector3Int SetZ(this Vector3Int vec3, int z)
        {
            //vec3.x = x;
            //vec3.y = y;
            vec3.z = z;
            return vec3;
        }




    }
}
