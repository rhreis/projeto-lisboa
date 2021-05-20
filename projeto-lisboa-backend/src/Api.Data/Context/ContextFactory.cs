using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=VESPIARY\\SQLEXPRESS;Initial Catalog=dbProjetoLisboa;Trusted_Connection=yes;";
            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new ApplicationContext(optionBuilder.Options);
        }
    }
}