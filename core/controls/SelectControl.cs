using KinoRakendus.core.controls.buttons;
using KinoRakendus.core.interfaces;
using KinoRakendus.core.models;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using KinoRakendus.core.utils;
using System.Diagnostics;

namespace KinoRakendus.core.controls
{
    public partial class SelectControl: UserControl
    {
        public List<int> FieldSize { get; set;}
        public List<SelectOptionButton> OptionsButtons { get; set; } = new List<SelectOptionButton>();
        public Panel Field { get; set;}
        public Label FieldValueLabel { get; set; }
        public PictureBox MoreIcon { get; set; }
        public Panel DownBarPanel { get; set;} = new Panel();
        public int DownBarSizeY { get; set; }
        public int GapBetweenOptions { get; set; }
        public int GapBetweenIconAndFiled { get; set; } = 10;
        public Action<SelectOptionButton> SelectedMethod { get; set; }
        private SelectOptionButton _selectedButton;
       public Action<int, bool> ShowOrHide { get; set;}
        public SelectOptionButton SelectedOption
        {
            get
            {
                return _selectedButton;
            }
            set
            {
                if(_selectedButton != null)
                {
                    _selectedButton.OptionSelected = false;
                }
                value.OptionSelected = true;
                _selectedButton = value;
            }
        }
        public bool IsDownBarShowed { get; private set; }
        public SelectControl(List<int> size, List<SelectOption> options, int downBarSizeY = 100, int gapBetweenOptions = 7)
        {
            GapBetweenOptions = gapBetweenOptions;
            FieldSize = size;
            this.Size = new Size(FieldSize[0], FieldSize[1]);
            DownBarSizeY = downBarSizeY;
            InitAll();
            GenerateButtons(options);
        }
        public void AddClickMethod(Action<SelectOptionButton> func)
        {
            SelectedMethod = func;
        }
        public void AddShowOrHideMethod(Action<int, bool> func)
        {
            ShowOrHide = func;
        }

        public void ShowDownBar()
        {
            IsDownBarShowed = true;
            
            this.Size = new Size(FieldSize[0], FieldSize[1] + DownBarPanel.Height);
            DownBarPanel.Show();
            
        }
        public void HideDownBar()
        {
            IsDownBarShowed = false;
            this.Size = new Size(FieldSize[0], FieldSize[1]);
            DownBarPanel.Hide();
        }
        private void FieldClicked(object sender, EventArgs e)
        {
            
            if (IsDownBarShowed)
            {
                ShowOrHide(this.DownBarPanel.Height, false);
                HideDownBar();
                Console.WriteLine("HIDE");
            }
            else
            {
                ShowOrHide(this.DownBarPanel.Height, true);
                ShowDownBar();
                Console.WriteLine("SHOW");
            }
        }
        public void InitAll()
        {
            InitField();
            InitDownBar();
        }
        private void InitDownBar()
        {
            DownBarPanel.Size = new Size(FieldSize[0], DownBarSizeY);
            DownBarPanel.BackColor = ColorTranslator.FromHtml("#333550");
            DownBarPanel.AutoScroll = true;
            DownBarPanel.Location = new Point(0, FieldSize[1]);
            this.Controls.Add(DownBarPanel);
            DownBarPanel.Hide();
        }

        private void InitField()
        {
            Field = new Panel();
            Field.BackColor = ColorTranslator.FromHtml("#333550");
            Field.Size = new Size(FieldSize[0], FieldSize[1]);
            this.Controls.Add(Field);

            MoreIcon = new PictureBox();
            MoreIcon.Image = DefaultImages.GetDefaultImage("menu-burger.png");
            MoreIcon.Size = new Size(24, 24);
            MoreIcon.SizeMode = PictureBoxSizeMode.Zoom;
            MoreIcon.BackColor = ColorManagment.InvisibleBackGround;

            FieldValueLabel = new Label();
            FieldValueLabel.Font = DefaultFonts.GetKanitFont(22);
            FieldValueLabel.ForeColor = Color.White;
            FieldValueLabel.BackColor = ColorManagment.InvisibleBackGround;
            FieldValueLabel.Text = "Vali";
            FieldValueLabel.AutoSize = true;

            
            Field.Controls.Add(FieldValueLabel);
            Field.Controls.Add(MoreIcon);
            
            Field.Click += FieldClicked;
            MoreIcon.Click += FieldClicked;
            FieldValueLabel.Click += FieldClicked;
            RefreshField();
        }
        private void RefreshField()
        {
            FieldValueLabel.Location = new Point(Field.Width / 2 - FieldValueLabel.Width / 2 - GapBetweenIconAndFiled - MoreIcon.Width, Field.Height / 2- FieldValueLabel.Height / 2);
            MoreIcon.Location = new Point(Field.Width / 2 - MoreIcon.Width / 2 + FieldValueLabel.Width / 2 + GapBetweenIconAndFiled, Field.Height / 2 - FieldValueLabel.Height / 2);
        }

        private void ItemSelected(SelectOptionButton button)
        {
            SelectedOption = button;
            FieldValueLabel.Text = button.Option.ExternalText;
            Console.WriteLine("SELECTED");
            FieldClicked(null, null);

            if(SelectedMethod != null)
            {
                SelectedMethod(this.SelectedOption);
            }
        }

        private void GenerateButtons(List<SelectOption> options)
        {
            int currentY = 0;
            foreach (SelectOption option in options)
            {
                Console.WriteLine(option.ExternalText);
                SelectOptionButton button = new SelectOptionButton(option);
                button.Size = new Size(FieldSize[0], 37);
                button.Font = DefaultFonts.GetKanitFont(17);
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                
                button.AddClickMethod(ItemSelected);

                OptionsButtons.Add(button);
                DownBarPanel.Controls.Add(button);
                button.Location = new Point(0, currentY);

                currentY += button.Height + GapBetweenOptions;
            }
        }

    }
}
