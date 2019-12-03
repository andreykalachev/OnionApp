using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Persistence.Context.Configurations
{
    public class RelationConfiguration : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> builder)
        {
            builder.ToTable("tblRelation");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.RelationAddress).WithOne(x => x.Relation)
                .HasForeignKey<RelationAddress>(x => x.RelationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
