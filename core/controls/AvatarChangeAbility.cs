using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.models;
using KinoRakendus.core.utils;
namespace KinoRakendus.core.controls
{
    public partial class AvatarChangeAbility : UserControl
    {
        public PictureBox Avatar { get; private set; }
        public Panel ButtonContainer { get; private set; } = new Panel();
        public Button ChangeButton { get; private set; }
        public User User { get; private set; }
        public AvatarChangeAbility(User user)
        {
            this.Size = new Size(121, 121);
            this.User = user;
        }
        private void InitAll()
        {
            InitButtonContainer();
            InitButton();
            InitAvatar();
        }
        private void InitAvatar()
        {
            Avatar = new PictureBox();
            Avatar.Size = new Size(121, 121);
            Avatar.Image = ImagesManager.GetAvatar(User);
            
        }
        private void InitButton()
        {
            ChangeButton = new Button();
            ChangeButton.Size = new Size(26, 27);
            ChangeButton.BackgroundImage = ImagesManager.GetDefaultImage("pencil.png");

            ChangeButton.Location = new Point(88, 87);
            ButtonContainer.Controls.Add(ChangeButton);

        }
        private void InitButtonContainer()
        {
            ButtonContainer.Size = new Size(40, 40);
            ButtonContainer.Location = new Point(81, 81);
            ButtonContainer.BackColor = ColorManagment.OptionField;
        }
    }
}
