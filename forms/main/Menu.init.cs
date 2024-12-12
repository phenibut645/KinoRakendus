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

            Profile.Size = new Size(72, 72);
            Profile.Region = new Region(new Rectangle(0, 0, Profile.Width, Profile.Height));
            Profile.BackgroundImage = ImagesManager.GetAvatar(User);
            Profile.BackgroundImageLayout = ImageLayout.Stretch;
            Profile.Location = new Point(1649, 0);
            
            Profile.Text = "";
            this.Header.Controls.Add(Profile);

            Label profileLine =GetLineBetweenButtons();
            profileLine.Location = new Point(1642, 0);
            Header.Controls.Add(profileLine);

            List<HeaderButton> buttons = new List<HeaderButton>();

            if(this.User.roll == Rolls.User)
            {
                KavaButton = new HeaderButton(Buttons.Kava);
          
                Piletid = new HeaderButton(Buttons.Piletid);
                Balance = new HeaderButton(Buttons.Balance);
                History = new HeaderButton(Buttons.History);

                buttons = new List<HeaderButton>()
                {
                    KavaButton, Piletid, Balance, History
                };
            }
            else if (this.User.roll == Rolls.Admin)
            {
                return;
            }
            int index = -1;
            foreach (Button button in buttons)
            {
                index++;
                button.Location = new Point(button.Width * index, 0);
                Label line = GetLineBetweenButtons();
                line.Location = new Point(button.Width * (index + 1) - line.Width / 2, 0);
                this.Header.Controls.Add(line);
                this.Header.Controls.Add(button);
            }
            HeaderHandler.LoadButtons(buttons);

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
