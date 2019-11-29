using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Models.Entities;

namespace OnionApp.Persistence.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("dbo.tblCategory");
            builder.HasKey(x => x.Id);
        }
    }
}
