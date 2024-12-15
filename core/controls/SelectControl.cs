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
        public List<SelectOptionButton> OptionsButtons { get; set; }
        public Panel Field { get; set;}
        public Label FieldValueLabel { get; set; }
        public PictureBox MoreIcon { get; set; }
        public Panel DownBarPanel { get; set;} = new Panel();
        public int DownBarSizeY { get; set; }
        public int GapBetweenOptions { get; set; }
        public int GapBetweenIconAndFiled { get; set; } = 10;
        private SelectOptionButton _selectedButton;
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
        public SelectControl(List<int> size, List<SelectOption> options, int downBarSizeY = 192, int gapBetweenOptions = 7)
        {
            GapBetweenOptions = gapBetweenOptions;
            FieldSize = size;
            this.Size = new Size(FieldSize[0], FieldSize[1]);
            DownBarSizeY = downBarSizeY;
            InitAll();
            GenerateButtons(options);
        }

        public void ShowDownBar()
        {
            IsDownBarShowed = true;
            DownBarPanel.Show();
        }
        public void HideDownBar()
        {
            IsDownBarShowed = false;
            DownBarPanel.Hide();
        }
        private void FieldClicked(object sender, EventArgs e)
        {
            if (IsDownBarShowed)
            {
                HideDownBar();
            }
            else
            {
                ShowDownBar();
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
            MoreIcon.Size = new Size(14, 14);
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
            RefreshField();
            HideDownBar();
        }

        private void GenerateButtons(List<SelectOption> options)
        {
            int currentY = 0;
            foreach (SelectOption option in options)
            {
                SelectOptionButton button = new SelectOptionButton(option);

                button.Size = new Size(FieldSize[0], 37);
                button.Font = DefaultFonts.GetKanitFont(17);
                button.ForeColor = Color.White;
                button.Location = new Point(0, currentY);
                button.AddClickMethod(ItemSelected);

                OptionsButtons.Add(button);
                DownBarPanel.Controls.Add(button);

                currentY += button.Height + GapBetweenOptions;
            }
        }

    }
}
