using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiZakladokNet.Models
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Roles_Id { get; set; }
    }
}
