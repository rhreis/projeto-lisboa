using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ItemPhotosMap : IEntityTypeConfiguration<ItemPhotosEntity>
    {
        public void Configure(EntityTypeBuilder<ItemPhotosEntity> builder)
        {
            builder.ToTable("ItemPhotos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ItemId);
            builder.Property(p => p.TypeId).IsRequired();
            builder.Property(p => p.FileName).HasMaxLength(50);
            builder.Property(p => p.Position);
            builder.Property(p => p.Alt).HasMaxLength(500);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.ModifiedAt);
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasOne(p => p.Item)
             .WithMany(p => p.ItemPhotos)
             .HasForeignKey(p => p.ItemId);
        }
    }
}