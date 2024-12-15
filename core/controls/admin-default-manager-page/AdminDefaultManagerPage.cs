using KinoRakendus.core.interfaces;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.presets;

namespace KinoRakendus.core.controls
{
    public partial class AdminDefaultManagerPage<T> : UserControl where T: Table, ITable, new()
    {
        public AdminDefaultManagerPage(string fieldName, int optionSize = 589)
        {
            this.Size = new Size(DefaultScales.PageWidth, DefaultScales.PageHeight);
            FieldName = fieldName;
            OptionSize = optionSize; 
            InitAll();
        }
        
    }
}
