using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ItemsMap : IEntityTypeConfiguration<ItemsEntity>
    {
        public void Configure(EntityTypeBuilder<ItemsEntity> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(p => p.Id);            
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}