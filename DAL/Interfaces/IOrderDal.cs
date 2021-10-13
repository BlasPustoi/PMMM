using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IOrderDal
    {
        List<OrderDTO> GetAllOrders();
        OrderDTO GetOrderByID(int OrderID);
        void UpdateOrder(OrderDTO o);
        void CreateOrder(OrderDTO o);
        void DeleteOrder(int OrderID);
    }
}
