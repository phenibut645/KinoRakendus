using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRakendus.core.utils
{
    public class DBHandler
    {
        string ConnectionString { get; set; }
        public DBHandler(string connection)
        {
            this.ConnectionString = connection;
        }

        public void makeQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            }
        }
    }
}
