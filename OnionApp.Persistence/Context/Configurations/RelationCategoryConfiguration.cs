using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Persistence.Context.Configurations
{
    public class RelationCategoryConfiguration : IEntityTypeConfiguration<RelationCategory>
    {
        public void Configure(EntityTypeBuilder<RelationCategory> builder)
        {
            builder.ToTable("tblRelationCategory");
            builder.HasKey(x => new { x.CategoryId, x.RelationId });
            builder.HasOne(x => x.Relation).WithMany(x => x.RelationCategories)
                .HasForeignKey(x => x.RelationId);
            builder.HasOne(x => x.Category).WithMany(x => x.RelationCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
