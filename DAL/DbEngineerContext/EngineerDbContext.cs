using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.DbEngineerContext
{
    public class EngineerDbContext : DbContext
    {
        public DbSet<Engineer> tb_engineer { get; set; }
        public DbSet<Location> tb_location { get; set; }
        public DbSet<Appointment> tb_appointment { get; set; }


        public EngineerDbContext(DbContextOptions<EngineerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Automatically configure PK for all IEntity objects
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .HasKey("Id");
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
