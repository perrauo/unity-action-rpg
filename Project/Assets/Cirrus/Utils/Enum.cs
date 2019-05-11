
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.Utils
{
    public class Enum
    {
        public static int Size(System.Type t)
        {
            return System.Enum.GetNames(t).Length;
        }
    }

}