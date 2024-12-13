using KinoRakendus.core.controls;
using KinoRakendus.core.enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.models
{
    public class PageDataTemplate
    {
        public string ButtonName { get; set; }
        public PageUserControl Page { get; set; }
        public Rolls Role { get; set; }
        public HeaderButtonType Type { get; set; }
        public Image Icon { get; set; }
        public PageDataTemplate(PageUserControl page, Rolls role, HeaderButtonType type, string buttonName = null, Image icon = null)
        {
            ButtonName = buttonName;
            Page = page;
            Role = role;
            Type = type;
            Icon = icon;
        }
    }
}
