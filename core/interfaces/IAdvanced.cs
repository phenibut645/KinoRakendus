using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.interfaces
{
    public interface IAdvanced
    {
        string CurrentValue { get; set; }
        string Field {get; set; }
    }
}
