using KinoRakendus.core.enums;
using KinoRakendus.core.models.database;
using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.models
{
    public class User
    {
        int id;
        string name;
        string password;
        public Rolls roll;
        string picture;
        string vanus;
        public User(string name, string password, Rolls role)
        {
            this.name = name;
            this.password = password;
            this.roll = role;
        }
        public bool Check(string name, string password)
        {
            if (this.name == name && this.password == password)
            {
                return true;
            }
            return false;
        }
        public static User ConvertUser(Kasutaja kasutaja)
        {
            string role = DBHandler.GetSingleResponse($"SELECT roll FROM roll WHERE id = {kasutaja["roll"]}", "roll");
            User user = new User(kasutaja["nimi"], kasutaja["salasona"], (Rolls)RolesManagment.GetRole(role));
            user.id = int.Parse(kasutaja["id"]);
            user.picture = kasutaja["pilt"];
            user.vanus = kasutaja["vanus"];
            return user;
        }
    }
}
