using KinoRakendus.core.enums;
using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.presets;
using KinoRakendus.core.models;
using KinoRakendus.forms.main.pages;
namespace KinoRakendus.core.controls
{
    public class HeaderButton: UserControl
    {
        private bool _isActive = false;
        public bool IsActive 
        { 
            get
            {
                return _isActive;
            } 
            set
            {
                _isActive = value;
                ChangeActiveStatus();
            } 
        }

        public PictureBox Icon { get; set; } = null;
        public Label Name { get; set; } = new Label();
        public Label IconLine { get; set; }
        public PageUserControl Page { get; set; } = null;
        public HeaderButtonType Type { get; set; }
        public User User { get; set; }
        public HeaderButton(PageUserControl page, HeaderButtonType type, string text = null, bool isActive = false, Image image = null, User user = null) 
        {
            
            InitUserControl();
            User = user;
            Type = type;
            Page = page;
            
            if(type == HeaderButtonType.Default && text != null)
            {
                InitLabel();
                Name.Text = text;
            }
            if(image != null)
            {
                InitIcon();
                Icon.Image = image;
            }
            SetButton();
            IsActive = isActive;
        }
        public void AddMethodOnClick(MouseEventHandler method)
        {
            this.MouseDown += method;
        }

        public void SetButton()
        {
            if(Type == HeaderButtonType.Default && Icon != null)
            {
                InitIconLine();
                Console.WriteLine("ICON ISN'T NULL, BITHES");
                this.Size = new Size(DefaultScales.DefaultHeaderButtonWidth, DefaultScales.DefaultHeaderButtonHeight);

                Icon.Location = new Point(DefaultScales.HeaderButtonIconSpace / 2 - Icon.Width / 2, this.Height / 2 - Icon.Height / 2);
                IconLine.Location = new Point(DefaultScales.HeaderButtonIconSpace - IconLine.Width, 0);

                Name.Location = new Point(((Width - DefaultScales.HeaderButtonIconSpace) / 2 - Name.Width / 2) + DefaultScales.HeaderButtonIconSpace, Height / 2 - (int)Math.Round((double)( Name.Height / 2 ) * 1));
            }
            else if(Type == HeaderButtonType.More)
            {
                InitIcon();
                this.Size = new Size(DefaultScales.MoreHeaderButtonWidth, DefaultScales.MoreHeaderButtonHeight);
                this.Icon.Image = DefaultImages.GetMoreIcon();
                Icon.Location = new Point(Width / 2 - Icon.Width / 2, Height / 2 - Icon.Height / 2);
            }
            else if(Type == HeaderButtonType.Profile)
            {
                InitIcon();
                
                this.Size = new Size(DefaultScales.MoreHeaderButtonWidth, DefaultScales.MoreHeaderButtonHeight);
                Icon.Size = new Size(50, 50);
                Icon.Location = new Point(Width / 2 - Icon.Width / 2, Height / 2 - Icon.Height / 2);
                
                if (User != null)
                {
                    Console.WriteLine("ZXCLOX");
                    Icon.Image = DefaultImages.GetAvatar(User);
                    Page = new Profile(User);
                }
            }
        }
        public void InitUserControl()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.BackColor = ColorManagment.ActiveButton;
        }
        public void InitLabel()
        {
            Name = new Label();
            Name.Font = DefaultFonts.GetFont(24);
            Name.BackColor = ColorManagment.InvisibleBackGround;
            Name.ForeColor = Color.White;
            Name.AutoSize = true;
            this.Controls.Add(Name);
        }
        public void InitIcon()
        {

            Icon = new PictureBox();
            Icon.Size = new Size(25, 25);
            Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Icon);
        }
        public void InitIconLine()
        {
            IconLine = new Label();
            IconLine.Size = new Size(DefaultScales.HeaderButtonLineThickness, Height);
            IconLine.BackColor = Color.White;
            this.Controls.Add(IconLine);
        }
        private void ChangeActiveStatus()
        {
            if (IsActive)
            {
                this.BackColor = ColorManagment.ActiveButton;
                Name.ForeColor = Color.White;
            }
            else
            {
                Console.WriteLine($"Switch off the {this.Name.Text} button");
                this.BackColor = ColorManagment.UnActiveButton;
                Name.ForeColor = ColorManagment.UnActiveButtonFontColor;
            }
        }
         public void ChangeActiveStatusAuto()
        {
            IsActive = !IsActive;
        }
    }
}
