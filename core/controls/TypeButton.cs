using KinoRakendus.core.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.core.controls
{
    public class TypeButton: Button
    {
        public Buttons Type { get; set; }
        public UserControl Window { get; set; }
        public TypeButton(Buttons type): base()
        {
            Type = type;
        }
    }
}
