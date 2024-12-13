using KinoRakendus.core.enums;
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

namespace KinoRakendus.core.controls
{
    public partial class Option : UserControl
    {
        public OptionType Type { get; set; }
        public Label OptionName { get; set; }
        public Label OptionValue { get; set; }
        public ChangeButton Button { get; set; }

        
        public Option(OptionType type, string optionName, string optionValue, int height = 48, int width = 160)
        {
            this.Type = type;

            OptionName = new Label();
            OptionName.Text = optionName;
            OptionName.BackColor = ColorManagment.OptionField;
            OptionName.ForeColor = ColorManagment.MovieCardHeader;
            OptionName.Font = utils.DefaultFonts.GetFont(22);
            OptionName.Size = new Size(width, height);
            OptionName.Location = new Point(0, 0);
            OptionName.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(OptionName);
            Console.WriteLine("first field");

            OptionValue = new Label();
            OptionValue.Text = optionValue;
            OptionValue.BackColor = ColorManagment.OptionValueField;
            OptionValue.ForeColor = Color.White;
            OptionValue.Font = utils.DefaultFonts.GetFont(22);
            OptionValue.Size = new Size(width, height);
            OptionValue.ForeColor = Color.White;
            OptionValue.Location = new Point(OptionName.Width, 0);
            OptionValue.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(OptionValue);
            Console.WriteLine($"{OptionName.Width}, 0");

            Button = new ChangeButton(type);
            Button.Location = new Point(OptionValue.Width + OptionName.Width, 0);
            this.Controls.Add(Button);

            this.Size = new Size(OptionName.Size.Width + OptionValue.Size.Width + Button.Width, height);
            
        }
        
    }
}
