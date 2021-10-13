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
    public class ProductDal : IProductDal
    {
        private string _connStr;
        public ProductDal(string connStr)
        {
            this._connStr = connStr;
        }
        public void CreateProduct(ProductDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "insert into Product(Product.Name,Product.Cost) values(@Name,@Cost)";
                comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@Name"].Value = p.Name;
                comm.Parameters.Add("@Cost", System.Data.SqlDbType.Int);
                comm.Parameters["@Cost"].Value = p.Cost;
                conn.Open();
                comm.ExecuteNonQuery();

            }
        }

        public void DeleteProduct(int ProductID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Product where Product.ProductID=@ID";
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = ProductID;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Product";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var Products = new List<ProductDTO>();
                while (reader.Read())
                {
                    Products.Add(new ProductDTO
                    {
                        ProductID = (int)reader["ProductID"],
                        Name = reader["Name"].ToString(),
                        Cost = (int)reader["Cost"]

                    }) ;
                }
                return Products;
            }
        }

        public ProductDTO GetProductByID(int ProductID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Product where ProductID =" + ProductID.ToString();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return new ProductDTO
                {
                    ProductID = (int)reader["ProductID"],
                    Name = reader["Name"].ToString(),
                    Cost = (int)reader["Cost"]
                };
            }
        }

        public void UpdateProduct(ProductDTO p)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                
                comm.CommandText = "update Product set Product.Name = @Name,Product.Cost=@Cost where ProductID=@ID";
                comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@Name"].Value = p.Name;
                comm.Parameters.Add("@Cost", System.Data.SqlDbType.Int);
                comm.Parameters["@Cost"].Value = p.Cost;
                comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                comm.Parameters["@ID"].Value = p.ProductID;
                conn.Open();
                comm.ExecuteNonQuery();
                
            }
        }
    }
}
