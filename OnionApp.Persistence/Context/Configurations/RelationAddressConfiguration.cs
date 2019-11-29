using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Persistence.Context.Configurations
{
    public class RelationAddressConfiguration : IEntityTypeConfiguration<RelationAddress>
    {
        public void Configure(EntityTypeBuilder<RelationAddress> builder)
        {
            builder.ToTable("dbo.tblRelationAddress");
            builder.HasKey(x => x.RelationId);
        }
    }
}
