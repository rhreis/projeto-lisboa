using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class TypesMap : IEntityTypeConfiguration<TypesEntity>
    {
        public void Configure(EntityTypeBuilder<TypesEntity> builder)
        {
            builder.ToTable("Types");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}