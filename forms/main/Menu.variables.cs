using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using KinoRakendus.core.enums;
using KinoRakendus.core.controls;
using System.IO;

namespace KinoRakendus.forms.main
{
    public partial class Menu
    {
        public Panel Header { get; set; }
        public Label HeaderLine { get; set; }
        public HeaderButton ActiveButton { get; set; }
        public PageUserControl MainPage { get; set; }
        

        // buttons in header
        public HeaderButton PiletidButton { get; set; } = new HeaderButton(Buttons.Piletid);
        public HeaderButton KavaButton { get; set; } = new HeaderButton(Buttons.Kava);
        public HeaderButton Profile { get; set; } = new HeaderButton(Buttons.Profile);
        public HeaderButton Piletid { get; set; } = new HeaderButton(Buttons.Piletid);
        public HeaderButton Balance { get; set; } = new HeaderButton(Buttons.Balance);
        public HeaderButton History { get; set; } = new HeaderButton(Buttons.History);
    }
}