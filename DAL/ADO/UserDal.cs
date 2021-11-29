using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.ADO
{
    public static class UserDal
    {
        public static bool Lookfor(string _connstr,string login)
        {
            while (login.Length < 20)
            {
                login = login + " ";
            }
            using (SqlConnection conn = new SqlConnection(_connstr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM USER1 WHERE login = @log";
                comm.Parameters.Add("@log", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@log"].Value = login;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if ((string)reader["login"] == login)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }
    }
}
