using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class TypePropertySetMap : IEntityTypeConfiguration<TypePropertySetEntity>
    {
        public void Configure(EntityTypeBuilder<TypePropertySetEntity> builder)
        {
            builder.ToTable("TypePropertySet");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.MediaTypeId).IsRequired();

            builder.Property(p => p.PropertyId).IsRequired();
        }
    }
}