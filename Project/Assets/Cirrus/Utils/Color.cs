using UnityEngine.UI;

namespace Cirrus.Utils
{
    public class Color
    {
        public static UnityEngine.Color Copy(UnityEngine.Color c)
        {
            return new UnityEngine.Color(c.r, c.g, c.b, c.a);
        }


        public static void SetR(ref Image im, float r)
        {
            var c = im.color;
            c.r = r;
            im.color = c;
        }

        public static void SetG(ref Image im, float g)
        {
            var c = im.color;
            c.g = g;
            im.color = c;
        }

        public static void SetB(ref Image im, float b)
        {
            var c = im.color;
            c.b = b;
            im.color = c;
        }


        public static void SetA(ref Image im, float a)
        {
            var c = im.color;
            c.a = a;
            im.color = c;
        }
    }

}