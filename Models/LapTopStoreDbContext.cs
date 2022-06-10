using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LapTopStore.Models
{
    public class LapTopStoreDbContext : DbContext{

    
        public LapTopStoreDbContext(DbContextOptions<LapTopStoreDbContext>
            options)
 : base(options) { }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
    
}
