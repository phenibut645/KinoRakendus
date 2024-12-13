using KinoRakendus.core.controls;
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
using KinoRakendus.core.enums;
using System.Runtime.InteropServices;
using KinoRakendus.core.utils;

namespace KinoRakendus.forms.main.pages
{
    public partial class Profile : PageUserControl
    {
        public User User { get; set; }

        public AvatarChangeAbility ACA;
        public Option VanusOption { get; set; }
        public Option RollOption { get; set; }
        public Option SalaSonaOption { get; set; }
        public Label UserName { get; set; }
        public Panel MainContainer { get; set; }
        public Button Logout { get; set; }
        public Profile(): base() { } 
        public Profile(User user)
        {
            this.Size = new Size(1720, 903);
            User = user;
            
        }
        public override void InitAll()
        {
            base.InitAll();
            MainContainer = new Panel();
            this.Controls.Add(MainContainer);
            MainContainer.Size = new Size(757, 782);
            MainContainer.Location = new Point(480, 31);

            ACA = new AvatarChangeAbility(User);
            MainContainer.Controls.Add(ACA);
            ACA.Location = new Point(315, 60);


            VanusOption = new Option(OptionType.Default, "Vanus", User.vanus.ToString());
            VanusOption.Button.Available = true;
            MainContainer.Controls.Add(VanusOption);
            VanusOption.Location = new Point(196, 296);

            RollOption = new Option(OptionType.Default, "Roll", User.roll.ToString());
            MainContainer.Controls.Add(RollOption);
            RollOption.Location = new Point(196, 379);

            SalaSonaOption = new Option(OptionType.Default, "Salasõna", "******");
            SalaSonaOption.Button.Available = true;
            MainContainer.Controls.Add(SalaSonaOption);
            SalaSonaOption.Location = new Point(196, 462);

            UserName = new Label();
            UserName.Text = User.name;
            UserName.ForeColor = Color.White;
            UserName.Size = new Size(500, 60);
            UserName.TextAlign = ContentAlignment.MiddleCenter;
            UserName.Location = new Point(MainContainer.Width / 2 - UserName.Width / 2, 195);
            MainContainer.Controls.Add(UserName);
            UserName.Font = core.utils.DefaultFonts.GetFont(34);

            Logout = new Button();
        }
    }
}
