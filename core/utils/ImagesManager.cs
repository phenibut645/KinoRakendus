using KinoRakendus.core.models;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.utils
{
    public static class ImagesManager
    {
        public static Image GetAvatar(User user)
        {
            if(user.picture != "NULL") return Image.FromFile(Path.Combine(PathsManager.AvatarsPath, user.picture));
            else return Image.FromFile(Path.Combine(PathsManager.DefaultImagesPath, "profile.jpg"));
        }
        public static Image GetPoster(Film film)
        {
            if(film["poster"] != "NULL") return Image.FromFile(Path.Combine(PathsManager.PostersPath, film["poster"]));
            else return Image.FromFile(Path.Combine(PathsManager.DefaultImagesPath, "poster.jpg"));
        }
        public static Image GetDefaultImage(string name)
        {
            return Image.FromFile(Path.Combine(PathsManager.DefaultImagesPath, name));
        }
    }
}
