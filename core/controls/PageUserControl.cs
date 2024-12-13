using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.core.controls
{
    public partial class PageUserControl : UserControl
    {
        public bool IsInited { get; set;} = false;
        public PageUserControl()
        {
            this.Size = new Size(1720, 903);
            this.Location = new Point(0, 77);
        }

        public void Clear()
        {
            Console.WriteLine("Clearing...");
            foreach(Control control in this.Controls)
            {
                control.Dispose();
            }
            this.Controls.Clear();
            IsInited = false;
        }

        public virtual void InitAll()
        {
            Console.WriteLine("Initing...");
            if (IsInited) throw new Exception("This Page is already inited");
            IsInited = true;
        }
    }
}
