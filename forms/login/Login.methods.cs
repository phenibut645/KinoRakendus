using KinoRakendus.core.utils;
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
namespace KinoRakendus
{
    public partial class Login
    {
        private void submitButton_click(object sender, EventArgs e)
        {
            User user = DBHandler.CheckUser(this.UserName.Text, Password.Text);
            if(user != null)
            {
                MessageBox.Show(user.roll.ToString());
            }
            else
            {
                MessageBox.Show("Down");
            }
            
        }
    }
}
