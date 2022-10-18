using BuyMyHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL
{
    public class BuyHouseContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<House> Houses { get; set; }

        public BuyHouseContext(DbContextOptions<BuyHouseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerID)
                .HasDatabaseName("CustomerCode");

                // entity.HasMany(d => d.Invoice);

            }
            );
        }
    }
}
