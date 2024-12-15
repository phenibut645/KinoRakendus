using KinoRakendus.core.controls.buttons;
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
    public partial class AdminDefaultManagerPage<T> : UserControl
    {
        public Panel SelectPanel { get; set; }
        public Panel OptionsPanel { get; set; }
        public Panel AddPanel { get; set; }
        public Button AddButton { get; set; }
        public List<OptionButton<T>> Buttons = new List<OptionButton<T>>();
        public string FieldName { get; set; }
        public int OptionSize { get; set; }
        public int StartOptionPositionY = 49;
        public int GapBetweenButtons = 20;

        public Panel SelectedPanel { get; set; }
        public OptionButton<T> SelectedButton { get; set; }
    }
}
