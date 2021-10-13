using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IProductDal
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductByID(int ProductID);
        void UpdateProduct(ProductDTO p);
        void CreateProduct(ProductDTO p);
        void DeleteProduct(int ProductID);
    }
}
