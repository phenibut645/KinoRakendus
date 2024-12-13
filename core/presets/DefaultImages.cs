using KinoRakendus.core.models;
using KinoRakendus.core.models.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KinoRakendus.core.utils
{
    public static class DefaultImages
    {
        public static Image GetAvatar(User user)
        {
            if(user.picture != "NULL") return Image.FromFile(Path.Combine(DefaultPaths.AvatarsPath, user.picture));
            else return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "profile.jpg"));
        }
        public static Image GetPoster(Film film)
        {
            if(film["poster"] != "NULL") return Image.FromFile(Path.Combine(DefaultPaths.PostersPath, film["poster"]));
            else return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "poster.jpg"));
        }
        public static Image GetDefaultImage(string name)
        {
            Console.WriteLine(DefaultPaths.DefaultImagesPath);
            return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, name));
        }
        public static Image GetMoreIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "menu-burger.png")); }
        public static Image GetHomeIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "home.png")); }
        public static Image GetTicketsIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "receipt.png")); }
        public static Image GetMoviesIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "clapper-open.png")); }
        public static Image GetUsersIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "user-gear.png")); }
        public static Image GetSessionIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "eye.png")); }
        public static Image GetGenreIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "theater-masks.png")); }
        public static Image GetHallIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "stage-theatre.png")); }
    }
}
