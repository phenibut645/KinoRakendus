using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoRakendus.core.enums;
using KinoRakendus.core.models;
using KinoRakendus.core.interfaces;
using KinoRakendus.core.models.database;


namespace KinoRakendus.core.utils
{
    public static class DBHandler
    {
        public static string ConnectionString { get; private set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kinorakendus;Integrated Security=True";

        public static User CheckUser(string username, string password)
        {
            List<Kasutaja> users = GetTableData<Kasutaja>();
            
            foreach(Kasutaja user in users)
            {
                User advancedUser = User.ConvertUser(user);
                if(advancedUser.Check(username, password))
                {
                    return advancedUser;
                }
            }
            return null;
        }
        public static string GetSingleResponse(string query, string field)
        {
            string response = string.Empty;

            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            {
                            response = reader[field].ToString();
                            
                        }
                    }
                }
            }
            return response;
        }
        public static List<T> GetTableData<T>() where T : ITable, new()
        {
            List<T> datas = new List<T>();
            string tableName = new T().tableName;
            string sql = $"SELECT * FROM {tableName}";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    T data = new T();
                    List<string> values = new List<string>();
                    foreach(string field in data.GetFields())
                    {
                        data[field] = dt.Rows[i][field].ToString();
                    }
                    datas.Add(data);
                }
            }
            return datas;
        }
    }
}
