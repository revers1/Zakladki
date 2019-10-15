using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiZakladokNet.Entity
{
    public class EFContext:DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        DbSet<Product> Dbproduct { get; set; }
        DbSet<User> Dbuser { get; set; }
        DbSet<Order> Dborder { get; set; }
    }
}
