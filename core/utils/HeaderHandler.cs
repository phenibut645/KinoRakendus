using KinoRakendus.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.enums;
using KinoRakendus.forms.main.pages;
using KinoRakendus.forms.main;

namespace KinoRakendus.core.utils
{
    public delegate void ChangePage(PageUserControl userControl);
    public static class HeaderHandler
    {
        public static List<HeaderButton> ButtonsInHeader { get; private set;}
        public static HeaderButton ActiveButton { get; private set; } = null;
        public static event ChangePage Notify;
        public static forms.main.Menu Form { get; set; }


        public static void LoadButtons(List<HeaderButton> buttons)
        {
            ButtonsInHeader = buttons;
            foreach(HeaderButton button in ButtonsInHeader)
            {
                button.Click += button_click;
            }

        }
        public static void PageSwitch(HeaderButton button)
        {
            if(ActiveButton != null)
            {
                if(ActiveButton.Page != null)
                {
                    ActiveButton.Page.Hide();
                }
                ActiveButton.ChangeActiveStatus();
                ActiveButton = button;
                if (ActiveButton.Page == null)ActiveButton.Page = GetUserControl(ActiveButton.Type);
                Form.ChangePage(ActiveButton.Page);
                ActiveButton.ChangeActiveStatus();
            }
            else
            {
                ActiveButton = button;
                ActiveButton.ChangeActiveStatus();
                if (ActiveButton.Page == null) ActiveButton.Page = GetUserControl(ActiveButton.Type);
                Form.ChangePage(ActiveButton.Page);
            }
        }
        private static void button_click(object sender, EventArgs e)
        {
            HeaderButton button = sender as HeaderButton;
            if(button != null)
            {
                PageSwitch(button);
            }
        }
        public static PageUserControl GetUserControl(Buttons buttonType)
        {
            switch (buttonType)
            {
                case Buttons.Kava:
                    return new Kava();
                case Buttons.Piletid:
                    return new Piletid();
                default:
                    return null;
            }
        }
        public static void SetButton<T> (T button) where T: TypeButton
        {
            Buttons typeButton = button.Type;

            switch (typeButton)
            {
                case Buttons.Kava:
                    button.Window = new Kava();
                    return;
                default:
                    return;
            }
        }
    }
}
