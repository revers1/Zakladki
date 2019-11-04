using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiZakladokNet.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("RoleOf")]
        public int Roles_Id { get; set; }

        public virtual Role RoleOf { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        public virtual Product ProductOf { get; set; }
        public virtual ICollection<ZakazClient> ZakazOf { get; set; }


    }
}
