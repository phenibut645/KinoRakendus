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
namespace KinoRakendus.forms.main
{
    public partial class Menu : Form
    {
        public User User { get; private set; }
        public Menu(User user)
        {
            this.BackColor = ColorManagment.BackGroundColor;
            this.ClientSize = new Size(1720, 980);
            this.User = user;
            InitAll();
        }
    }
}
