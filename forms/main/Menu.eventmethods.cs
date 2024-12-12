using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.forms.main
{
    public partial class Menu
    {
        public void kavaButton_click(object sender, EventArgs e)
        {
            ActiveButton.BackColor = ColorManagment.UnActiveButton;
            ActiveButton.ForeColor = ColorManagment.UnActiveButtonFontColor;

            
            return;
        }
        public void piletidButton_click(object sender, EventArgs args)
        {
            return;
        }
        public void balanceButton_click(object sender, EventArgs args)
        {
            return;
        }
        public void historyButton_click(object sender, EventArgs eventArgs)
        {
            return;
        }
    }
}
