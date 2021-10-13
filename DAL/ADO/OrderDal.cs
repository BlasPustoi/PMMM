using System;
using DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class OrderDal:IOrderDal
    {
        private string _connStr;
        public OrderDal(string connStr)
        {
            this._connStr = connStr;
        }
        public void CreateOrder(OrderDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "insert into Order1(ClientID,ProductID,Time) values(@CID,@PID,@Time)";
                comm.Parameters.Add("@CID", System.Data.SqlDbType.Int);
                comm.Parameters["@CID"].Value = p.ClientID;
                comm.Parameters.Add("@PID", System.Data.SqlDbType.Int);
                comm.Parameters["@PID"].Value = p.ProductID;
                comm.Parameters.Add("@Time", System.Data.SqlDbType.DateTime);
                comm.Parameters["@Time"].Value = p.Time;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }

        public void DeleteOrder(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Order1 where OrderID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = OrderID;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Order1";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var Products = new List<OrderDTO>();
                while (reader.Read())
                {
                    Products.Add(new OrderDTO
                    {
                        OrderID=(int)reader["OrderID"],
                        ClientID = (int)reader["ClientID"],
                        ProductID = (int)reader["ProductID"],
                        Time = (DateTime)reader["Time"]

                    });
                }
                return Products;
            }
        }

        public OrderDTO GetOrderByID(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Order1 where OrderID =" + OrderID.ToString();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return new OrderDTO
                {
                    OrderID = (int)reader["OrderID"],
                    ClientID = (int)reader["ClientID"],
                    ProductID = (int)reader["ProductID"],
                    Time = (DateTime)reader["Time"]
                };
            }
        }

        public void UpdateOrder(OrderDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "update Order1 set ClientID = @CID,ProductID=@PID, Time=@Time where OrderID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = p.OrderID;
                comm.Parameters.Add("@CID", System.Data.SqlDbType.Int);
                comm.Parameters["@CID"].Value = p.ClientID;
                comm.Parameters.Add("@PID", System.Data.SqlDbType.Int);
                comm.Parameters["@PID"].Value = p.ProductID;
                comm.Parameters.Add("@Time", System.Data.SqlDbType.DateTime);
                comm.Parameters["@Time"].Value = p.Time;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }
    }
}
