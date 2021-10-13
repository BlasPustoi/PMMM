using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IClientDal
    {
        List<ClientDTO> GetAllClients();
        ClientDTO GetClientByID(int ClientDTO);
        void UpdateClient(ClientDTO p);
        void CreateClient(ClientDTO p);
        void DeleteClient(int ClientID);
    }
}
