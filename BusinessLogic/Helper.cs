using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Helper
    {
        public static string Combo_fix(string Combo_input)
        {
            switch (Combo_input)
            {
            case "Products": return "Product";
            case "Orders": return "Order1";
            case "Clients": return "Client";
            case "Users": return "User1";
            case "Comms": return "Comms";
            case "History": return "History";

            }
            return "whoops";
        }


    }
}
