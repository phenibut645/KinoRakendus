using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.utils;

namespace KinoRakendus
{
    public partial class Login
    {
        private void InitAll()
        {
            InitLabels();
            InitTextBoxes();
            InitSubmitButton();
        }
        private void InitLabels()
        {
            this.UserNameLabel = new Label();
            UserNameLabel.ClientSize = new Size(204, 47);
            UserNameLabel.Font = MaintFont;
            UserNameLabel.Location = new Point(258, 198);
            UserNameLabel.Text = "Username";
            UserNameLabel.ForeColor = Color.White;
            this.Controls.Add(UserNameLabel);

            this.PasswordLabel = new Label();
            PasswordLabel.ClientSize = new Size(1655, 39);
            PasswordLabel.Font = MaintFont;
            PasswordLabel.Location = new Point(258, 359);
            PasswordLabel.ForeColor = Color.White;

            PasswordLabel.Text = "Password";
            this.Controls.Add(PasswordLabel);
        }
        private void InitTextBoxes()
        {
            this.UserName = new TextBox();
            UserName.Name = "username_textbox";
            UserName.Font = new Font("Arial", 16);
            UserName.ClientSize = new Size(283, 46);
            UserName.Location = new Point(258, 264);
            UserName.BorderStyle = BorderStyle.None;
            UserName.BackColor = ColorManagment.InputColors;
            UserName.ForeColor = Color.White;
            this.Controls.Add(UserName);

            Password = new TextBox();
            Password.Name = "password_textbox";
            Password.Font = new Font("Arial", 16);
            Password.ClientSize = new Size(283, 46);
            Password.BorderStyle = BorderStyle.None;
            Password.Location = new Point(258, 425);
            Password.ForeColor = Color.White;
            Password.BackColor = ColorManagment.InputColors;
            this.Controls.Add(Password);
        }
        private void InitSubmitButton()
        {
            SubmitButton = new Button();
            SubmitButton.Name = "submit_button";
            SubmitButton.ClientSize = new Size(204, 69);
            SubmitButton.Font = MaintFont;
            SubmitButton.Location = new Point(298, 532);
            SubmitButton.Text = "Submit";
            SubmitButton.BackColor = ColorManagment.InputColors;
            SubmitButton.ForeColor = Color.White;
            SubmitButton.FlatStyle = FlatStyle.Flat;
            SubmitButton.FlatAppearance.BorderSize = 0;
            SubmitButton.Click += this.submitButton_click;
            Controls.Add(SubmitButton);
        }
        
    }
}
