using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface ICommsDal
    {
        List<CommsDTO> GetAllComms();
        CommsDTO GetCommsByID(int OrderID);
        void UpdateComms(CommsDTO p);
        void CreateComms(CommsDTO p);
        void DeleteComms(int OrderID);
    }
}
