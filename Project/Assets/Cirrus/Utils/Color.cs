using System.Collections.Generic;
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

    //public class ColorUtils
    //{

    //    /**
    //     * Initialize the color list that we have.
    //     */
    //    private List<ColorName> initColorList()
    //    {
    //        List<ColorName> colorList = new List<ColorName>();
    //        colorList.Add(new ColorName("AliceBlue", 0xF0, 0xF8, 0xFF));
    //        colorList.Add(new ColorName("AntiqueWhite", 0xFA, 0xEB, 0xD7));
    //        colorList.Add(new ColorName("Aqua", 0x00, 0xFF, 0xFF));
    //        colorList.Add(new ColorName("Aquamarine", 0x7F, 0xFF, 0xD4));
    //        colorList.Add(new ColorName("Azure", 0xF0, 0xFF, 0xFF));
    //        colorList.Add(new ColorName("Beige", 0xF5, 0xF5, 0xDC));
    //        colorList.Add(new ColorName("Bisque", 0xFF, 0xE4, 0xC4));
    //        colorList.Add(new ColorName("Black", 0x00, 0x00, 0x00));
    //        colorList.Add(new ColorName("BlanchedAlmond", 0xFF, 0xEB, 0xCD));
    //        colorList.Add(new ColorName("Blue", 0x00, 0x00, 0xFF));
    //        colorList.Add(new ColorName("BlueViolet", 0x8A, 0x2B, 0xE2));
    //        colorList.Add(new ColorName("Brown", 0xA5, 0x2A, 0x2A));
    //        colorList.Add(new ColorName("BurlyWood", 0xDE, 0xB8, 0x87));
    //        colorList.Add(new ColorName("CadetBlue", 0x5F, 0x9E, 0xA0));
    //        colorList.Add(new ColorName("Chartreuse", 0x7F, 0xFF, 0x00));
    //        colorList.Add(new ColorName("Chocolate", 0xD2, 0x69, 0x1E));
    //        colorList.Add(new ColorName("Coral", 0xFF, 0x7F, 0x50));
    //        colorList.Add(new ColorName("CornflowerBlue", 0x64, 0x95, 0xED));
    //        colorList.Add(new ColorName("Cornsilk", 0xFF, 0xF8, 0xDC));
    //        colorList.Add(new ColorName("Crimson", 0xDC, 0x14, 0x3C));
    //        colorList.Add(new ColorName("Cyan", 0x00, 0xFF, 0xFF));
    //        colorList.Add(new ColorName("DarkBlue", 0x00, 0x00, 0x8B));
    //        colorList.Add(new ColorName("DarkCyan", 0x00, 0x8B, 0x8B));
    //        colorList.Add(new ColorName("DarkGoldenRod", 0xB8, 0x86, 0x0B));
    //        colorList.Add(new ColorName("DarkGray", 0xA9, 0xA9, 0xA9));
    //        colorList.Add(new ColorName("DarkGreen", 0x00, 0x64, 0x00));
    //        colorList.Add(new ColorName("DarkKhaki", 0xBD, 0xB7, 0x6B));
    //        colorList.Add(new ColorName("DarkMagenta", 0x8B, 0x00, 0x8B));
    //        colorList.Add(new ColorName("DarkOliveGreen", 0x55, 0x6B, 0x2F));
    //        colorList.Add(new ColorName("DarkOrange", 0xFF, 0x8C, 0x00));
    //        colorList.Add(new ColorName("DarkOrchid", 0x99, 0x32, 0xCC));
    //        colorList.Add(new ColorName("DarkRed", 0x8B, 0x00, 0x00));
    //        colorList.Add(new ColorName("DarkSalmon", 0xE9, 0x96, 0x7A));
    //        colorList.Add(new ColorName("DarkSeaGreen", 0x8F, 0xBC, 0x8F));
    //        colorList.Add(new ColorName("DarkSlateBlue", 0x48, 0x3D, 0x8B));
    //        colorList.Add(new ColorName("DarkSlateGray", 0x2F, 0x4F, 0x4F));
    //        colorList.Add(new ColorName("DarkTurquoise", 0x00, 0xCE, 0xD1));
    //        colorList.Add(new ColorName("DarkViolet", 0x94, 0x00, 0xD3));
    //        colorList.Add(new ColorName("DeepPink", 0xFF, 0x14, 0x93));
    //        colorList.Add(new ColorName("DeepSkyBlue", 0x00, 0xBF, 0xFF));
    //        colorList.Add(new ColorName("DimGray", 0x69, 0x69, 0x69));
    //        colorList.Add(new ColorName("DodgerBlue", 0x1E, 0x90, 0xFF));
    //        colorList.Add(new ColorName("FireBrick", 0xB2, 0x22, 0x22));
    //        colorList.Add(new ColorName("FloralWhite", 0xFF, 0xFA, 0xF0));
    //        colorList.Add(new ColorName("ForestGreen", 0x22, 0x8B, 0x22));
    //        colorList.Add(new ColorName("Fuchsia", 0xFF, 0x00, 0xFF));
    //        colorList.Add(new ColorName("Gainsboro", 0xDC, 0xDC, 0xDC));
    //        colorList.Add(new ColorName("GhostWhite", 0xF8, 0xF8, 0xFF));
    //        colorList.Add(new ColorName("Gold", 0xFF, 0xD7, 0x00));
    //        colorList.Add(new ColorName("GoldenRod", 0xDA, 0xA5, 0x20));
    //        colorList.Add(new ColorName("Gray", 0x80, 0x80, 0x80));
    //        colorList.Add(new ColorName("Green", 0x00, 0x80, 0x00));
    //        colorList.Add(new ColorName("GreenYellow", 0xAD, 0xFF, 0x2F));
    //        colorList.Add(new ColorName("HoneyDew", 0xF0, 0xFF, 0xF0));
    //        colorList.Add(new ColorName("HotPink", 0xFF, 0x69, 0xB4));
    //        colorList.Add(new ColorName("IndianRed", 0xCD, 0x5C, 0x5C));
    //        colorList.Add(new ColorName("Indigo", 0x4B, 0x00, 0x82));
    //        colorList.Add(new ColorName("Ivory", 0xFF, 0xFF, 0xF0));
    //        colorList.Add(new ColorName("Khaki", 0xF0, 0xE6, 0x8C));
    //        colorList.Add(new ColorName("Lavender", 0xE6, 0xE6, 0xFA));
    //        colorList.Add(new ColorName("LavenderBlush", 0xFF, 0xF0, 0xF5));
    //        colorList.Add(new ColorName("LawnGreen", 0x7C, 0xFC, 0x00));
    //        colorList.Add(new ColorName("LemonChiffon", 0xFF, 0xFA, 0xCD));
    //        colorList.Add(new ColorName("LightBlue", 0xAD, 0xD8, 0xE6));
    //        colorList.Add(new ColorName("LightCoral", 0xF0, 0x80, 0x80));
    //        colorList.Add(new ColorName("LightCyan", 0xE0, 0xFF, 0xFF));
    //        colorList.Add(new ColorName("LightGoldenRodYellow", 0xFA, 0xFA, 0xD2));
    //        colorList.Add(new ColorName("LightGray", 0xD3, 0xD3, 0xD3));
    //        colorList.Add(new ColorName("LightGreen", 0x90, 0xEE, 0x90));
    //        colorList.Add(new ColorName("LightPink", 0xFF, 0xB6, 0xC1));
    //        colorList.Add(new ColorName("LightSalmon", 0xFF, 0xA0, 0x7A));
    //        colorList.Add(new ColorName("LightSeaGreen", 0x20, 0xB2, 0xAA));
    //        colorList.Add(new ColorName("LightSkyBlue", 0x87, 0xCE, 0xFA));
    //        colorList.Add(new ColorName("LightSlateGray", 0x77, 0x88, 0x99));
    //        colorList.Add(new ColorName("LightSteelBlue", 0xB0, 0xC4, 0xDE));
    //        colorList.Add(new ColorName("LightYellow", 0xFF, 0xFF, 0xE0));
    //        colorList.Add(new ColorName("Lime", 0x00, 0xFF, 0x00));
    //        colorList.Add(new ColorName("LimeGreen", 0x32, 0xCD, 0x32));
    //        colorList.Add(new ColorName("Linen", 0xFA, 0xF0, 0xE6));
    //        colorList.Add(new ColorName("Magenta", 0xFF, 0x00, 0xFF));
    //        colorList.Add(new ColorName("Maroon", 0x80, 0x00, 0x00));
    //        colorList.Add(new ColorName("MediumAquaMarine", 0x66, 0xCD, 0xAA));
    //        colorList.Add(new ColorName("MediumBlue", 0x00, 0x00, 0xCD));
    //        colorList.Add(new ColorName("MediumOrchid", 0xBA, 0x55, 0xD3));
    //        colorList.Add(new ColorName("MediumPurple", 0x93, 0x70, 0xDB));
    //        colorList.Add(new ColorName("MediumSeaGreen", 0x3C, 0xB3, 0x71));
    //        colorList.Add(new ColorName("MediumSlateBlue", 0x7B, 0x68, 0xEE));
    //        colorList.Add(new ColorName("MediumSpringGreen", 0x00, 0xFA, 0x9A));
    //        colorList.Add(new ColorName("MediumTurquoise", 0x48, 0xD1, 0xCC));
    //        colorList.Add(new ColorName("MediumVioletRed", 0xC7, 0x15, 0x85));
    //        colorList.Add(new ColorName("MidnightBlue", 0x19, 0x19, 0x70));
    //        colorList.Add(new ColorName("MintCream", 0xF5, 0xFF, 0xFA));
    //        colorList.Add(new ColorName("MistyRose", 0xFF, 0xE4, 0xE1));
    //        colorList.Add(new ColorName("Moccasin", 0xFF, 0xE4, 0xB5));
    //        colorList.Add(new ColorName("NavajoWhite", 0xFF, 0xDE, 0xAD));
    //        colorList.Add(new ColorName("Navy", 0x00, 0x00, 0x80));
    //        colorList.Add(new ColorName("OldLace", 0xFD, 0xF5, 0xE6));
    //        colorList.Add(new ColorName("Olive", 0x80, 0x80, 0x00));
    //        colorList.Add(new ColorName("OliveDrab", 0x6B, 0x8E, 0x23));
    //        colorList.Add(new ColorName("Orange", 0xFF, 0xA5, 0x00));
    //        colorList.Add(new ColorName("OrangeRed", 0xFF, 0x45, 0x00));
    //        colorList.Add(new ColorName("Orchid", 0xDA, 0x70, 0xD6));
    //        colorList.Add(new ColorName("PaleGoldenRod", 0xEE, 0xE8, 0xAA));
    //        colorList.Add(new ColorName("PaleGreen", 0x98, 0xFB, 0x98));
    //        colorList.Add(new ColorName("PaleTurquoise", 0xAF, 0xEE, 0xEE));
    //        colorList.Add(new ColorName("PaleVioletRed", 0xDB, 0x70, 0x93));
    //        colorList.Add(new ColorName("PapayaWhip", 0xFF, 0xEF, 0xD5));
    //        colorList.Add(new ColorName("PeachPuff", 0xFF, 0xDA, 0xB9));
    //        colorList.Add(new ColorName("Peru", 0xCD, 0x85, 0x3F));
    //        colorList.Add(new ColorName("Pink", 0xFF, 0xC0, 0xCB));
    //        colorList.Add(new ColorName("Plum", 0xDD, 0xA0, 0xDD));
    //        colorList.Add(new ColorName("PowderBlue", 0xB0, 0xE0, 0xE6));
    //        colorList.Add(new ColorName("Purple", 0x80, 0x00, 0x80));
    //        colorList.Add(new ColorName("Red", 0xFF, 0x00, 0x00));
    //        colorList.Add(new ColorName("RosyBrown", 0xBC, 0x8F, 0x8F));
    //        colorList.Add(new ColorName("RoyalBlue", 0x41, 0x69, 0xE1));
    //        colorList.Add(new ColorName("SaddleBrown", 0x8B, 0x45, 0x13));
    //        colorList.Add(new ColorName("Salmon", 0xFA, 0x80, 0x72));
    //        colorList.Add(new ColorName("SandyBrown", 0xF4, 0xA4, 0x60));
    //        colorList.Add(new ColorName("SeaGreen", 0x2E, 0x8B, 0x57));
    //        colorList.Add(new ColorName("SeaShell", 0xFF, 0xF5, 0xEE));
    //        colorList.Add(new ColorName("Sienna", 0xA0, 0x52, 0x2D));
    //        colorList.Add(new ColorName("Silver", 0xC0, 0xC0, 0xC0));
    //        colorList.Add(new ColorName("SkyBlue", 0x87, 0xCE, 0xEB));
    //        colorList.Add(new ColorName("SlateBlue", 0x6A, 0x5A, 0xCD));
    //        colorList.Add(new ColorName("SlateGray", 0x70, 0x80, 0x90));
    //        colorList.Add(new ColorName("Snow", 0xFF, 0xFA, 0xFA));
    //        colorList.Add(new ColorName("SpringGreen", 0x00, 0xFF, 0x7F));
    //        colorList.Add(new ColorName("SteelBlue", 0x46, 0x82, 0xB4));
    //        colorList.Add(new ColorName("Tan", 0xD2, 0xB4, 0x8C));
    //        colorList.Add(new ColorName("Teal", 0x00, 0x80, 0x80));
    //        colorList.Add(new ColorName("Thistle", 0xD8, 0xBF, 0xD8));
    //        colorList.Add(new ColorName("Tomato", 0xFF, 0x63, 0x47));
    //        colorList.Add(new ColorName("Turquoise", 0x40, 0xE0, 0xD0));
    //        colorList.Add(new ColorName("Violet", 0xEE, 0x82, 0xEE));
    //        colorList.Add(new ColorName("Wheat", 0xF5, 0xDE, 0xB3));
    //        colorList.Add(new ColorName("White", 0xFF, 0xFF, 0xFF));
    //        colorList.Add(new ColorName("WhiteSmoke", 0xF5, 0xF5, 0xF5));
    //        colorList.Add(new ColorName("Yellow", 0xFF, 0xFF, 0x00));
    //        colorList.Add(new ColorName("YellowGreen", 0x9A, 0xCD, 0x32));
    //        return colorList;
    //    }

    //    /**
    //     * Get the closest color name from our list
    //     * 
    //     * @param r
    //     * @param g
    //     * @param b
    //     * @return
    //     */
    //    public string getColorNameFromRgb(int r, int g, int b)
    //    {
    //        List<ColorName> colorList = initColorList();
    //        ColorName closestMatch = null;
    //        int minMSE = int.MaxValue;
    //        int mse;
    //        foreach(ColorName c in colorList)
    //        {
    //            mse = c.computeMSE(r, g, b);
    //            if (mse < minMSE)
    //            {
    //                minMSE = mse;
    //                closestMatch = c;
    //            }
    //        }

    //        if (closestMatch != null)
    //        {
    //            return closestMatch.getName();
    //        }
    //        else
    //        {
    //            return "No matched color name.";
    //        }
    //    }

    //    /**
    //     * Convert hexColor to rgb, then call getColorNameFromRgb(r, g, b)
    //     * 
    //     * @param hexColor
    //     * @return
    //     */
    //    public string getColorNameFromHex(int hexColor)
    //    {
    //        int r = (hexColor & 0xFF0000) >> 16;
    //        int g = (hexColor & 0xFF00) >> 8;
    //        int b = (hexColor & 0xFF);
    //        return getColorNameFromRgb(r, g, b);
    //    }

    //    public int colorToHex(UnityEngine.Color c)
    //    {
    //        return int.decode("0x" + Integer.toHexString(c.getRGB()).substring(2));
    //    }

    //    public string getColorNameFromColor(UnityEngine.Color color)
    //    {
    //        return getColorNameFromRgb(color.r, color.g),
    //                color.b);
    //    }

    //    /**
    //     * SubClass of ColorUtils. In order to lookup color name
    //     * 
    //     * @author Xiaoxiao Li
    //     * 
    //     */
    //    public class ColorName
    //    {
    //        public int r, g, b;
    //        public string name;

    //        public ColorName(string name, int r, int g, int b)
    //        {
    //            this.r = r;
    //            this.g = g;
    //            this.b = b;
    //            this.name = name;
    //        }

    //        public int computeMSE(int pixR, int pixG, int pixB)
    //        {
    //            return (int)(((pixR - r) * (pixR - r) + (pixG - g) * (pixG - g) + (pixB - b)
    //                    * (pixB - b)) / 3);
    //        }

    //        public int getR()
    //        {
    //            return r;
    //        }

    //        public int getG()
    //        {
    //            return g;
    //        }

    //        public int getB()
    //        {
    //            return b;
    //        }

    //        public string getName()
    //        {
    //            return name;
    //        }
    //    }
    //}

}