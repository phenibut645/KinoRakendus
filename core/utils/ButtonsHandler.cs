using KinoRakendus.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.enums;

namespace KinoRakendus.core.utils
{
    public static class ButtonsHandler
    {
        public static void SetButton<T> (T button) where T: TypeButton
        {
            Buttons typeButton = button.Type;

            switch (typeButton)
            {
                case Buttons.Kava:
                    button.Window = new Kava();
                    return null;
                default:
                    return null;
            }
        }
    }
}
