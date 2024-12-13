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
            if (MainPage != null)
            {
                if(MainPage == page) return;
                MainPage.Clear();
                this.Controls.Remove(MainPage);
            }
            this.MainPage = page;
            MainPage.InitAll();

            this.Controls.Add(MainPage);
        }
    }
}
