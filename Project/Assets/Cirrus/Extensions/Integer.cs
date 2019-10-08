using UnityEngine;
using System.Collections;

namespace Cirrus.Extensions
{

    public static class IntegerExtension
    {
        public static int Mod(this int x, int m)
        {
            return (x % m + m) % m;
        }

        public static int Wrap(this int x, int x_min, int x_max)
        {
            if (x < x_min)
                return x_max - (x_min - x) % (x_max - x_min);
            else
                return x_min + (x - x_min) % (x_max - x_min);
        }
    }
}