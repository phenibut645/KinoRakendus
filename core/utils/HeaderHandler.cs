using KinoRakendus.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.enums;
using KinoRakendus.forms.main.pages;
using KinoRakendus.core.models;
using System.Runtime.CompilerServices;

namespace KinoRakendus.core.utils
{
    public delegate void ChangePage(PageUserControl userControl);
    public static class HeaderHandler
    {
        public static List<HeaderButton> ButtonsInHeader { get; private set;} = null;
        public static HeaderButton ActiveButton { get; private set; } = null;

        public static event ChangePage Notify;
        public static forms.main.Menu Form { get; set; } = null;

        static HeaderHandler()
        {
            if(Form != null)
            {

            }
        }
        public static bool IsButtonLoaded(HeaderButton button)
        {
            if(ButtonsInHeader != null)
            {
                foreach(HeaderButton headerButton in ButtonsInHeader)
                {
                    if(headerButton == button) return true;
                }
            }
            else throw new Exception("The buttons haven't been loaded.");
            return false;
        }
        private static void headerButton_click(object sender, MouseEventArgs e)
        {
            
            HeaderButton button = (HeaderButton)sender;
            if(button != null)
            {
                Console.WriteLine($"the click event have been called by {button.Name.Text} button");

                if(Form != null)
                {
                    if (IsButtonLoaded(button))
                    {
                        Console.WriteLine($"{button.Page} bruh");
                        Form.ChangePage(button.Page);
                        if (ActiveButton != null) ActiveButton.ChangeActiveStatusAuto();
                        button.ChangeActiveStatusAuto();
                        ActiveButton = button;
                    }
                }
                else throw new Exception("The form wasn't given.");
            }
        }
        public static void LoadButtons(List<HeaderButton> buttons)
        {
            if(Form != null)
            {
                ButtonsInHeader = buttons;
                foreach(HeaderButton button in buttons)
                {
                    Console.WriteLine($"{button.Name.Text} button has been added with {button.Page}");
                    button.AddMethodOnClick(headerButton_click);
                }
            }
            else throw new Exception("A form wasn't given to 'Header Handler' class.");

        }
    }
}
