using System;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class HistoryDal:IHistoryDal
    {
        private string _connStr;
        public HistoryDal(string connStr)
        {
            this._connStr = connStr;
        }
        public void CreateHistory(HistoryDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "insert into History(OrderID,Finished) values(@OrderID,@Finished)";
                comm.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
                comm.Parameters["@OrderID"].Value = p.OrderID;
                comm.Parameters.Add("@Finished", System.Data.SqlDbType.Bit);
                comm.Parameters["@Finished"].Value = p.finished;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }

        public void DeleteHistory(int HistoryID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from History where OrderID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = HistoryID;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<HistoryDTO> GetAllHistory()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from History";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var Products = new List<HistoryDTO>();
                while (reader.Read())
                {
                    Products.Add(new HistoryDTO
                    {
                        OrderID = (int)reader["OrderID"],
                        finished =(bool)reader["Finished"]

                    });
                }
                return Products;
            }
        }

        public HistoryDTO GetHistoryByID(int HistoryID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from History where OrderID =" + HistoryID.ToString();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return new HistoryDTO
                {
                    OrderID = (int)reader["OrderID"],
                    finished = (bool)reader["Finished"]
                };
            }
        }

        public void UpdateHistory(HistoryDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "update History set OrderID = @ID,Finished=@Finished where OrderID=@IDA";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = p.OrderID;
                comm.Parameters.Add("@Finished", System.Data.SqlDbType.Bit);
                comm.Parameters["@Finished"].Value = p.finished;
                comm.Parameters.Add("@IDA", System.Data.SqlDbType.Int);
                comm.Parameters["@IDA"].Value = p.OrderID;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }
    }
}
