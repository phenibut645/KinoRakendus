using KinoRakendus.core.context;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinoRakendus.core.utils;
using KinoRakendus.forms.main.pages;

namespace KinoRakendus.core.controls
{
    public partial class MovieCard
    {
        public void buttonMore_clicked(object sedner, EventArgs e)
        {
            HeaderHandler.ChangeToForeignPage(new MoreFilm(this.FilmTable));
        }
    }
}
