using KinoRakendus.core.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.utils
{
    static class RolesManagment
    {
        public static Rolls? GetRole(string role)
        {
            if(role == "admin")
            {
                return Rolls.Admin;
            }
            else if(role == "kasutaja"){
                return Rolls.User;
            }
            else if(role == "tootaja")
            {
                return Rolls.Worker;
            }
            return null;
        }
    }
}
