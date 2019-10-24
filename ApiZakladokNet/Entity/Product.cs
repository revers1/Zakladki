using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApiZakladokNet.Entity
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public string CoordX { get; set; }
        [Required]
        public string CoordY { get; set; }

        public string Description { get; set; }
        public string Imagge { get; set; }
        [ForeignKey("UserOf")]
        public int User_Id { get; set; }
        public virtual User UserOf { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
