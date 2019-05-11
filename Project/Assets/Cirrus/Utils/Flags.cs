///====================================================================================================
///
///     BitwiseUtil by
///     - CantyCanadian
///
///====================================================================================================

using UnityEngine;

namespace Cirrus.Utils
{
    public static class Bitwise
    {
        /// <summary>
        /// Counts how many bits within an integer is set to 1.
        /// </summary>
        /// <param name="value">Integer to work with.</param>
        /// <returns>Number of set bits.</returns>
        public static int Count<T>(T t)
        {
            int value = (int)(object)t;

            int count = 0;
            while (value > 0)
            {
                count += value & 1;
                value >>= 1;
            }

            return count;
        }


        public static int Position<T>(T t)
        {
            int value = (int)(object)t;
            int count = 0;
            while (value != 0)
            {
                count++;
                value >>=  1;
            }
            return count;
        }


        public static bool TestBit<T>(T t, int position)
        {
            int value = (int)(object)t;

            return ((value >> position) & 1) == 1;
        }

        public static T SetBit<T>(T t, int position)
        {
            int value = (int)(object)t;
            value |= 1 << position;
            return (T)(object)value;
        }

        public static T ClearBit<T>(T t, int position)
        {
            int value = (int)(object)t;
            value &= ~(1 << position);
            return (T)(object)value;
        }

        public static T ToggleBit<T>(T t, int position)
        {
            int value = (int)(object)t;
            value ^= 1 << position;
            return (T)(object)value;
        }
    }
}