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
        public static Color InputColors { get; private set; } =ColorTranslator.FromHtml("#696CFF");
        public static Color BackGroundColor { get; private set; } = ColorTranslator.FromHtml("#212229");
        public static Color DefaultPurple { get; private set; } = ColorTranslator.FromHtml("#696CFF");
        public static Color ActiveButton { get; private set; } = ColorTranslator.FromHtml("#4446B5");
    }
}
