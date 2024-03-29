﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakladkiAdoNet
{
   public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Imagge { get; set; }

        public float Quantity { get; set; }

        public string CoordX { get; set; }

        public string CoordY { get; set; }
        public int User_Id { get; set; }

        public override string ToString()
        {

            return $"Name: {Name}\t" + $"Quantity: {Quantity}\t" + $"Description: {Description}. Price - {Price}";
        }
    }
}
