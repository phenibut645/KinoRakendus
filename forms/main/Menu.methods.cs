using KinoRakendus.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.utils;
using KinoRakendus.core.context;
using KinoRakendus.core.models.database;
using System.Drawing;
using KinoRakendus.forms.main.pages;

namespace KinoRakendus.forms.main
{
    public partial class Menu
    {
        public void RefreshForm()
        {
            HeaderHandler.ClearEverything();
            MainPage = null;
            InitAll();
        }
        public void Logout()
        {
           FormAppContext.CurrentUser = null;
        }
    }
}
