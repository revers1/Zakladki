using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakladkiAdoNet
{
    public class User
    {
 
        public string Login { get; set; }
        public string Password { get; set; }
        public int Roles_Id { get; set; }

        public bool IsBlocked { get; set; }
    }
}
