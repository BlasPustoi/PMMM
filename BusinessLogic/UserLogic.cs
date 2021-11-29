using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DTO;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class UserLogic : IUserInterface
    {
        public string _connStr;
        public UserLogic(string connStr)
        {
            this._connStr = connStr;
        }
        public void CreateUser(UserDTO u)
        {

            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User1(login,password,salt,rowInsertTime,role) values(@login,@password,@salt,@rowInsertTime,@role)";
                comm.Parameters.Add("@login", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@login"].Value = u.login;
                comm.Parameters.Add("@password", System.Data.SqlDbType.Binary);
                comm.Parameters["@password"].Value = hash(u.password,u.salt.ToString());
                comm.Parameters.Add("@salt", System.Data.SqlDbType.UniqueIdentifier);
                comm.Parameters["@salt"].Value = u.salt;
                comm.Parameters.Add("@rowInsertTime", System.Data.SqlDbType.DateTime);
                comm.Parameters["@rowInsertTime"].Value = u.rowInsertTime;
                comm.Parameters.Add("@role", System.Data.SqlDbType.Int);
                comm.Parameters["@role"].Value = u.role;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public byte[] hash(string a, string b)
        {
            var data = Encoding.UTF8.GetBytes(a+b);
            using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed())
            {
                var hash = shaM.ComputeHash(data);
                return hash;
            }
        }
        public bool Login(UserDTO u)
        {
            try
            {
                while (u.login.Length < 20)
                {
                    u.login = u.login + " ";
                }
                using (SqlConnection conn = new SqlConnection(this._connStr))
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM USER1 WHERE login = @log";
                    comm.Parameters.Add("@log", System.Data.SqlDbType.NVarChar);
                    comm.Parameters["@log"].Value = u.login;
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        string txt = reader["salt"].ToString();
                        string newsalt = txt.ToLower();

                        if ((string)reader["login"] == u.login && BitConverter.ToString((byte[])reader["password"]) == BitConverter.ToString(hash(u.password, newsalt)))
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
            catch
            {
                return false;
            }
        }
        public int RoleCheck(UserDTO u)
        {
            try
            {
                while (u.login.Length < 20)
                {
                    u.login = u.login + " ";
                }
                using (SqlConnection conn = new SqlConnection(this._connStr))
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM USER1 WHERE login = @log";
                    comm.Parameters.Add("@log", System.Data.SqlDbType.NVarChar);
                    comm.Parameters["@log"].Value = u.login;
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        int role = (int)reader["role"];

                        if (role==1)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
