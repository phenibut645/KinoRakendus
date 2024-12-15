using KinoRakendus.core.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.models;
using KinoRakendus.core.utils;
using KinoRakendus.core.context;
using System.IO;
namespace KinoRakendus.forms.main
{
    public partial class Menu : Form
    {
        public Menu()
        {
            this.Icon = new Icon(Path.Combine(DefaultPaths.DefaultImagesPath, "icon.ico"));
            this.Text = "CookieKino";
            this.BackColor = ColorManagment.BackGroundColor;
            this.ClientSize = new Size(1720, 980);

            FormAppContext.MainForm = this;
            FormAppContext.LoggedIn += LoggedIn;
            InitAll();
        }
    }
}
