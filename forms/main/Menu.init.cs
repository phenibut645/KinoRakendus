using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.forms.main
{
    public partial class Menu
    {
        public void InitAll()
        {
            this.InitHeader();
        }
        public void InitHeader()
        {
            this.Header = new Panel();
            Header.Size = new Size(1720, 80);

            this.HeaderLine = new Label();
            HeaderLine.Height = 4;
            HeaderLine.Width = 1723;
            HeaderLine.BackColor = ColorManagment.DefaultPurple;
            HeaderLine.Location = new Point(0, 73);
            

            this.KavaButton = new Button();
            KavaButton.Size = new Size(287, 73);
            KavaButton.BackColor = ColorManagment.ActiveButton;
            KavaButton.ForeColor = Color.White;
            KavaButton.Font = FontManager.GetFont(22);
            KavaButton.Text = "Kava";
            KavaButton.FlatStyle = FlatStyle.Flat;
            KavaButton.FlatAppearance.BorderSize = 0;
            this.Header.Controls.Add(KavaButton);
            this.Header.Controls.Add(HeaderLine);
            this.Controls.Add(Header);
        }
    }
}
