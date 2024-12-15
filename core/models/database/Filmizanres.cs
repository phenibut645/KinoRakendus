using KinoRakendus.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.models.database
{
    public class Filmizanres: Table, ITable
    {
        public string tableName { get; set; } = "filmizanris";
        public Filmizanres() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"film", null },
            {"zanr", null}
        };
    }
}
