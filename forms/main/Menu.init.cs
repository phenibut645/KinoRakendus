using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.controls;
using KinoRakendus.core.enums;
using System.IO;
using KinoRakendus.core.presets;
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
            Header.Location = new Point(0, 0);
            Header.BackColor = ColorManagment.HeaderBackGround;
            this.Controls.Add(Header);

            this.HeaderLine = new Label();
            HeaderLine.Height = 11;
            HeaderLine.Width = 1723;
            HeaderLine.BackColor = ColorManagment.DefaultPurple;
            HeaderLine.Location = new Point(0, 73);
            this.Header.Controls.Add(HeaderLine);

            List<HeaderButton> buttons = DefaultPageTemplates.GetButtons(User.roll);
            HeaderButton moreButton = null;
            int currentX = 0;
            int index = -1;
            foreach(HeaderButton button in buttons)
            {
                index++;
                if(index > 3)
                {
                    moreButton = new HeaderButton(null, HeaderButtonType.More);
                    moreButton.Location = new Point(currentX, 0);
                    this.Header.Controls.Add(moreButton);
                    break;
                }
                Console.WriteLine($"LIDA {button.Page}");
                button.Location = new Point(currentX, 0);
                currentX += button.Width + 25;
                this.Header.Controls.Add(button);
            }
            Profile = new HeaderButton(null, HeaderButtonType.Profile, user:User);
            Profile.Location = new Point(ClientSize.Width - Profile.Width, 0);
            if (moreButton != null) buttons.Add(moreButton);
            buttons.Add(Profile);
            HeaderHandler.LoadButtons(buttons);
            this.Header.Controls.Add(Profile);
        }
        public Label GetLineBetweenButtons(int x = 0, int y = 0)
        {
            Label line = new Label();
            line.Size = new Size(6, 73);
            line.BackColor = ColorManagment.LineBetweenButtons;
            return line;
        }
    }
}
