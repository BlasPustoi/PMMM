using System;
using DTO;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class CommsDal:ICommsDal
    {
        private string _connStr;
        public CommsDal(string connStr)
        {
            this._connStr = connStr;
        }
        public void CreateComms(CommsDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "insert into Comms(OrderID,ClientID,MS) values(@OID,@CID,@MS)";
                comm.Parameters.Add("@OID", System.Data.SqlDbType.Int);
                comm.Parameters["@OID"].Value = p.OrderID;
                comm.Parameters.Add("@CID", System.Data.SqlDbType.Int);
                comm.Parameters["@CID"].Value = p.ClientID;
                comm.Parameters.Add("@MS", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@MS"].Value = p.MS;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }

        public void DeleteComms(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Comms where OrderID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = OrderID;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<CommsDTO> GetAllComms()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Comms";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var Products = new List<CommsDTO>();
                while (reader.Read())
                {
                    Products.Add(new CommsDTO
                    {
                        OrderID = (int)reader["OrderID"],
                        ClientID = (int)reader["ClientID"],
                        MS = reader["MS"].ToString()

                    });
                }
                return Products;
            }
        }

        public CommsDTO GetCommsByID(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Comms where OrderID =" + OrderID.ToString();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return new CommsDTO
                {
                    OrderID = (int)reader["OrderID"],
                    ClientID = (int)reader["ClientID"],
                    MS = reader["MS"].ToString()
                };
            }
        }

        public void UpdateComms(CommsDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "update Comms set OrderID = @ID,ClientID=@CID,MS=@MS where OrderID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = p.OrderID;
                comm.Parameters.Add("@CID", System.Data.SqlDbType.Int);
                comm.Parameters["@CID"].Value = p.ClientID;
                comm.Parameters.Add("@MS", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@MS"].Value = p.MS;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }
    }
}
