
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ItemsEntity> Items { get; set; }
        public DbSet<ItemPhotosEntity> ItemPhotos { get; set; }
        public DbSet<ItemPhotoPropertySetEntity> ItemPhotoPropertySet { get; set; }
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base (options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}