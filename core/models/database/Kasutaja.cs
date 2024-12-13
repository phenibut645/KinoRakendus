using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using KinoRakendus.core.interfaces;

namespace KinoRakendus.core.models.database
{
    public class Kasutaja: ITable
    {
        public string tableName { get; set; } = "kasutaja";
        public Kasutaja() { }
        public Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"nimi", null },
            {"salasona", null},
            {"vanus", null },
            {"roll", null },
            {"pilt", null}
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
