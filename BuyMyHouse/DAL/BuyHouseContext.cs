using BuyMyHouse.DAL.EntityTypeConfigurations;
using BuyMyHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyMyHouse.DAL
{
    public class BuyHouseContext : DbContext
    {
        private readonly FunctionConfiguration _config;

        public DbSet<Customer> Customer { get; set; }

        // public DbSet<House> Houses { get; set; }

        public BuyHouseContext(FunctionConfiguration config) 
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                accountEndpoint: _config.CosmosAccountEndpoint,
                accountKey: _config.CosmosAccountKey,
                databaseName: _config.CosmosDatabaseName
            );
        }
    }
}
