using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiZakladokNet.Entity
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int Product_Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int User_Id { get; set; }
        public virtual User Users { get; set; }
        public virtual Product Products { get; set; }

    }
}
