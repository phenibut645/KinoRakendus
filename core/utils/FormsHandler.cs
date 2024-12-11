using KinoRakendus.core.enums;
using KinoRakendus.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.forms.main;
namespace KinoRakendus.core.utils
{
    static class FormsHandler
    {
        public static void ShowMainForm(User user, Form currentForm = null)
        {
            if(currentForm != null)
            {
                currentForm.Dispose();
            }
            forms.main.Menu form = new forms.main.Menu(user);
            form.Show();
        }
    }
}
