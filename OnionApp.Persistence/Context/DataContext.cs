using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Models.Entities;
using OnionApp.Persistence.Context.Configurations;

namespace OnionApp.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<RelationAddress> RelationAddresses { get; set; }

        public RelationCategory RelationCategory { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RelationConfiguration());

            modelBuilder.ApplyConfiguration(new RelationCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.ApplyConfiguration(new RelationAddressConfiguration());
        }
    }
}
