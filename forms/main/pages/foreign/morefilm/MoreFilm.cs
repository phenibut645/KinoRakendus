using KinoRakendus.core.controls;
using KinoRakendus.core.models.database;
using KinoRakendus.core.presets;
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

namespace KinoRakendus.forms.main.pages
{
    public partial class MoreFilm : PageUserControl
    {
        public MoreFilm(Film film): base()
        {
            Film = film;
        }
    }
}
