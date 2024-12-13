using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.utils
{
    public static class ColorManagment
    {
        public static Color InputColors { get; private set; } = ColorTranslator.FromHtml("#696CFF");
        public static Color BackGroundColor { get; private set; } = ColorTranslator.FromHtml("#212229");
        public static Color DefaultPurple { get; private set; } = ColorTranslator.FromHtml("#696CFF");
        public static Color ActiveButton { get; private set; } = ColorTranslator.FromHtml("#4446B5");
        public static Color UnActiveButton { get; private set; } = ColorTranslator.FromHtml("#383990");
        public static Color CardBackground { get; private set; } = ColorTranslator.FromHtml("#313276");
        public static Color LineBetweenButtons { get; private set; } = ColorTranslator.FromHtml("#313276");
        public static Color UnActiveButtonFontColor { get; private set; } = ColorTranslator.FromHtml("#9A9A9A");
        public static Color HeaderBackGround { get; private set; } = Color.FromArgb(100,56,57,144);
        public static Color MovieCardHeader { get; private set; } = ColorTranslator.FromHtml("#B5BFDD");
        public static Color MoveCardBackground { get; private set; } = Color.FromArgb(100, 49, 50, 118);
        public static Color MovieCardBorder { get; private set;} = ColorTranslator.FromHtml("#383990");
        public static Color InvisibleBackGround { get; private set;} = Color.FromArgb(0, 0, 0, 0);
        public static Color MovieCardOption { get; private set; } = ColorTranslator.FromHtml("#5B6172");
        public static Color MovieCardOptionValue { get; private set; } = ColorTranslator.FromHtml("#FFFFFF");
        public static Color OptionField { get; set; } = Color.FromArgb(60, 61, 66, 119);
        public static Color OptionValueField { get; private set; } = Color.FromArgb(60, 51, 53, 80);
    }
}
