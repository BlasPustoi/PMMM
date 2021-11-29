using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic.Interfaces
{
    interface IUserInterface
    {
        void CreateUser(UserDTO u);
        bool Login(UserDTO u);
        byte[] hash(string a, string b);
    }
}
