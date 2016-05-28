using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using RIS4dz.Models;

namespace RIS4dz.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasAlternateKey(s => s.Name);

            modelBuilder.Entity<Order>();
        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockState> StockState { get; set; }
        public DbSet<Fund> Fund { get; set; }
        public DbSet<StockMultiplyer> StockMultiplyer { get; set; }

        public DbSet<StockOrder> StockOrder { get; set; }

        public DbSet<FundOrder> FundOrder { get; set; }

        public DbSet<Order> Order { get; set; }
    }
}
