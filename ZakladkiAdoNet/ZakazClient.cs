using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakladkiAdoNet
{
    public class ZakazClient
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Quantity { get; set; }

        public override string ToString()
        {

            return $"Name: {Name}\t" + $"Quantity: {Quantity}\t"+ $"Description: {Description}";
        }
    }
   
}
