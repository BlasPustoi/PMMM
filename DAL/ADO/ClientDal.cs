using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class ClientDal : IClientDal
    {
        private string _connStr;
        public ClientDal(string connStr)
        {
            this._connStr = connStr;
        }
        public void CreateClient(ClientDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "insert into Client(Client.Name,Client.Phone) values(@Name,@Phone)";
                comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@Name"].Value = p.name;
                comm.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@Phone"].Value = p.phone;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }

        public void DeleteClient(int ProductID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Client where Client.ClientID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = ProductID;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<ClientDTO> GetAllClients()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Client";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var Products = new List<ClientDTO>();
                while (reader.Read())
                {
                    Products.Add(new ClientDTO
                    {
                        ClientID = (int)reader["ClientID"],
                        name = reader["Name"].ToString(),
                        phone = reader["Phone"].ToString()

                    });
                }
                return Products;
            }
        }

        public ClientDTO GetClientByID(int ClientID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Client where ClientID =" + ClientID.ToString();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return new ClientDTO
                {
                    ClientID = (int)reader["ClientID"],
                    name = reader["Name"].ToString(),
                    phone = reader["Phone"].ToString()
                };
            }
        }

        public void UpdateClient(ClientDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "update Client set Client.Name = @Name,Client.Phone=@Phone where ClientID=@ID";
                comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@Name"].Value = p.name;
                comm.Parameters.Add("@Phone", System.Data.SqlDbType.Int);
                comm.Parameters["@Phone"].Value = p.phone;
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = p.ClientID;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }
    }
}