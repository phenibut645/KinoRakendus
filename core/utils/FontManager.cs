using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KinoRakendus.core.utils
{
    public static class FontManager
    {
        public static PrivateFontCollection jaroRegualr;

        static FontManager()
        {
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile(Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\other\fonts\jaro\Jaro-Regular.ttf")));
            jaroRegualr = font;
        }

        public static Font GetFont(int size)
        {
            return new Font(jaroRegualr.Families[0], size);
        }
    }
}
