using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Models.Entities;

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
            // Relation
            modelBuilder.Entity<Relation>().ToTable("dbo.tblRelation");
            modelBuilder.Entity<Relation>().HasOne(x => x.RelationAddress).WithOne(x => x.Relation)
                .HasForeignKey<RelationAddress>(x => x.RelationId).OnDelete(DeleteBehavior.Cascade);

            // RelationCategory
            modelBuilder.Entity<RelationCategory>().ToTable("dbo.tblRelationCategory");
            modelBuilder.Entity<RelationCategory>().HasKey(x => new { x.CategoryId, x.RelationId });
            modelBuilder.Entity<RelationCategory>().HasOne(x => x.Relation).WithMany(x => x.RelationCategories)
                .HasForeignKey(x => x.RelationId);
            modelBuilder.Entity<RelationCategory>().HasOne(x => x.Category).WithMany(x => x.RelationCategories)
                .HasForeignKey(x => x.CategoryId);

            // Category
            modelBuilder.Entity<Category>().ToTable("dbo.tblCategory");

            // AddressType
            modelBuilder.Entity<AddressType>().ToTable("dbo.tblAddressType");

            // Country
            modelBuilder.Entity<Country>().ToTable("dbo.tblCountry");

            // RelationAddress
            modelBuilder.Entity<RelationAddress>().ToTable("dbo.tblRelationAddress");
            modelBuilder.Entity<RelationAddress>().HasKey(x => x.RelationId);
        }
    }
}
