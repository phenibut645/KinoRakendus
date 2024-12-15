using KinoRakendus.core.interfaces;
using KinoRakendus.core.models;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.core.controls.buttons
{
    public class SelectOptionButton: Button
    {
        public SelectOption Option { get; set; }
        private bool _optionSelected;
        public bool OptionSelected
        {
            get
            {
                return _optionSelected;
            }
            set
            {
                _optionSelected = value;
                if (_optionSelected)
                {
                    this.BackColor = ColorTranslator.FromHtml("#303689");

                }
                else
                {
                    this.BackColor = ColorTranslator.FromHtml("#464A7A");
                }
            }
        }
        public Action<SelectOptionButton> Func { get; private set; }
        public SelectOptionButton(SelectOption option)
        {
            Option = option;
            this.Text = Option.ExternalText;
            this.Click += clicked;
        }
        private void clicked(object sender, EventArgs e)
        {
            Func(this);
        }
        public void AddClickMethod(Action<SelectOptionButton> func)
        {
            Func = func;
        }
    }
}
