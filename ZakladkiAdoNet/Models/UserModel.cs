using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakladkiAdoNet.Models
{
   public class UserModel
    {
        
        public string Login { get; set; }
        public string Password { get; set; }
        public int Roles_Id { get; set; }
        public bool IsBanned { get; set; }
    }
}
