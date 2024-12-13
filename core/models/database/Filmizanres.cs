using KinoRakendus.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.models.database
{
    public class Filmizanres: ITable
    {
        public string tableName { get; set; } = "filmizanris";
        public Filmizanres() { }
        public Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"film", null },
            {"zanr", null}
        };
        public string this[string key]
        {
            get
            {
                if (_data.ContainsKey(key))
                {
                    return _data[key];
                }
                return null;
         
            }
            set
            {
                if (_data.ContainsKey(key))
                {
                    _data[key] = value;
                }
            }
        }

        public List<string> GetFields()
        {
            return _data.Keys.ToList();
        }
    }
}
