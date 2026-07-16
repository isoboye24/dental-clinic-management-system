using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Persistence.Repositories;
using DCMS.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DCMS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register the DbContext with the connection string from configuration
            services.AddDbContext<DCMSDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DCMSConnection")));

            // Register other persistence-related services here if needed
            services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDentistRepository, DentistRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

            return services;
        }
    }
}
