using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Persistence.Context.Configurations
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.ToTable("dbo.tblAddressType");
            builder.HasKey(x => x.Id);
        }
    }
}
