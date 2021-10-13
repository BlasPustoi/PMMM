using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public DateTime Time { get; set; }

    }
}
