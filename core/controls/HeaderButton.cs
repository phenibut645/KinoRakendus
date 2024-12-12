using KinoRakendus.core.enums;
using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.core.controls
{
    public class HeaderButton: TypeButton
    {
        public bool IsActive { get; set; }
        public PageUserControl Page { get; set; } = null;

        public HeaderButton(Buttons type) : base(type)
        {
            IsActive = true;
            this.Font = FontManager.GetFont(19);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            ChangeActiveStatus();
            this.Text = type.ToString();
            this.Size = new System.Drawing.Size(287, 73);
        }
        public void ChangeTextSize(int size)
        {
            this.Font = FontManager.GetFont(size);
        }
        public void ChangeActiveStatus()
        {
            if (IsActive)
            {
                IsActive = false;
                this.BackColor = ColorManagment.UnActiveButton;
                this.ForeColor = ColorManagment.UnActiveButtonFontColor;
            }
            else
            {
                IsActive = true;
                this.BackColor = ColorManagment.ActiveButton;
                this.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
