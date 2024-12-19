using KinoRakendus.core.controls.buttons;
using KinoRakendus.core.interfaces;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.core.controls
{
    public partial class AdminDefaultManagerPage<T> : UserControl where T: Table, ITable, new()
    {
        public void Selected(OptionButton<T> button)
        {
            if(SelectedButton != null) SelectedButton.IsActive = false;
            SelectedButton = button;
            SelectedButton.IsActive = true;

            InitAdvancedOptions(type: enums.PanelType.Choice);
        }
    }
}
