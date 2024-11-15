using DAL.DbEngineerContext;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;
using Shared.Services.Interfaces;

namespace Shared.Configuration
{
    public static class ServicesConfig
    {
        public static void Register(IServiceCollection services)
        {
            #region Services
                services.AddScoped<IAppointmentService, AppointmentService>();
                services.AddScoped<IEngineerService, EngineerService>();
                services.AddScoped<ILocationService, LocationService>();
            #endregion

            #region Repositories
                services.AddScoped<IEngineerRepository, EngineerRepository>();
                services.AddScoped<IAppointmentRepository, AppointmentRepository>();
                services.AddScoped<ILocationRepository, LocationRepository>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion
        }

        public static void RegisterDb(IServiceCollection services, string connectionString)
        {
            // Register DbContext with the connection string
            services.AddDbContext<EngineerDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(120))
                       .UseLazyLoadingProxies()); // Enable lazy loading
        }
    }
}
