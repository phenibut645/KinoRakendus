using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus
{
    public partial class Login : Form
    {
        public Login()
        {
            this.ClientSize = new Size(Width, Height);
            this.InitAll();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = ColorManagment.BackGroundColor;
            
        }
    }
}
