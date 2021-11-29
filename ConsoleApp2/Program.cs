using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using DAL.ADO;
using BusinessLogic;
using DTO;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //var data = Encoding.UTF8.GetBytes("123"+ "de52c199-0dd4-4d09-87f5-89f01cc2e9a8");
            while (true)
            {
                bool logged = false;
                Console.WriteLine("Authorise yourself");
                Console.WriteLine("type register/login to proceed");
                string c = Console.ReadLine();
                switch (c)
                {
                    case "register": CreateUser();break;
                    case "login": if (Login()) { logged = true; }break;
                }
                if (logged == true)
                {
                    break;
                }
            }
            Console.WriteLine("Type help to get the list of commands");
            while (true)
            {
               
                string c = Console.ReadLine();
                Console.Clear();

                switch (c)
                {
                   
                    case "help":Console.WriteLine("show Products\nshow Clients\nshow Orders\nshow Comms\nshow History\nshow Product by ID\nshow Client by ID\nshow Order by ID\nshow History by ID\nshow Comms by ID\nupdate Product\n" +
                        "update Client\nupdate Order\nupdate History\nupdate Comms\ndelete Product\ndelete Client\ndelete Order\ndelete History\ndelete Comms\nadd Product\nadd Client\nadd Order\nadd History\nadd Comms\n");break;
                    case "show Products": GetAllProducts();break;
                    case "show Clients": GetAllClients();break;
                    case "show Orders": GetAllOrders();break;
                    case "show History": GetAllHistory();break;
                    case "show Comms": GetAllComms();break;
                    case "show Product by ID":GetProductByID();break;
                    case "show Client by ID": GetClientByID(); break;
                    case "show Order by ID": GetOrderByID();break;
                    case "show History by ID": GetHistoryByID(); break;
                    case "show Comms by ID": GetCommsByID();break;
                    case "update Product": UpdateProduct();break;
                    case "update Client": UpdateClient();break;
                    case "update Order": UpdateOrder();break;
                    case "update Comms":UpdateComms();break;
                    case "update History": UpdateHistory();break;
                    case "delete Product": DeleteProduct();break;
                    case "delete Client": DeleteClient();break;
                    case "delete Order": DeleteOrder();break;
                    case "delete History": DeleteHistory();break;
                    case "delete Comms": DeleteComms();break;
                    case "add Product": CreateProduct();break;
                    case "add Client": CreateClient();break;
                    case "add Order": CreateOrder();break;
                    case "add History": CreateHistory();break;
                    case "add Comms": CreateComms();break;
                }
            }
        }

        private static bool Login()
        {
            try
            {
                Console.WriteLine("Enter your login:");
                string log = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                string pass = Console.ReadLine();
                UserDTO a = new UserDTO
                {
                    login = log,
                    password = pass
                };
                var p = new UserLogic(ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString);
                if (p.Login(a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Given data most likely was incorrect");
                return false;
            }
        }
        private static void CreateUser()
        {
            Console.WriteLine("Enter your login:");
            string log = Console.ReadLine();
            if (!UserDal.Lookfor(ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString, log))
            {

                Console.WriteLine("Enter your password:");
                string pass = Console.ReadLine();
                UserDTO a = new UserDTO
                {
                    login = log,
                    password = pass
                };
                string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
                var p = new UserLogic(connStr);
                p.CreateUser(a);
            }
            else
            {
                Console.WriteLine("User with that login already exists");
            }
        }
        private static void CreateProduct()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ProductDal(connStr);
            Console.WriteLine("Enter Name:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Cost:\n");
            int cost = Int32.Parse(Console.ReadLine());
            var Product = new DTO.ProductDTO
            {
                ProductID = 0,
                Name = name,
                Cost = cost
            };
            Console.WriteLine("ok");
            p.CreateProduct(Product);
        }
        private static void CreateClient()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ClientDal(connStr);
            Console.WriteLine("Enter Name:\n");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Phone nubmer:\n");
            string phon = Console.ReadLine();
            var Product = new DTO.ClientDTO
            {
                ClientID = 0,
                name = Name,
                phone = phon
            };
            Console.WriteLine("ok");
            p.CreateClient(Product);
        }
        private static void CreateHistory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter finished case:\n");
            bool phon = bool.Parse(Console.ReadLine());
            var Product = new DTO.HistoryDTO
            {
                OrderID = i,
                finished = phon

            };
            Console.WriteLine("ok");
            p.CreateHistory(Product);
        }
        private static void CreateOrder()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            Console.WriteLine("Enter ClientID:\n");
            int CID =Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter ProductID:\n");
            int PID = Int32.Parse(Console.ReadLine());
            var Product = new DTO.OrderDTO
            {
                OrderID = 0,
                ClientID = CID,
                ProductID = PID,
                Time = DateTime.Now
            };
            Console.WriteLine("ok");
            p.CreateOrder(Product);
        }
        private static void CreateComms()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new CommsDal(connStr);
            Console.WriteLine("Enter OrderID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter ClientID:\n");
            int i2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter MS:\n");
            string ms = Console.ReadLine();
            var Product = new DTO.CommsDTO
            {
                OrderID = i,
                ClientID=i2,
                MS=ms

            };
            Console.WriteLine("ok");
            p.CreateComms(Product);
        }

        private static void DeleteProduct()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ProductDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            p.DeleteProduct(i);
        }
        private static void DeleteClient()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ClientDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            p.DeleteClient(i);
        }
        private static void DeleteOrder()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            p.DeleteOrder(i);
        }
        private static void DeleteHistory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            p.DeleteHistory(i);
        }
        private static void DeleteComms()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new CommsDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            p.DeleteComms(i);
        }

        private static void UpdateProduct()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ProductDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Name:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new Cost:\n");
            int cost = Int32.Parse(Console.ReadLine());
            var Product = new DTO.ProductDTO
            {
                ProductID = i,
                Name = name,
                Cost = cost
            };
            Console.WriteLine("ok");
            p.UpdateProduct(Product);
            
        }
        private static void UpdateClient()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ClientDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Name:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new Phone Number:\n");
            string phon = Console.ReadLine();
            var Product = new DTO.ClientDTO
            {
                ClientID = i,
                name = name,
                phone = phon
            };
            Console.WriteLine("ok");
            p.UpdateClient(Product);

        }
        private static void UpdateOrder()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            Console.WriteLine("Enter OrderID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new ClientID :\n");
            int i2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new ProductID:\n");
            int i3 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Time:\n");
            DateTime dateTime = DateTime.Now;

            var Product = new DTO.OrderDTO
            {
                OrderID = i,
                ClientID=i2,
                ProductID=i3,
                Time = dateTime
            };
            Console.WriteLine("ok");
            p.UpdateOrder(Product);

        }
        private static void UpdateHistory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Finished case:\n");
            bool Finish = bool.Parse(Console.ReadLine());
            var Product = new DTO.HistoryDTO
            {
                OrderID = i,
                finished = Finish
            };
            Console.WriteLine("ok");
            p.UpdateHistory(Product);

        }
        private static void UpdateComms()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new CommsDal(connStr);
            Console.WriteLine("Enter new OrderID:\n");
            int i = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new ClientID:\n");
            int i2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new MS:\n");
            string i3 = Console.ReadLine();
            var Product = new DTO.CommsDTO
            {
                OrderID = i,
                ClientID = i2,
                MS=i3
            };
            Console.WriteLine("ok");
            p.UpdateComms(Product);

        }

        private static void GetProductByID()
        {
            Console.WriteLine("Enter ID:\n");
           int i = Int32.Parse(Console.ReadLine());
           string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
           var p = new ProductDal(connStr);
           var Product = p.GetProductByID(i);
            Console.WriteLine($"{Product.ProductID}\t{Product.Name}\t{Product.Cost}");

        }
        private static void GetClientByID()
        {
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new ClientDal(connStr);
            var Product = p.GetClientByID(i);
            Console.WriteLine($"{Product.ClientID}\t{Product.name}\t{Product.phone}");

        }
        private static void GetOrderByID()
        {
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new OrderDal(connStr);
            var Product = p.GetOrderByID(i);
            Console.WriteLine($"{Product.OrderID}\t{Product.ClientID}\t{Product.ProductID}\t{Product.Time}");

        }
        private static void GetHistoryByID()
        {
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new HistoryDal(connStr);
            var Product = p.GetHistoryByID(i);
            Console.WriteLine($"{Product.OrderID}\t{Product.finished}");

        }
        private static void GetCommsByID()
        {
            Console.WriteLine("Enter ID:\n");
            int i = Int32.Parse(Console.ReadLine());
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var p = new CommsDal(connStr);
            var Product = p.GetCommsByID(i);
            Console.WriteLine($"{Product.OrderID}\t{Product.ClientID}\t{Product.MS}");

        }

        private static void GetAllProducts()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var productDal = new ProductDal(connStr);
            var products = productDal.GetAllProducts();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID}\t{p.Name}\t{p.Cost}");
            }
        }
        private static void GetAllClients()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var productDal = new ClientDal(connStr);
            var products = productDal.GetAllClients();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ClientID}\t{p.name}\t{p.phone}");
            }
        }
        private static void GetAllOrders()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var productDal = new OrderDal(connStr);
            var products = productDal.GetAllOrders();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.OrderID}\t{p.ClientID}\t{p.ProductID}\t{p.Time}");
            }
        }
        private static void GetAllHistory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var productDal = new HistoryDal(connStr);
            var products = productDal.GetAllHistory();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.OrderID}\t{p.finished}");
            }
        }
        private static void GetAllComms()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PMMM"].ConnectionString;
            var productDal = new CommsDal(connStr);
            var products = productDal.GetAllComms();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.OrderID}\t{p.ClientID}\t{p.MS}");
            }
        }
    }
}
/*
 *             string connStr = "Data Source=WIN-BDS2CCAJU56;Initial Catalog=Shop;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select ProductID,Name,Cost from Product";

                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                Console.WriteLine(reader["ProductID"] + " " + reader["Name"] + " " + reader["Cost"]);
*/
