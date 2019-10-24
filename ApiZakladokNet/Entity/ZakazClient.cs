using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiZakladokNet.Entity
{
    [Table("ZakazClient")]
    public class ZakazClient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Quantity { get; set; }

        public string Description { get; set; }



    }
}
