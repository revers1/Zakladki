using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiZakladokNet.Entity
{
    [Table("tblUser_Is_Bloked")]
    public class IsBloked
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserBloked")]
        public int Id_User { get; set; }

        [Required]
        public bool Bloked { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual User UserBloked { get; set; }
    }
}
