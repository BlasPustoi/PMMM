using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.ADO;
using DTO;
using System.Data.SqlClient;
using System;
using System.Configuration;

namespace DAL_TESTS
{
    [TestClass]
    public class ProductDalTests
    {
        [TestMethod]
        public void GetProductByIDTest()
        {
            string connStr = "Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True";
            var p = new ProductDal(connStr);
            string name= "PMMM Vol.1                    ";
            int cost = 20;
            var Product = new DTO.ProductDTO
            {
                ProductID = 1,
                Name = name,
                Cost = cost
            };
            DTO.ProductDTO p1 = p.GetProductByID(1);


            Assert.IsTrue(Product.Name==p1.Name&&p1.ProductID==Product.ProductID&&p1.Cost==Product.Cost );

        }
    }
    
    [TestClass]
    public class ClientDalTests
    {
        [TestMethod]
        public void GetClientByIDTest()
        {
            string connStr = "Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True";
            var p = new ClientDal(connStr);
            string Name = "Blas Lafrenz                  ";
            string Phone = "+79524835089 ";
            var Client = new DTO.ClientDTO
            {
                ClientID = 1,
                name = Name,
                phone = Phone
            };
            
            Assert.IsTrue(Client.name == p.GetClientByID(1).name && Client.phone == p.GetClientByID(1).phone && Client.ClientID == p.GetClientByID(1).ClientID);
        }
    }
}
