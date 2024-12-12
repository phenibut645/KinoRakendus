using KinoRakendus.core.controls;
using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.forms.main
{
    public partial class Menu
    {
        public void ChangePage(PageUserControl page)
        {
            this.MainPage = page;
            this.Controls.Add(MainPage);
            MainPage.Show();
        }
    }
}
