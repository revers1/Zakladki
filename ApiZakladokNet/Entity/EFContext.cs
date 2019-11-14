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

        public DbSet<Product> Dbproduct { get; set; }
        public DbSet<User> Dbuser { get; set; }
        public DbSet<Role> Dbrole { get; set; }
        public DbSet<ZakazClient> Dbzakaz { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        //public   DbSet<Order> Dborder { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
