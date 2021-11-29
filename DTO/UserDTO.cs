using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int userID { get; set; } = 1;
        public string login { get; set; }
        public string password { get; set; }
        public Guid salt { get; set; } = Guid.NewGuid();
        public DateTime rowInsertTime { get; set; } = DateTime.Now;
        public int role { get; set; } = 0;

    }
}
