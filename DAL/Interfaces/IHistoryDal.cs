using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IHistoryDal
    {
        List<HistoryDTO> GetAllHistory();
        HistoryDTO GetHistoryByID(int HistoryID);
        void UpdateHistory(HistoryDTO p);
        void CreateHistory(HistoryDTO p);
        void DeleteHistory(int HistoryID);
    }
}
