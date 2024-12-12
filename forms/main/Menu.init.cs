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
            Header.Location = new Point(0, 0);

            this.HeaderLine = new Label();
            HeaderLine.Height = 4;
            HeaderLine.Width = 1723;
            HeaderLine.BackColor = ColorManagment.DefaultPurple;
            HeaderLine.Location = new Point(0, 73);

            
            if(this.User.roll == core.enums.Rolls.User)
            {
                KavaButton = GetButtonInHeader("Kava", active: true);
                ActiveButton = KavaButton;
                KavaButton.
                KavaButton.Click += new EventHandler(kavaButton_click);

                Piletid = GetButtonInHeader("Piletid");
                Piletid.Click += piletidButton_click;

                Balance = GetButtonInHeader("Balance");
                Balance.Click += balanceButton_click;

                History = GetButtonInHeader("History");
                History.Click += historyButton_click;

                List<Button> buttons = new List<Button>()
                {
                    KavaButton, Piletid, Balance, History
                };

                int index = -1;
                foreach (Button button in buttons)
                {
                    index++;
                    button.Location = new Point(button.Width * index, 0);
                    Label line = GetLineBetweenButtons();
                    line.Location = new Point(button.Width * (index + 1) + line.Width / 2, 0);
                    this.Controls.Add(line);
                    this.Controls.Add(button);
                }
                return;
            }
            else if (this.User.roll == core.enums.Rolls.Admin)
            {
                return;
            }

            this.Header.Controls.Add(HeaderLine);
            this.Controls.Add(Header);
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
