using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.utils;

namespace KinoRakendus
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBHandler dbhandler = new DBHandler("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kinorakendus;Integrated Security=True");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
