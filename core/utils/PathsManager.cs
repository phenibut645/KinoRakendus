﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRakendus.core.utils
{
    public static class PathsManager
    {
        public static string PostersPath { get; set; } = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\other\images\posters"));
        public static string AvatarsPath { get; set; } = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\other\images\avatars"));
        public static string DefaultImagesPath { get; set;} = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\other\images\form-default"));
    }
}
