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
using KinoRakendus.core.context;
using System.Runtime.CompilerServices;
using KinoRakendus.core.models.database;
using KinoRakendus.core.enums;
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
                FormAppContext.CurrentUser = user;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Down");
            }
            
        }
        private void submitSignInButton_click(object sender, EventArgs e)
        {
            if(ConfirmPassword.Text != Password.Text)
            {
                MessageBox.Show("Passwords don't match", "Error");
                return;
            }
            else
            {
                Kasutaja kasutaja = new Kasutaja();
                kasutaja["nimi"] = UserName.Text;
                kasutaja["roll"] = RolesManagment.GetRoleId(Rolls.User).ToString();
                kasutaja["salasona"] = ConfirmPassword.Text;
                DBHandler.AddUser(kasutaja);
                MessageBox.Show("Success", "Error");
                kasutaja = DBHandler.GetRecord<Kasutaja>(new List<WhereField>() { new WhereField("nimi", UserName.Text), new WhereField("salasona", Password.Text)});
                User user = User.ConvertUser(kasutaja);
                FormAppContext.CurrentUser = user;
                this.Dispose();
            }
        }
        public void Clear()
        {
            foreach(Control control in this.Controls)
            {
                control.Dispose();
            }
            this.Controls.Clear();
        }
        public void SignIn(object sender, EventArgs e)
        {
            Clear();
            InitSignin();
        }
    }
}
