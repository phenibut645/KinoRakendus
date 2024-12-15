using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.models
{
    public class WhereField
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public WhereField(string field, string value)
        {
            Field = field;
            Value = value;
        }
    }
}
