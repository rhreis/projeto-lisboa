using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class PropertiesMap : IEntityTypeConfiguration<PropertiesEntity>
    {
        public void Configure(EntityTypeBuilder<PropertiesEntity> builder)
        {
            builder.ToTable("Properties");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}