using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ItemPhotoPropertySetMap : IEntityTypeConfiguration<ItemPhotoPropertySetEntity>
    {
        public void Configure(EntityTypeBuilder<ItemPhotoPropertySetEntity> builder)
        {
            builder.ToTable("ItemPhotoPropertySet");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ItemPhotoId).IsRequired();
            builder.Property(p => p.PropertyId).IsRequired();
            builder.Property(p => p.Value).IsRequired().HasMaxLength(50);

            builder.HasOne(p => p.ItemPhotos)
             .WithMany(p => p.ItemPhotoPropertySet)
             .HasForeignKey(p => p.ItemPhotoId);

            builder.HasOne(p => p.Properties)
             .WithMany(p => p.ItemPhotoPropertySet)
             .HasForeignKey(p => p.PropertyId);
        }
    }
}