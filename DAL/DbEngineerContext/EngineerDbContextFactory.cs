using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace DAL.DbEngineerContext
{
    public class EngineerDbContextFactory : IDesignTimeDbContextFactory<EngineerDbContext>
    {
        public EngineerDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EngineerDbContext>();
            var connectionString = configuration.GetConnectionString("SQLServer");

            // Configure DbContext with the connection string
            optionsBuilder.UseSqlServer(connectionString);

            return new EngineerDbContext(optionsBuilder.Options);
        }
    }
}

