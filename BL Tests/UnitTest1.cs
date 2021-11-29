using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using DTO;
using System.Data.SqlClient;

namespace BL_Tests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void Combo_Fix_Test()
        {

            Assert.IsTrue(Helper.Combo_fix("Products") == "Product" && Helper.Combo_fix("Orders") == "Order1" && Helper.Combo_fix("History") == "History" && Helper.Combo_fix("Clients") == "Client" && Helper.Combo_fix("Orders") == "Order1");
        }
    }
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserLogicTest()
        {
            string c = "Elephant";
            var u = new UserLogic(c);
            Assert.IsTrue(u._connStr == c);
        }
        
        [TestMethod]
        public void CreateUserTest()
        {
            UserDTO u = new UserDTO { login = "Blasovec", salt = Guid.NewGuid(), rowInsertTime = DateTime.Now, role = 0, password = "0" };
            using (SqlConnection conn = new SqlConnection("Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True"))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User1(login,password,salt,rowInsertTime,role) values(@login,@password,@salt,@rowInsertTime,@role)";
                comm.Parameters.Add("@login", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@login"].Value = u.login;
                comm.Parameters.Add("@password", System.Data.SqlDbType.Binary);
                comm.Parameters["@password"].Value = u.password;
                comm.Parameters.Add("@salt", System.Data.SqlDbType.UniqueIdentifier);
                comm.Parameters["@salt"].Value = u.salt;
                comm.Parameters.Add("@rowInsertTime", System.Data.SqlDbType.DateTime);
                comm.Parameters["@rowInsertTime"].Value = u.rowInsertTime;
                comm.Parameters.Add("@role", System.Data.SqlDbType.Int);
                comm.Parameters["@role"].Value = u.role;
                conn.Open();
                comm.ExecuteNonQuery();
            }
            using (SqlConnection conn = new SqlConnection("Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True"))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "Select * from User1 where login = @log";
                comm.Parameters.Add("@log", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@log"].Value = u.login;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                UserDTO u1 = new UserDTO();
                while (reader.Read())
                {
                    u1 = new UserDTO { login = reader["login"].ToString(), salt = (Guid)reader["salt"], rowInsertTime = (DateTime)reader["rowInsertTime"], role = (int)reader["role"], password = "0" };
                }
                Assert.AreEqual(u, u1);

            }
            using (SqlConnection conn = new SqlConnection("Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True"))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "Delete from User1 where login = Blasovec";
                comm.ExecuteNonQuery();
            }
        }
        [TestMethod]
        public void LoginTest()
        {
            string login = "Alzem";
            while (login.Length < 20)
            {
                login = login + " ";
            }
            string password = "123";
            using (SqlConnection conn = new SqlConnection("Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True"))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM USER1 WHERE login = @log";
                comm.Parameters.Add("@log", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@log"].Value = login;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Assert.IsTrue(true);
                    string txt = reader["salt"].ToString();
                    string newsalt = txt.ToLower();

                    if ((string)reader["login"] == login && BitConverter.ToString((byte[])reader["password"]) == BitConverter.ToString(new UserLogic("Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True").hash(password, newsalt)))
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsTrue(false);
                    }
                }
            }

        }
        [TestMethod]
        public void RoleCheck()
        {
            string login = "Alzem";
            while (login.Length < 20)
            {
                login = login + " ";
            }
            using (SqlConnection conn = new SqlConnection("Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True"))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM USER1 WHERE login = @log";
                comm.Parameters.Add("@log", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@log"].Value = login;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int role = (int)reader["role"];

                    if (role == 1)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsTrue(false);
                    }
                }
            }
        }
    }
}
