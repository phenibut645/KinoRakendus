using KinoRakendus.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.forms.main;
using KinoRakendus.core.enums;

namespace KinoRakendus.core.context
{
    
    public static class FormAppContext
    {
        public static event Action LoggedIn;
        private static User _currentUser;
        public static User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                Console.WriteLine("Invoking");
                LoggedIn?.Invoke();
            }
        }
        public static Rolls Role
        {
            get
            {
                if(CurrentUser != null)
                {
                    return CurrentUser.roll;
                }
                else
                {
                    return Rolls.Guest;
                }
            }
        }
        public static forms.main.Menu MainForm { get; set; } = null;
    }
}
